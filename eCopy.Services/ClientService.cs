﻿using AutoMapper;
using eCopy.Model.Requests;
using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using eCopy.Services.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace eCopy.Services
{
    public class ClientService : BaseCRUDService<ClientResponse, Client, ClientSearch, ClientRequest, ClientRequestUpdate>, IClientService
    {
        private readonly IUserService userService;
        private readonly IPasswordHasher<Database.IdentityUser> hasher;
        private IHttpContextAccessor httpContextAccessor;


        public ClientService(eCopyContext context, IMapper mapper, IUserService userService, IPasswordHasher<Database.IdentityUser> hasher, IHttpContextAccessor httpContextAccessor)
            : base(context, mapper)
        {
            this.userService = userService;
            this.hasher = hasher;
            this.httpContextAccessor = httpContextAccessor;
        }

        public override ClientResponse Insert(ClientRequest entity)
        {
            using var transaction = context.Database.BeginTransaction();

            Client model = mapper.Map<Client>(entity);

            entity.User.Role = Model.Enum.Role.User;
            
            var user = userService.Insert(entity.User);

            var person = mapper.Map<Person>(entity.Person);
            person.Active = entity.Active;
            context.Persons.Add(person);
            context.SaveChanges();

            model.ApplicationUserId = user.Id;
            model.PersonId = person.Id;

            context.Clients.Add(model);
            context.SaveChanges();

            transaction.Commit();
            return mapper.Map<ClientResponse>(model);
        }

        public override ClientResponse Update(int id, ClientRequestUpdate update)
        {

            var client = context.Clients
                .Include(x => x.ApplicationUser)
                .Include(x => x.Person)
                .FirstOrDefault(x => x.Id == id);

            client.Active = update.Active;
            client.Person.FirstName = update.FirstName;
            client.Person.LastName = update.LastName;
            client.Person.MiddleName = update.MiddleName;
            client.Person.Gender = update.Gender.ToString();
            client.Person.CityId = update.CityId;
            client.Person.Address = update.Address;
            client.Person.BirthDate = update.BirthDate;

            client.ApplicationUser.Email = update.Email;
            client.ApplicationUser.UserName = update.Username;
            client.ApplicationUser.PhoneNumber = update.PhoneNumber;

            context.SaveChanges();

            return mapper.Map<ClientResponse>(client);

        }


        public override IEnumerable<ClientResponse> Get(ClientSearch search = null)
        {
            var entity = context.Clients.AsQueryable();

            entity = AddFilter(entity, search);

            var list = entity
                .Include(x => x.ApplicationUser)
                .Include(x => x.Person)
                .ToList();

            return mapper.Map<IList<ClientResponse>>(list);
        }

        public override ClientResponse GetById(int id)
        {
            var entity = context.Clients.AsQueryable();

            var client = entity
                .Include(x => x.ApplicationUser)
                .Include(x => x.Person)
                .FirstOrDefault(x => x.Id == id);

            return mapper.Map<ClientResponse>(client);
        }

        public ClientResponse GetByUsername(string username, string email)
        {
            var entity = context.Clients.AsQueryable();

            var list = entity
                .Include(x => x.ApplicationUser)
                .FirstOrDefault(x => x.ApplicationUser.UserName == username || x.ApplicationUser.Email == email);

            return mapper.Map<ClientResponse>(list);
        }

        public bool ChangePass(PassRequest request)
        {
            var clientIdClaim = httpContextAccessor.HttpContext.User.Claims
               .FirstOrDefault(x => x.Type == "ClientId");
            var clientId = int.Parse(clientIdClaim.Value);

            var client = context.Clients
                .Include(x=> x.ApplicationUser)
                .FirstOrDefault(x => x.Id == clientId);

            if(hasher.VerifyHashedPassword(client.ApplicationUser, client.ApplicationUser.PasswordHash, request.oldPass) != PasswordVerificationResult.Success)
            {
                return false;
            }

            client.ApplicationUser.PasswordHash = hasher.HashPassword(client.ApplicationUser, request.newPass);

            context.SaveChanges();
            
            return true;
        }

        public ClientResponse GetClientAccount()
        {
            var clientIdClaim = httpContextAccessor.HttpContext.User.Claims
                .FirstOrDefault(x => x.Type == "ClientId");

            var clientId = int.Parse(clientIdClaim.Value);

            var cluser = context.Clients
                .Include(x => x.ApplicationUser)
                .Include(x => x.Person)
                .ThenInclude(x=> x.City)
                .FirstOrDefault(x => x.Id == clientId);

            
            return mapper.Map<ClientResponse>(cluser);
        }

        public ClientResponse MyUpdateClient(ClientRequestUpdate update)
        {
            var clientIdClaim = httpContextAccessor.HttpContext.User.Claims
              .FirstOrDefault(x => x.Type == "ClientId");
            var clientId = int.Parse(clientIdClaim.Value);

            var client = context.Clients
                .Include(x => x.ApplicationUser)
                .Include(x => x.Person)
                .FirstOrDefault(x => x.Id == clientId);

            client.Active = update.Active;
            client.Person.FirstName = update.FirstName;
            client.Person.LastName = update.LastName;
            client.Person.MiddleName = update.MiddleName;
            client.Person.Gender = update.Gender.ToString();
            client.Person.CityId = update.CityId;
            client.Person.Address = update.Address;
            client.Person.BirthDate = update.BirthDate;

            client.ApplicationUser.NormalizedEmail = update.Email.ToUpper();
            client.ApplicationUser.Email = update.Email;
            client.ApplicationUser.UserName = update.Username;
            client.ApplicationUser.NormalizedUserName = update.Username.ToUpper();
            client.ApplicationUser.PhoneNumber = update.PhoneNumber;

            context.SaveChanges();

            return mapper.Map<ClientResponse>(client);

        }
    }
}

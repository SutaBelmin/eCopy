using AutoMapper;
using eCopy.Model.Requests;
using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace eCopy.Services
{
    public class ClientService : BaseCRUDService<ClientResponse, Client, ClientSearch, ClientRequest, ClientRequestUpdate>, IClientService
    {
        private readonly IUserService userService;

        public ClientService(eCopyContext context, IMapper mapper, IUserService userService)
            : base(context, mapper)
        {
            this.userService = userService;
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
    }
}

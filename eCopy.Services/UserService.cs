﻿using AutoMapper;
using eCopy.Model.Requests;
using eCopy.Model.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace eCopy.Services
{
    public class UserService : BaseCRUDService<Database.IdentityUser, object, object, ApplicationUserRequest, object>, IUserService
    {
        private readonly IPasswordHasher<Database.IdentityUser> passwordHasher;

        public UserService(eCopyContext context, IMapper mapper, IPasswordHasher<Database.IdentityUser> passwordHasher)
            : base(context, mapper)
        {
            this.passwordHasher = passwordHasher;
        }

        public Database.IdentityUser GetUserByUsername(string username)
        {
            username = username.ToUpperInvariant();
            return context
                .Users
                .Include(x => x.AspNetUserRoles)
                .ThenInclude(x => x.Role)
                .FirstOrDefault(x => x.NormalizedUserName == username || x.NormalizedEmail == username);
        }

        public Database.IdentityUser Insert(ApplicationUserRequest insert)
        {
            var user = mapper.Map<Database.IdentityUser>(insert);
            user.NormalizedUserName = user.UserName.ToUpperInvariant();
            user.NormalizedEmail = user.Email.ToUpperInvariant();
            user.ConcurrencyStamp = Guid.NewGuid().ToString();
            user.PasswordHash = passwordHasher.HashPassword(user, insert.Password);
            context.Users.Add(user);
            context.UserRoles.Add(new Database.IdentityUserRole
            {
                User = user,
                RoleId = (int)insert.Role
            });

            context.SaveChanges();
            return user;
        }

        public GetByUsernameOrEmail GetByUsrnameOrEmail(string username, string email)
        {
            var normalizedUserName = username.ToUpper();
            var normalizedEmail = email.ToUpper();

            var user = context.Users
                .FirstOrDefault(x => x.NormalizedUserName == normalizedUserName);

            var userEmail = context.Users
                .FirstOrDefault(x => x.NormalizedEmail == normalizedEmail);

            return new GetByUsernameOrEmail
            {
                Username = user != null,
                Email = userEmail != null
            };
        }

    }
}

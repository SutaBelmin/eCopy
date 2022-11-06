﻿using eCopy.Model.Requests;
using eCopy.Model.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace eCopy.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService userService;
        private readonly IPasswordHasher<Database.IdentityUser> passwordHasher;
        private readonly IConfiguration configuration;

        public AuthenticationService
        (
            IUserService userService,
            IPasswordHasher<Database.IdentityUser> passwordHasher,
            IConfiguration configuration
        )
        {
            this.userService = userService;
            this.passwordHasher = passwordHasher;
            this.configuration = configuration;
        }
        public AuthenticationResponse Authenticate(AuthenticationRequest request)
        {
            // Dohvatimo user-a po username ili email
            var user = userService.GetUserByUsername(request.Username);
            if(user == null)
            {
                return null;
            }
            // Provjerimo password
            if(passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password) != PasswordVerificationResult.Success)
            {
                return null;
            }
            // Generisemo token
            var role = user.AspNetUserRoles.First();

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = configuration["Jwt:Audience"],
                IssuedAt = DateTime.Now,
                Issuer = configuration["Jwt:Issuer"],
                Claims = new Dictionary<string, object> 
                { 
                    { ClaimTypes.NameIdentifier, user.Id },
                    { ClaimTypes.Role, role.RoleId }
                },
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"])), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = jwtSecurityTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            // Vratimo token
            return new AuthenticationResponse
            {
                Token = jwtSecurityTokenHandler.WriteToken(token)
            };
        }
    }
}

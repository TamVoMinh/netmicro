using System;
using System.Collections.Generic;
using Nmro.IAM.Application.Interfaces;
using Nmro.IAM.Domain.Entities;

namespace Nmro.IAM.Application.UseCases.Systems
{
    public static class SeedUsers
    {
        public static IEnumerable<IdentityUser> List(IPasswordProcessor passwordProcessor)
        {
            var salt = passwordProcessor.GenerateSalt();
            return new List<IdentityUser>{
                new IdentityUser {
                    UserName = "admin",
                    Salt = salt,
                    Password = passwordProcessor.HashWithPbkdf2(passwordProcessor.HashWithSha256("admin123"), salt),
                    Email = "admin@nmro.local",
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow,
                    IsDeleted = false
                }
            };
        }
    }
}

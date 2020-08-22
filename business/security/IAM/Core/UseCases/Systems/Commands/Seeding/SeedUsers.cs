using System;
using System.Collections.Generic;
using Nmro.Shared.Extentions;
using Nmro.Security.IAM.Core.Interfaces;
using Nmro.Security.IAM.Core.Entities;

namespace Nmro.Security.IAM.Core.UseCases.Systems
{
    public static class SeedUsers
    {
        public static IEnumerable<IdentityUser> List(IPasswordProcessor passwordProcessor)
        {
            var salt = passwordProcessor.GenerateSalt();
            return new List<IdentityUser>{
                new IdentityUser {
                    Username = "admin",
                    Salt = salt,
                    Password = passwordProcessor.HashWithPbkdf2("admin123".Sha256(), salt),
                    Email = "admin@nmro.local",
                    Created = DateTime.UtcNow,
                    Updated = DateTime.UtcNow,
                    IsDeleted = false
                }
            };
        }
    }
}

using System;

namespace Nmro.IAM.Application.Users.Queries
 {
 public class IdentityUserModel : BaseEntityModel<long>
    {
        public string UserName {get;set;}

        public string Email {get;set;}

        public bool IsDeleted { get; set; }
    }
 }

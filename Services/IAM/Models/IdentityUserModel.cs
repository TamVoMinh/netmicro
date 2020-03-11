using System;

namespace Nmro.IAM.Models
 {
 public class IdentityUserModel : BaseEntityModel<long>
    {
        public string UserName {get;set;}

        public string Email {get;set;}

        public bool IsDelete { get; set; }
    }
 }

using System;
namespace Nmro.IAM.Application.Users.Models
 {
 public class IdentityUserModel : AuditableModel
    {
        public int Id { get; set; }
        public string UserName {get;set;}
        public string Email {get;set;}
    }
 }

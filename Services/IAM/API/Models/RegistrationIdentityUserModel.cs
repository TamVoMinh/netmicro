using System;

namespace Nmro.IAM.Models
{
    public class UserModifiableModel
    {
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class UserCreatingModel: UserModifiableModel
    {
        public string UserName { get; set; }
    }

    public class UserUpdatingModel: UserModifiableModel
    {
        public long Id { get; set;}
        public DateTime UpdatedDate { get; set; }
    }
}

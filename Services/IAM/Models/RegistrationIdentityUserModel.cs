using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nmro.IAM.Models
{
    public class RegistrationIdentityUserModel: IdentityUserModel
    {
        public string Password { get; set; }
    }
}

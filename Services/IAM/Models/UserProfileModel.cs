using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nmro.IAM.Models
{
    public class UserProfileModel : BaseEntityModel<long>
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
}

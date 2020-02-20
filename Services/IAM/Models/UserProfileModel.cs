using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nmro.IAM.Models
{
    public class UserProfileModel
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}

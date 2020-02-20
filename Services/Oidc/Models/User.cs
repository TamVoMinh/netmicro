using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nmro.Oidc.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public string SubjectId { get => Id.ToString(); }
    }
}

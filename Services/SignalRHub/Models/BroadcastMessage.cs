using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nmro.SignalRHub.Models
{
    public class BroadcastMessage
    {
        public string Type { get; set; }
        public string Payload { get; set; }
    }
}

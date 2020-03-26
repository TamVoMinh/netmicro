using System;
using Nmro.Blocks.Interfaces;

namespace Nmro.Blocks.Services
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public int CurrentYear => DateTime.Now.Year;
    }
}

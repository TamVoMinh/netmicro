using System;

namespace Nmro.Blocks.Interfaces
{
    public interface IDateTime
    {
        DateTime Now { get; }

        int CurrentYear {get;}
    }
}

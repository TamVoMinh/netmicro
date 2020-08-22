using System;

namespace Nmro.Shared.Services
{
    public interface IDateTime
    {
        DateTime Now { get; }

        int CurrentYear {get;}
    }
}

using System;

namespace Nmro.Common.Services
{
    public interface IDateTime
    {
        DateTime Now { get; }

        int CurrentYear {get;}
    }
}

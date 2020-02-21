using Microsoft.AspNetCore.SignalR;
using Nmro.SignalRHub.Interface;

namespace Nmro.SignalRHub
{
    public class SignalRHub: Hub<ITypedHubClient>
    {
    }
}

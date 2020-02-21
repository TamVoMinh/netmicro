using System.Threading.Tasks;

namespace Nmro.SignalRHub.Interface
{
    public interface ITypedHubClient
    {
        Task BroadcastMessage(string type, string payload);
    }
}

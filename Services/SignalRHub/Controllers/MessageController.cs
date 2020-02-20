using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Nmro.SignalRHub.Interface;
using Nmro.SignalRHub.Models;

namespace Nmro.SignalRHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IHubContext<SignalRHub, ITypedHubClient> _hubContext;

        public MessageController(IHubContext<SignalRHub, ITypedHubClient> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public void SendBroadcastMessage([FromBody] BroadcastMessage msg)
        {
            _hubContext.Clients.All.BroadcastMessage(msg.Type, msg.Payload);
        }
    }
}

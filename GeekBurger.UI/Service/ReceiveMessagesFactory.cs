using GeekBurger.UI.Contract;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace GeekBurger.UI.Service
{
    public class ReceiveMessagesFactory : IReceiveMessagesFactory
    {
        private readonly IHubContext<MessageHub> _hubContext;
        private readonly ILogger<ReceiveMessagesService> _logger;
        public ReceiveMessagesFactory(IHubContext<MessageHub> hubContext, ILogger<ReceiveMessagesService> logger)
        {

            _hubContext = hubContext;
            _logger = logger;

            //By default, creates this receivemessageservice
            CreateNew("storecatalogready", "UI");
            CreateNew("userretrieved", "UI");
            //CreateNew("orderpaid", "html", "filter-store", "8048e9ec-80fe-4bad-bc2a-e4f4a75c834e");
        }

        public ReceiveMessagesService CreateNew(string topic, string subscription, string filterName = null, string filter = null)
        {
            return new ReceiveMessagesService(_hubContext, _logger, topic, subscription, filterName, filter);
        }
    }
}

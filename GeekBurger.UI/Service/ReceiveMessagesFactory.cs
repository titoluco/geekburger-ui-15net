using GeekBurger.UI.Contract;
using GeekBurger.UI.Helper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace GeekBurger.UI.Service
{
    public class ReceiveMessagesFactory : IReceiveMessagesFactory
    {
        private readonly IHubContext<MessageHub> _hubContext;
        private readonly ILogger<ReceiveMessagesService> _logger;
        private readonly IShowDisplayService _showDisplayService;
        private readonly ILogService _logService;
        private readonly IMetodosApi _metodosApi;


        public ReceiveMessagesFactory(IHubContext<MessageHub> hubContext, ILogger<ReceiveMessagesService> logger, IShowDisplayService showDisplayService, ILogService logService, IMetodosApi metodosApi)
        {

            _hubContext = hubContext;
            _logger = logger;
            _showDisplayService = showDisplayService;
            _logService = logService;
            _metodosApi = metodosApi;
            //By default, creates this receivemessageservice
            CreateNew(Topics.storecatalogready.ToString(), "UI");
            CreateNew(Topics.userretrieved.ToString(), "UI");
            //CreateNew("orderpaid", "html", "filter-store", "8048e9ec-80fe-4bad-bc2a-e4f4a75c834e");

    }

        public ReceiveMessagesService CreateNew(string topic, string subscription, string filterName = null, string filter = null)
        {
            return new ReceiveMessagesService(_hubContext, _logger, _showDisplayService, _logService, _metodosApi, topic, subscription, filterName, filter);
        }

    }
}

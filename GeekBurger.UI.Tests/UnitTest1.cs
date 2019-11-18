using GeekBurger.UI.Service;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace GeekBurger.UI.Tests
{
    public class Tests
    {

        new Mock<IHubContext<MessageHub>> hubContext;
        new Mock<ILogger<ReceiveMessagesService>> logger;
        new Mock<IShowDisplayService> showDisplayService;
        new Mock<ILogService> logService;
        new Mock<IMetodosApi> metodosApi;
        string topic;
        string subscription;
        string filterName;
        string filter;

        public Tests()
        {
            hubContext = new Mock<IHubContext<MessageHub>>();
            logger = new Mock<ILogger<ReceiveMessagesService>>();
            showDisplayService = new Mock<IShowDisplayService>();
            logService = new Mock<ILogService>();
            metodosApi = new Mock<IMetodosApi>();
            string topic = "teste";
            string subscription = "teste";
            string filterName = null;
            string filter = null;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using System.Threading;
using Microsoft.Extensions.Configuration;
using GeekBurger.UI.Configuration;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Linq;
using GeekBurger.UI.Model;
using Newtonsoft.Json;
using GeekBurger.UI.Contract;

namespace GeekBurger.UI.Service
{

    public class ReceiveMessagesService
    {
        private readonly string _topicName;
        private static ServiceBusConfiguration _serviceBusConfiguration;
        private readonly string _subscriptionName;
        private readonly IHubContext<MessageHub> _hubContext;
        private readonly ILogger<ReceiveMessagesService> _logger;
        private readonly IShowDisplayService _showDisplayService;

        private CancellationTokenSource _cancelMessages;

        /*
        private Task _lastTask;
        private readonly List<Message> _messages;
        */

        public ReceiveMessagesService(IHubContext<MessageHub> hubContext, ILogger<ReceiveMessagesService> logger, IShowDisplayService showDisplayService,
            string topic, string subscription, string filterName = null, string filter = null)
        {
            _logger = logger;
            _hubContext = hubContext;
            _showDisplayService = showDisplayService;

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            _serviceBusConfiguration = configuration.GetSection("serviceBus").Get<ServiceBusConfiguration>();

            _topicName = topic;
            _subscriptionName = subscription;

            _cancelMessages = new CancellationTokenSource();
            ReceiveMessages(filterName, filter);

        }

        private void ReceiveMessages(string filterName = null, string filter = null)
        {
            var subscriptionClient = new SubscriptionClient
                (_serviceBusConfiguration.ConnectionString, _topicName, _subscriptionName);

            var mo = new MessageHandlerOptions(ExceptionHandle) { AutoComplete = true };

            if (filterName != null && filter != null)
            {
                const string defaultRule = "$default";

                if (subscriptionClient.GetRulesAsync().Result.Any(x => x.Name == defaultRule))
                    subscriptionClient.RemoveRuleAsync(defaultRule).Wait();

                if (subscriptionClient.GetRulesAsync().Result.All(x => x.Name != filterName))
                    subscriptionClient.AddRuleAsync(new RuleDescription
                    {
                        Filter = new CorrelationFilter { Label = filter },
                        Name = filterName
                    }).Wait();

            }
            if (_topicName.ToUpper().Equals("STORECATALOGREADY"))
            {
                subscriptionClient.RegisterMessageHandler(HandleStoreCatalogReady, mo);
            }
            else
            {
                subscriptionClient.RegisterMessageHandler(HandleUserRetrieved, mo);
            }

        }

        private Task HandleStoreCatalogReady(Message message, CancellationToken arg2)
        {
            /*
            UserRetrievedMessage userRetrievedMessage = new UserRetrievedMessage() { UserId = new Guid(), AreRestrictionsSet = true };

            _showDisplayService.AddMessageObj<UserRetrievedMessage>(userRetrievedMessage);
            _showDisplayService.SendMessagesAsync();


            return Task.CompletedTask;
            */
            var messageString = "";
            if (message.Body != null)
                messageString = Encoding.UTF8.GetString(message.Body);

            IDictionary<String, Object> propriedades = new Dictionary<String, Object>();
            propriedades.Add("ServicoEnvio", "GeekBurger.UI");
            _showDisplayService.AddMessage("showwelcomepage", "Exibir página de boas vindas", propriedades);
            _showDisplayService.SendMessagesAsync();

            return Task.CompletedTask;
        }

        private Task HandleUserRetrieved(Message message, CancellationToken arg2)
        {
            var messageString = "";
            if (message.Body != null)
                messageString = Encoding.UTF8.GetString(message.Body);

            //UserRetrievedMessage userRetrievedMessage = new UserRetrievedMessage();

            UserRetrievedMessage userRetrievedMessage = message.As<UserRetrievedMessage>();
            if(userRetrievedMessage == null)
            {
                return Task.CompletedTask;

            }

            if (userRetrievedMessage.AreRestrictionsSet)
            {
                //TODO get para produtos
                //get api/products
                //publish message showproduct list


                ProductsListMessage  productsListMessage =  MetodosApi.retornoGet<ProductsListMessage>("http://localhost:50135/Mock/api/products");

                IDictionary<String, Object> propriedades = new Dictionary<String, Object>();
                propriedades.Add("ServicoEnvio", "GeekBurger.UI");
                _showDisplayService.AddMessageObj<ProductsListMessage>(productsListMessage);
                _showDisplayService.SendMessagesAsync();
            }
            else
            {

                IDictionary<String, Object> propriedades = new Dictionary<String, Object>();
                propriedades.Add("ServicoEnvio", "GeekBurger.UI");
                _showDisplayService.AddMessage("showfoodrestrictionsform", "Exibir lista de restrições", propriedades);
                _showDisplayService.SendMessagesAsync();
            }            

            return Task.CompletedTask;
        }

        private Task ExceptionHandle(ExceptionReceivedEventArgs arg)
        {
            _logger.LogError($"Message handler encountered an exception {arg.Exception}.");
            var context = arg.ExceptionReceivedContext;
            _logger.LogError($"- Endpoint: {context.Endpoint}, Path: {context.EntityPath}, Action: {context.Action}");
            return Task.CompletedTask;
        }

        
    }
}

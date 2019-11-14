using GeekBurger.UI.Model;
using GeekBurger.UI.Repository;
using Microsoft.Azure.Management.ServiceBus.Fluent;
using Microsoft.Azure.ServiceBus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SignalR;
using Fiap.GeekBurguer.Users.Contract;
using GeekBurger.UI.Helper;
using System.IO;

namespace GeekBurger.UI.Service
{
    public class ServiceBusTopics : IServiceBusTopics
    {

        private readonly IServiceBusNamespace _namespace;
        private static ServiceBusConfiguration _serviceBusConfiguration;

        public ServiceBusTopics() //IConfiguration configuration, ILogService logService, IServiceProvider serviceProvider)
        {

            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            _serviceBusConfiguration = configuration.GetSection("serviceBus").Get<ServiceBusConfiguration>();

            _namespace = configuration.GetServiceBusNamespace();
            EnsureTopicIsCreated();
        }

        public void EnsureTopicIsCreated()
        {
            //criação dos tópicos
            if (!_namespace.Topics.List()
                .Any(topic => topic.Name
                    .Equals(Topics.uicommand.ToString(), StringComparison.InvariantCultureIgnoreCase)))
                _namespace.Topics.Define(Topics.uicommand.ToString())
                    .WithSizeInMB(1024).Create();

            if (!_namespace.Topics.List()
                .Any(topic => topic.Name
                    .Equals(Topics.neworder.ToString(), StringComparison.InvariantCultureIgnoreCase)))
                _namespace.Topics.Define(Topics.neworder.ToString())
                    .WithSizeInMB(1024).Create();

            if (!_namespace.Topics.List()
                .Any(topic => topic.Name
                    .Equals(Topics.storecatalogready.ToString(), StringComparison.InvariantCultureIgnoreCase)))
                _namespace.Topics.Define(Topics.storecatalogready.ToString())
                    .WithSizeInMB(1024).Create();

            if (!_namespace.Topics.List()
                .Any(topic => topic.Name
                    .Equals(Topics.userretrieved.ToString(), StringComparison.InvariantCultureIgnoreCase)))
                _namespace.Topics.Define(Topics.userretrieved.ToString())
                    .WithSizeInMB(1024).Create();

            // Criação do subscribers
            _namespace.Topics.GetByName(Topics.storecatalogready.ToString()).Subscriptions.Define("UI").Create();
            _namespace.Topics.GetByName(Topics.userretrieved.ToString()).Subscriptions.Define("UI").Create();


        }


    }
}
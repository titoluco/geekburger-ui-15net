﻿using AutoMapper;
using GeekBurger.UI.Contract;
using GeekBurger.UI.Model;
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

namespace GeekBurger.UI.Service
{
    public class ShowDisplayService : IShowDisplayService
    {
        //private const string Topic = "uicommand";
        private readonly IConfiguration _configuration;
        //private readonly IMapper _mapper;
        private readonly List<Message> _messages;
        private Task _lastTask;
        private readonly IServiceBusNamespace _namespace;
        private readonly ILogService _logService;
        private CancellationTokenSource _cancelMessages;
        private IServiceProvider _serviceProvider { get; }

        public ShowDisplayService(IConfiguration configuration, ILogService logService, IServiceProvider serviceProvider)
        {
            //_mapper = mapper;
            _configuration = configuration;
            _logService = logService;
            _messages = new List<Message>();
            _namespace = _configuration.GetServiceBusNamespace();
            _cancelMessages = new CancellationTokenSource();
            _serviceProvider = serviceProvider;
        }


        public void AddMessage(ShowDisplayMessage showDisplayMessage)
        {
            _messages.Clear();
            Message message = new Message();
            message.Label = showDisplayMessage.Label;
            message.Body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(showDisplayMessage.Body));
            if (showDisplayMessage.Properties != null)
            {
                foreach (KeyValuePair<string, object> keyValuePair in showDisplayMessage.Properties)
                {
                    message.UserProperties.Add(keyValuePair);
                }
            }

            _messages.Add(showDisplayMessage.AsMessage());
        }

        public async void SendMessagesAsync(Topics topic)
        {
            try
            {
                if (_lastTask != null && !_lastTask.IsCompleted)
                    return;

                var config = _configuration.GetSection("serviceBus").Get<ServiceBusConfiguration>();
                var topicClient = new TopicClient(config.ConnectionString, topic.ToString());

                _logService.SendMessagesAsync("Face was changed");

                _lastTask = SendAsync(topicClient, _cancelMessages.Token);

                await _lastTask;

                var closeTask = topicClient.CloseAsync();
                await closeTask;
                HandleException(closeTask);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task SendAsync(TopicClient topicClient,
            CancellationToken cancellationToken)
        {
            var tries = 0;
            while (!cancellationToken.IsCancellationRequested)
            {
                if (_messages.Count <= 0)
                    break;

                Message message;
                lock (_messages)
                {
                    message = _messages.FirstOrDefault();
                }

                var sendTask = topicClient.SendAsync(message);
                await sendTask;
                var success = HandleException(sendTask);

                if (!success)
                {
                    var cancelled = cancellationToken.WaitHandle.WaitOne(10000 * (tries < 60 ? tries++ : tries));
                    if (cancelled) break;
                }
                else
                {
                    if (message == null) continue;
                    ///AddOrUpdateEvent(new ShowDisplayEvent() { EventId = new Guid(message.MessageId) });
                    _messages.Remove(message);
                }
            }
        }

        public bool HandleException(Task task)
        {
            if (task.Exception == null || task.Exception.InnerExceptions.Count == 0) return true;

            task.Exception.InnerExceptions.ToList().ForEach(innerException =>
            {
                Console.WriteLine($"Error in SendAsync task: {innerException.Message}. Details:{innerException.StackTrace} ");

                if (innerException is ServiceBusCommunicationException)
                    Console.WriteLine("Connection Problem with Host. Internet Connection can be down");
            });

            return false;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //EnsureTopicIsCreated();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _cancelMessages.Cancel();

            return Task.CompletedTask;
        }


    }
}
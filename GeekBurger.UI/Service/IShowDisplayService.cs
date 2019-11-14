﻿using GeekBurger.UI.Contract;
using GeekBurger.UI.Model;
using GeekBurger.UI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;
using GeekBurger.UI.Helper;

namespace GeekBurger.UI.Service
{
    public interface IShowDisplayService : IHostedService
    {
        void SendMessagesAsync(Topics topic);
        void AddToMessageList(IEnumerable<EntityEntry<FaceModel>> changes);
        void AddMessage(ShowDisplayMessage showDisplayMessage);
    }
}
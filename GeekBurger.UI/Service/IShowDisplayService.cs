using GeekBurger.UI.Contract;
using GeekBurger.UI.Model;
using GeekBurger.UI.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;

namespace GeekBurger.UI.Service
{
    public interface IShowDisplayService : IHostedService
    {
        void SendMessagesAsync();
        void AddToMessageList(IEnumerable<EntityEntry<FaceModel>> changes);
        void AddMessage(string label, string messageText, IDictionary<string, object> properties = null);
        void AddMessageObj<T>(T obj);
    }
}
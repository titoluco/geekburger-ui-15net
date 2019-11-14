using System;

namespace GeekBurger.UI.Service
{
    public interface IReceiveMessagesFactory
    {
        ReceiveMessagesService CreateNew(string topic, string subscription, string filterName = null, string filter = null);
        //ShowDisplayService publicar();
    }
}
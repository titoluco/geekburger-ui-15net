using System;

namespace GeekBurger.UI.Mock
{
    public interface IReceiveMessagesFactory
    {
        ReceiveMessagesService CreateNew(string topic, string subscription, string filterName = null, string filter = null);
    }
}
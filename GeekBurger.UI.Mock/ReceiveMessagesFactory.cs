using GeekBurger.UI.Contract;

namespace GeekBurger.UI.Mock
{
    public class ReceiveMessagesFactory : IReceiveMessagesFactory
    {
        public ReceiveMessagesFactory(dynamic hubContext, dynamic logger)
        {
        }

        public ReceiveMessagesService CreateNew(string topic, string subscription, string filterName = null, string filter = null)
        {
            return new ReceiveMessagesService();
        }
    }
}

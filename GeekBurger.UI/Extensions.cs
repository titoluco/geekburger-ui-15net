using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;

namespace GeekBurger.UI
{
    public static class Extensions
    {
        public static T As<T>(this Message message) where T : class
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(message.Body));          

            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
        public static Message AsMessage(this object obj)
        {
            return new Message(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj)));
        }

        public static bool Any(this IList<Message> collection)
        {
            return collection != null && collection.Count > 0;
        }
    }
}
using System;
using System.Net.Http;

namespace GeekBurger.UI.Controllers
{
    internal class UserConnector
    {
        internal static async void GetUserFromFace(Guid requestiD)
        {
            HttpClient c = new HttpClient();
            var resp = c.GetAsync("");

            SendMessage(resp.Result);
        }
        public void SendMessage(Guid UserId)
        {
            var FoodRestrictionMessage = new FoodRestrictionMessage();

            var topicClient = new TopicClient();
            topicClient.SendMessageAsync(new Message(FoodRestrictionMessage));
    }
}
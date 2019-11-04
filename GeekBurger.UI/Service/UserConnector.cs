using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GeekBurger.UI.Service
{
    public class UserConnector : IUserConnector
    {
        /*
         * EXEMPLO PROFESSOR
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
        */

        public async Task GetUserFromFace(Guid requestiD)
        {

        }
        public async Task SendMessage(Guid UserId)
        {
            
        }
    }
}
using System;
using System.Threading.Tasks;
using GeekBurger.UI.Contract;

namespace GeekBurger.UI.Mock
{
    public class UserConnector : IUserConnector
    {
        public async Task GetUserFromFace(Guid requestiD)
        {
            await SendMessage(new Guid());
        }
        public async Task SendMessage(Guid UserId)
        {
            return;
        }

    }
}

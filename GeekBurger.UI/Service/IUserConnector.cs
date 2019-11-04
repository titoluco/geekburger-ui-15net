using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.UI.Service
{
    public interface IUserConnector
    {
        Task GetUserFromFace(Guid requestiD);
        Task SendMessage(Guid UserId);
    }
}

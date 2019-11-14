using System;
using GeekBurger.UI.Model;

namespace GeekBurger.UI.Repository
{
    public interface IFaceChangedEventRepository
    {
        ShowDisplayEvent Get(Guid eventId);
        bool Add(ShowDisplayEvent faceChangedEvent);
        bool Update(ShowDisplayEvent faceChangedEvent);
        void Save();
    }
}
using System;
using GeekBurger.UI.Model;

namespace GeekBurger.UI.Repository
{
    public interface IFaceChangedEventRepository
    {
        FaceChangedEvent Get(Guid eventId);
        bool Add(FaceChangedEvent faceChangedEvent);
        bool Update(FaceChangedEvent faceChangedEvent);
        void Save();
    }
}
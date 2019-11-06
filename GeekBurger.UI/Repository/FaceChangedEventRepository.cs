using System;
using System.Linq;
using GeekBurger.UI.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekBurger.UI.Repository
{
    public class FaceChangedEventRepository : IFaceChangedEventRepository
    {
        private readonly UIContext _dbContext;

        public FaceChangedEventRepository(UIContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ShowDisplayEvent Get(Guid eventId)
        {
            return _dbContext.FaceChangedEvents
                .FirstOrDefault(face => face.EventId == eventId);
        }

        public bool Add(ShowDisplayEvent faceChangedEvent)
        {
            //faceChangedEvent.Face =
            //    _dbContext.Face
            //    .FirstOrDefault(_ => _.Face == faceChangedEvent.Face.Face);

            faceChangedEvent.EventId = Guid.NewGuid();

            _dbContext.FaceChangedEvents.Add(faceChangedEvent);

            return true;
        }

        public bool Update(ShowDisplayEvent faceChangedEvent)
        {
            return true;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
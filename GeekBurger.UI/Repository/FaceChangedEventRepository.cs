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

        public FaceChangedEvent Get(Guid eventId)
        {
            return _dbContext.FaceChangedEvents
                .FirstOrDefault(face => face.EventId == eventId);
        }

        public bool Add(FaceChangedEvent faceChangedEvent)
        {
            faceChangedEvent.Face =
                _dbContext.Face
                .FirstOrDefault(_ => _.Face == faceChangedEvent.Face.Face);

            faceChangedEvent.EventId = Guid.NewGuid();

            _dbContext.FaceChangedEvents.Add(faceChangedEvent);

            return true;
        }

        public bool Update(FaceChangedEvent faceChangedEvent)
        {
            return true;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
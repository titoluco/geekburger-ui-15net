using GeekBurger.UI.Helper;
using GeekBurger.UI.Model;
using GeekBurger.UI.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.UI.Repository
{
    public class FaceRepository : IFaceRepository
    {
        private UIContext _dbContext;
        private IShowDisplayService _faceChangedService;

        public FaceRepository(UIContext dbContext, IShowDisplayService faceChangedService)
        {
            _dbContext = dbContext;
            _faceChangedService = faceChangedService;
        }

        public FaceModel GetFace(byte[] Face)
        {
            return _dbContext.Face?
                .Include(x => x.RequesterId)
                .FirstOrDefault(x => x.Face == Face);
        }

        public bool Add(FaceModel face)
        {
            face.RequesterId = Guid.NewGuid();
            _dbContext.Face.Add(face);
            return true;
        }
        /*

        public List<Item> GetFullListOfItems()
        {
            return _dbContext.Items.ToList();
        }

   
         public bool Update(Product product)
         {
             return true;
         }

         public IEnumerable<Product> GetProductsByStoreName(string storeName)
         {
             var products = _dbContext.Products?
                 .Where(product =>
                     product.Store.Name.Equals(storeName,
                     StringComparison.InvariantCultureIgnoreCase))
                 .Include(product => product.Items);

             return products;
         }

         public void Delete(Product product)
         {
             _dbContext.Products.Remove(product);
         }
           */

        public void Save()
        {
            _faceChangedService
                .AddToMessageList(_dbContext.ChangeTracker.Entries<FaceModel>());

            _dbContext.SaveChanges();

            _faceChangedService.SendMessagesAsync(Topics.uicommand);
        }

    }
}

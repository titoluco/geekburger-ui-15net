using GeekBurger.UI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.UI.Repository
{
    public class FoodRestrictionsRepository : IFoodRestrictionsRepository
    {
        private UIContext _dbContext;
        //private IProductChangedService _productChangedService;

        public FoodRestrictionsRepository(UIContext dbContext) //, IProductChangedService productChangedService)
        {
            _dbContext = dbContext;
            //_productChangedService = productChangedService;
        }

        public FoodRestrictionsModel GetRestrictionsById(Guid userId)
        {
            return _dbContext.FoodRestrictions?
                .Include(x => x.Restrictions )
                .FirstOrDefault(x => x.UserId == userId);
        }
        /*
        public List<Item> GetFullListOfItems()
        {
            return _dbContext.Items.ToList();
        }

        public bool Add(Product product)
        {
            product.ProductId = Guid.NewGuid();
            _dbContext.Products.Add(product);
            return true;
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

        public void Save()
        {
            _productChangedService
                .AddToMessageList(_dbContext.ChangeTracker.Entries<Product>());

            _dbContext.SaveChanges();

            _productChangedService.SendMessagesAsync();
        }
        */
    }
}

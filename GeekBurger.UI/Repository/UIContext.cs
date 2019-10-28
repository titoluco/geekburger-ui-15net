using GeekBurger.UI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.UI.Repository
{
    public class UIContext : DbContext
    {
        public UIContext(DbContextOptions<UIContext> options)
        : base(options)
        {
        }
        public DbSet<FaceModel> Face { get; set; }
        public DbSet<FoodRestrictionsModel> FoodRestrictions { get; set; }
    }
}

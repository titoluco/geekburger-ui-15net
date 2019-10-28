using GeekBurger.UI.Model;
using GeekBurger.UI.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.UI.Extension
{
    public static class UIContextExtension
    {
        public static void Seed(this UIContext dbContext)
        {

            if (dbContext.Face.Any() ||
                dbContext.FoodRestrictions.Any())
                return;

            dbContext.Face.AddRange(new List<FaceModel> {
                new FaceModel { Face = "Teste 1", Processing = true, RequesterId =  new Guid("8048e9ec-80fe-4bad-bc2a-e4f4a75c834e"), UserId = new Guid("8048e9ec-80fe-4bad-bc2a-e4f4a75c834e") },
                new FaceModel { Face = "Teste 2", Processing = true, RequesterId =  new Guid("8048e9ec-80fe-4bad-bc2a-e4f4a75c834e"), UserId = new Guid("8048e9ec-80fe-4bad-bc2a-e4f4a75c834e") }
            });

            var foodTxt = File.ReadAllText("Food.json");
            var foods = JsonConvert.DeserializeObject<List<FoodRestrictionsModel>>(foodTxt);
            dbContext.FoodRestrictions.AddRange(foods);

            dbContext.SaveChanges();
        }
    }
}

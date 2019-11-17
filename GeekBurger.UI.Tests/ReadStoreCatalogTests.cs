using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace GeekBurger.UI.Tests
{
    public class ReadStoreCatalogTests
    {        
        //{"storeId":"8048e9ec-80fe-4bad-bc2a-e4f4a75c834e","isReady":true}
        [Test]
        public void CatalogVerify_Test_IsReady_True()
        {
            Ready ready = new Ready()
                                {
                                    StoreId = Guid.Parse("8048e9ec-80fe-4bad-bc2a-e4f4a75c834e"),
                                    IsReady = true
                                };

            Assert.IsTrue(ready.IsReady);
        }

        [Test]
        public void CatalogVerify_Test_IsReady_False()
        {
            Ready ready = new Ready()
            {
                StoreId = Guid.Parse("8048e9ec-80fe-4bad-bc2a-e4f4a75c834e"),
                IsReady = false
            };

            Assert.IsFalse(ready.IsReady);
        }
    }

    public class Ready
    {
        public Guid StoreId { get; set; }
        public bool IsReady { get; set; }
    }
}

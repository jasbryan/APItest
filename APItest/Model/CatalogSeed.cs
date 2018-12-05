using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APItest.Model
{
    public static class CatalogSeed
    {
        public static async Task SeedAsync(CatalogContext context)
        {
            context.Database.Migrate();
            if (!context.CatalogBrands.Any())
            {
                context.CatalogBrands.AddRange(GetPreconfiguredCatalogBrands());
            }

            if(!context.CatalogTypes.Any())
            {
                await context.CatalogTypes.AddRangeAsync(GetPreconfiguredCatalogTpyes());
            }

            if (!context.CatalogItems.Any())
            {
                await context.CatalogItems.AddRangeAsync(GetPreconfiguredCatalogItems());
            }
            context.SaveChanges();

        }

        private static CatalogItem[] GetPreconfiguredCatalogItems()
        {
            //throw new NotImplementedException();
            return new CatalogItem[]
             {
                 new CatalogItem
                 {
                     ItemName = "NikeAirs",
                     BrandId = 2,
                     TypeId = 3,
                     Description = "The best Basketball shoes ever",
                     Price = 235.34M
                 },
                 new CatalogItem() { TypeId=2,BrandId=3, Description = "Shoes for next century", ItemName = "World Star", Price = 199.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" },
                new CatalogItem() { TypeId=1,BrandId=2, Description = "will make you world champions", ItemName = "White Line", Price= 88.50M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2" },
                new CatalogItem() { TypeId=2,BrandId=3, Description = "You have already won gold medal", ItemName = "Prism White Shoes", Price = 129, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3" },
                new CatalogItem() { TypeId=2,BrandId=2, Description = "Olympic runner", ItemName = "Foundation Hitech", Price = 12, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4" },
                new CatalogItem() { TypeId=2,BrandId=1, Description = "Roslyn Red Sheet", ItemName = "Roslyn White", Price = 188.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5" },
                new CatalogItem() { TypeId=2,BrandId=2, Description = "Lala Land", ItemName = "Blue Star", Price = 112, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/6" },
                new CatalogItem() { TypeId=2,BrandId=1, Description = "High in the sky", ItemName = "Roslyn Green", Price = 212, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7"  },
                new CatalogItem() { TypeId=1,BrandId=1, Description = "Light as carbon", ItemName = "Deep Purple", Price = 238.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/8" },
                new CatalogItem() { TypeId=1,BrandId=2, Description = "High Jumper", ItemName = "Addidas<White> Running", Price = 129, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/9" },
                new CatalogItem() { TypeId=2,BrandId=3, Description = "Dunker", ItemName = "Elequent", Price = 12, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/10" },
                new CatalogItem() { TypeId=1,BrandId=2, Description = "All round", ItemName = "Inredeible", Price = 248.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/11" },
                new CatalogItem() { TypeId=2,BrandId=1, Description = "Pricesless", ItemName = "London Sky", Price = 412, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/12" },
                new CatalogItem() { TypeId=3,BrandId=3, Description = "Tennis Star", ItemName = "Elequent", Price = 123, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/13" },
                new CatalogItem() { TypeId=3,BrandId=2, Description = "Wimbeldon", ItemName = "London Star", Price = 218.5M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/14" },
                new CatalogItem() { TypeId=3,BrandId=1, Description = "Rolan Garros", ItemName = "Paris Blues", Price = 312, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/15" }
            };
        }

        private static CatalogType[] GetPreconfiguredCatalogTpyes()
        {
            //throw new NotImplementedException();
            return new CatalogType[]
            {
                new CatalogType
                {
                    TypeId = 1,
                    TypeName = "Running"
                },
                new CatalogType
                {
                    TypeId = 2,
                    TypeName = "Walking"
                },
                new CatalogType
                {
                    TypeId = 3,
                    TypeName = "Basketball"
                }
            };
        }

        private static CatalogBrand[] GetPreconfiguredCatalogBrands()
        {
            //throw new NotImplementedException();
            return new CatalogBrand[]
            {
                new CatalogBrand
                {
                    BrandId = 1,
                    BrandName = "Addidas"
                },
                new CatalogBrand
                {
                    BrandId = 2,
                    BrandName = "Nike"
                },
                new CatalogBrand
                {
                    BrandId = 3,
                    BrandName = "Puma"
                },
                new CatalogBrand
                {
                    BrandId = 4,
                    BrandName = "NewBalance"
                }
            };
        }
    }
}

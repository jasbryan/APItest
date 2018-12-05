using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APItest.Model
{
    public class CatalogItem
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public int BrandId { get; set; }

        public int TypeId { get; set; }

        public virtual CatalogBrand ItemBrand { get; set; }

        public virtual CatalogType ItemType { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }

        public decimal Price { get; set; }
    }
}

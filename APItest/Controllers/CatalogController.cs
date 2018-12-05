using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APItest.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace APItest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private CatalogContext _context;
        private IConfiguration _config;
        public CatalogController(CatalogContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [Route("[action]")]
        public async Task<IActionResult> CatalogBrands()
        {
            var brands = await _context.CatalogBrands.ToListAsync();
            return Ok(brands);
        }

        [Route("[action]")]
        public async Task<IActionResult> CatalogTypes()
        {
            var types = await _context.CatalogTypes.ToListAsync();
            return Ok(types);
        }

        [Route("[action]")]
        public async Task<IActionResult> CatalogItems([FromQuery]int pageIndex=0, [FromQuery]int pageSize=6) 
        {

            var items = await _context.CatalogItems
                .OrderBy(c => c.ItemName)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();

            items = ChangeUrlPlaceholders(items);
            return Ok(items);
        }

        private List<CatalogItem> ChangeUrlPlaceholders(List<CatalogItem> items)
        {
            items.ForEach(
                x =>  x.PictureUrl = (!string.IsNullOrEmpty(x.PictureUrl)? 
                x.PictureUrl.Replace("http://externalcatalogbaseurltobereplaced", _config["ExternalUrl"]
            ): null));
            return items;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateProduct([FromBody]CatalogItem product)
        {
            if (product == null || string.IsNullOrEmpty(product.ItemName) || product.Price < 0 )
                return BadRequest("Bad damn product!!!");

            var item = new CatalogItem
            {
                ItemName = product.ItemName,
                Price = product.Price,
                BrandId = product.BrandId,
                TypeId = product.TypeId,
                Description = product.Description,
                PictureUrl = product.PictureUrl
            };

            _context.CatalogItems.Add(item);
            await _context.SaveChangesAsync();

            return Ok(item);
        }

    }
}
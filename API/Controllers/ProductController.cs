using API.Helpers;
using API.Logic;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IGenericRepository<ProductEntity> _product;
        private readonly ProductLogic _productLogic;

        public ProductController(IGenericRepository<ProductEntity> product)
        {
            _product = product;
            _productLogic = new(_product);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductEntity>>> GetProduct([FromQuery] ProductSpecParams productParams)
        {
            Pagination<ProductEntity> product = await _productLogic.GetProductLogic(productParams);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductEntity>> PostProduct([FromBody] ProductEntity product)
        {
            ProductEntity save = await _productLogic.PostProductLogic(product);
            return Ok(save);
        }
    }
}

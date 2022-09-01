using API.Helpers;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

namespace API.Logic
{
    public class ProductLogic
    {
        private readonly IGenericRepository<ProductEntity> _product;

        public ProductLogic(IGenericRepository<ProductEntity> product)
        {
            _product = product;
        }

        public async Task<Pagination<ProductEntity>> GetProductLogic(ProductSpecParams productParams)
        {
            var spec = new ProductFilterSpecification(productParams);
            var products = await _product.ListWithSpecAsync(spec);
            var totalItems = await _product.CountAsync(spec);
            return new Pagination<ProductEntity>(productParams.PageIndex, productParams.PageSize, totalItems, products);
        }

        public async Task<ProductEntity> PostProductLogic(ProductEntity product)
        {
            return await _product.Add(product);
        }
    }
}

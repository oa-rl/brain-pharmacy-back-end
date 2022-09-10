using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

namespace API.Logic
{
    public class ProductLogic
    {
        private readonly IGenericRepository<ProductEntity> _product;
        private readonly IMapper _mapper;


        public ProductLogic(IGenericRepository<ProductEntity> product, IMapper mapper)
        {
            _product = product;
            _mapper = mapper;
        }

        public async Task<Pagination<ProductDto>> GetProductLogic(ProductSpecParams productParams)
        {
            var spec = new ProductFilterSpecification(productParams);
            var products = await _product.ListWithSpecAsync(spec);
            var totalItems = await _product.CountAsync(spec);
            IReadOnlyList<ProductDto> productsToReturn = _mapper.Map<IReadOnlyList<ProductEntity>, IReadOnlyList<ProductDto>>(products);
            return new Pagination<ProductDto>(productParams.PageIndex, productParams.PageSize, totalItems, productsToReturn);
        }

        public async Task<ProductDto> GetProductIdLogic(int id)
        {
            var product = await _product.GetByIdAsync(id);
            ProductDto ProductDto = _mapper.Map<ProductEntity, ProductDto>(product);
            return ProductDto;
        }

        public async Task<ResponseOk<ProductDto>> PostProduct(ProductEntity product)
        {

            ProductEntity ProductEntity = await _product.Add(product);
            ProductDto ProductDto = _mapper.Map<ProductEntity, ProductDto>(ProductEntity);
            ResponseOk<ProductDto> response = new(201, true, ProductDto);
            return response;
        }

        public async Task<ProductDto> PutProduct(ProductEntity product)
        {
            ProductEntity ProductEntity = await _product.Update(product);
            ProductDto ProductDto = _mapper.Map<ProductEntity, ProductDto>(ProductEntity);
            return ProductDto;
        }

        public async Task<ProductDto> DeleteProduct(ProductEntity product)
        {
            ProductEntity ProductEntity = await _product.Delete(product);
            ProductDto ProductDto = _mapper.Map<ProductEntity, ProductDto>(ProductEntity);
            return ProductDto;
        }

    }
}

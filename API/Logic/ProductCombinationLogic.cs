using System;
using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

namespace API.Logic
{
	public class ProductCombinationLogic
	{
        private readonly IGenericRepository<ProductCombinationEntity> _product;
        private readonly IMapper _mapper;


        public ProductCombinationLogic(IGenericRepository<ProductCombinationEntity> product, IMapper mapper)
        {
            _product = product;
            _mapper = mapper;
        }

        public async Task<Pagination<ProductCombinationDto>> GetProductLogic(ProductCombinationSpecParams productCombinationParams)
        {
            var spec = new ProductCombinationFilterSpecification(productCombinationParams);
            var products = await _product.ListWithSpecAsync(spec);
            var totalItems = await _product.CountAsync(spec);
            IReadOnlyList<ProductCombinationDto> productsToReturn = _mapper.Map<IReadOnlyList<ProductCombinationEntity>, IReadOnlyList<ProductCombinationDto>>(products);
            return new Pagination<ProductCombinationDto>(productCombinationParams.PageIndex, productCombinationParams.PageSize, totalItems, productsToReturn);
        }

        public async Task<ProductCombinationDto> GetProductIdLogic(int id)
        {
            var product = await _product.GetByIdAsync(id);
            ProductCombinationDto ProductDto = _mapper.Map<ProductCombinationEntity, ProductCombinationDto>(product);
            return ProductDto;
        }

        public async Task<ResponseOk<ProductCombinationDto>> PostProduct(ProductCombinationEntity product)
        {

            ProductCombinationEntity ProductCombination = await _product.Add(product);
            ProductCombinationDto ProductDto = _mapper.Map<ProductCombinationEntity, ProductCombinationDto>(ProductCombination);
            ResponseOk<ProductCombinationDto> response = new(201, true, ProductDto);
            return response;
        }

        public async Task<ProductCombinationDto> PutProduct(ProductCombinationEntity product)
        {
            ProductCombinationEntity ProductCombination = await _product.Update(product);
            ProductCombinationDto ProductDto = _mapper.Map<ProductCombinationEntity, ProductCombinationDto>(ProductCombination);
            return ProductDto;
        }

        public async Task<ProductCombinationDto> DeleteProduct(ProductCombinationEntity product)
        {
            ProductCombinationEntity ProductCombination = await _product.Delete(product);
            ProductCombinationDto ProductDto = _mapper.Map<ProductCombinationEntity, ProductCombinationDto>(ProductCombination);
            return ProductDto;
        }

    }
}


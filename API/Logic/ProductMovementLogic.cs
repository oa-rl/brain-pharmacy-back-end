using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

namespace API.Logic
{
    public class ProductMovementLogic
    {
        private readonly IGenericRepository<ProductMovementEntity> _productMovement;
        private readonly IGenericRepository<ProductCombinationEntity> _productCombination;
        private readonly IMapper _mapper;


        public ProductMovementLogic(IGenericRepository<ProductMovementEntity> productMovement, IMapper mapper, IGenericRepository<ProductCombinationEntity> productCombination)
        {
            _productMovement = productMovement;
            _productCombination = productCombination;
            _mapper = mapper;
        }

        public async Task<Pagination<ProductMovementDto>> GetProductMovementLogic(ProductMovementSpecParams ProductMovementParams)
        {
            var spec = new ProductMovementFilterSpecification(ProductMovementParams);
            var products = await _productMovement.ListWithSpecAsync(spec);
            var totalItems = await _productMovement.CountAsync(spec);
            IReadOnlyList<ProductMovementDto> userToReturn = _mapper.Map<IReadOnlyList<ProductMovementEntity>, IReadOnlyList<ProductMovementDto>>(products);
            return new Pagination<ProductMovementDto>(ProductMovementParams.PageIndex, ProductMovementParams.PageSize, totalItems, userToReturn);
        }

        public async Task<ProductMovementDto> GetProductMovementIdLogic(int id)
        {
            var productMovement = await _productMovement.GetByIdAsync(id);
            ProductMovementDto ProductMovementDto = _mapper.Map<ProductMovementEntity, ProductMovementDto>(productMovement);
            return ProductMovementDto;
        }

        public async Task<ResponseOk<ProductMovementDto>> PostProductMovement(ProductMovementEntity productMovement)
        {
            ProductCombinationEntity combination = await _productCombination.GetByIdAsync(productMovement.ProductCombinationId);
            combination.Existence += productMovement.Quantity;
            await _productCombination.Update(combination);
            ProductMovementEntity ProductMovementEntity = await _productMovement.Add(productMovement);
            ProductMovementDto ProductMovementDto = _mapper.Map<ProductMovementEntity, ProductMovementDto>(ProductMovementEntity);
            ResponseOk<ProductMovementDto> response = new(201, true, ProductMovementDto);
            return response;
        }

        public async Task<ProductMovementDto> PutProductMovement(ProductMovementEntity productMovement)
        {
            ProductMovementEntity ProductMovementEntity = await _productMovement.Update(productMovement);
            ProductMovementDto ProductMovementDto = _mapper.Map<ProductMovementEntity, ProductMovementDto>(ProductMovementEntity);
            return ProductMovementDto;
        }

        public async Task<ProductMovementDto> DeleteProductMovement(ProductMovementEntity productMovement)
        {
            ProductMovementEntity ProductMovementEntity = await _productMovement.Delete(productMovement);
            ProductMovementDto ProductMovementDto = _mapper.Map<ProductMovementEntity, ProductMovementDto>(ProductMovementEntity);
            return ProductMovementDto;
        }
    }
}

using API.Dtos;
using API.Helpers;
using API.Logic;
using AutoMapper;
using Core;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductMovementController: BaseController
    {
        private readonly IGenericRepository<ProductMovementEntity> _productMovement;
        private readonly IGenericRepository<ProductCombinationEntity> _productCombination;
        private readonly IMapper _mapper;
        private readonly ProductMovementLogic _productMovementLogic;

        public ProductMovementController(IGenericRepository<ProductMovementEntity> productMovement, IMapper mapper, IGenericRepository<ProductCombinationEntity> productCombination)
        {
            _productMovement = productMovement;
            _productCombination = productCombination;
            _mapper = mapper;
            _productMovementLogic = new(_productMovement, _mapper, _productCombination);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductMovementDto>>> GetProductMovements([FromQuery] ProductMovementSpecParams productMovementParams)
        {
            Pagination<ProductMovementDto> product = await _productMovementLogic.GetProductMovementLogic(productMovementParams);
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductMovementDto>> GetProductMovement(int id)
        {
            ProductMovementDto product = await _productMovementLogic.GetProductMovementIdLogic(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ResponseOk<ProductMovementDto>> PostProductMovement([FromBody] ProductMovementEntity productMovement)
        {
            return await _productMovementLogic.PostProductMovement(productMovement);
        }

        [HttpPut]
        public async Task<ActionResult<ProductMovementDto>> PutProductMovement([FromBody] ProductMovementEntity productMovement)
        {
            ProductMovementDto update = await _productMovementLogic.PutProductMovement(productMovement);
            return Ok(update);
        }

        [HttpDelete]
        public async Task<ActionResult<ProductMovementDto>> DeleteProductMovement([FromBody] ProductMovementEntity productMovement)
        {
            ProductMovementDto delete = await _productMovementLogic.DeleteProductMovement(productMovement);
            return Ok(delete);
        }
    }
}

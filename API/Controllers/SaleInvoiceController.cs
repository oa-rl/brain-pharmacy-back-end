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
    public class SaleInvoiceController: BaseController
    {
        private readonly IGenericRepository<SaleInvoiceEntity> _saleInvoice;
        private readonly IGenericRepository<ProductMovementEntity> _productMovement;
        private readonly IGenericRepository<ProductCombinationEntity> _productCombination;
        private readonly IMapper _mapper;
        private readonly SaleInvoiceLogic _saleInvoiceLogic;

        public SaleInvoiceController(IGenericRepository<SaleInvoiceEntity> saleInvoice, IMapper mapper, IGenericRepository<ProductMovementEntity> productMovement, IGenericRepository<ProductCombinationEntity> productCombination)
        {
            _saleInvoice = saleInvoice;
            _mapper = mapper;
            _productMovement = productMovement;
            _productCombination = productCombination;

            _saleInvoiceLogic = new(_saleInvoice, _mapper, _productMovement, _productCombination);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<SaleInvoiceDto>>> GetProducts([FromQuery] SaleInvoiceSpecParams saleInvoiceParams)
        {
            Pagination<SaleInvoiceDto> product = await _saleInvoiceLogic.GetSaleInvoiceLogic(saleInvoiceParams);
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SaleInvoiceDto>> GetSaleInvoice([FromQuery] SaleInvoiceSpecParams saleInvoiceParams)
        {
            SaleInvoiceDto product = await _saleInvoiceLogic.GetSaleInvoiceIdLogic(saleInvoiceParams);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ResponseOk<SaleInvoiceDto>> PostSaleInvoice([FromBody] SaleInvoiceEntity saleInvoice, [FromHeader] HeadersMap headers)
        {
            return await _saleInvoiceLogic.PostSaleInvoice(saleInvoice, headers);
        }

        [HttpPut]
        public async Task<ActionResult<SaleInvoiceDto>> PutSaleInvoice([FromBody] SaleInvoiceEntity saleInvoice)
        {
            SaleInvoiceDto update = await _saleInvoiceLogic.PutSaleInvoice(saleInvoice);
            return Ok(update);
        }

        [HttpDelete]
        public async Task<ActionResult<SaleInvoiceDto>> DeleteSaleInvoice([FromBody] SaleInvoiceEntity saleInvoice)
        {
            SaleInvoiceDto delete = await _saleInvoiceLogic.DeleteSaleInvoice(saleInvoice);
            return Ok(delete);
        }
    }
}

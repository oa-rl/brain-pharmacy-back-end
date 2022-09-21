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
    public class SaleInvoiceDetailsController: BaseController
    {
        private readonly IGenericRepository<SaleInvoiceDetailsEntity> _saleInvoiceDetails;
        private readonly IMapper _mapper;
        private readonly SaleInvoiceDetailsLogic _saleInvoiceDetailsLogic;

        public SaleInvoiceDetailsController(IGenericRepository<SaleInvoiceDetailsEntity> saleInvoiceDetails, IMapper mapper)
        {
            _saleInvoiceDetails = saleInvoiceDetails;
            _mapper = mapper;
            _saleInvoiceDetailsLogic = new(_saleInvoiceDetails, _mapper);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<SaleInvoiceDetailsDto>>> GetProducts([FromQuery] SaleInvoiceDetailsSpecParams saleInvoiceDetailsParams)
        {
            Pagination<SaleInvoiceDetailsDto> product = await _saleInvoiceDetailsLogic.GetSaleInvoiceDetailsLogic(saleInvoiceDetailsParams);
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SaleInvoiceDetailsDto>> GetSaleInvoiceDetails(int id)
        {
            SaleInvoiceDetailsDto product = await _saleInvoiceDetailsLogic.GetSaleInvoiceDetailsIdLogic(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ResponseOk<SaleInvoiceDetailsDto>> PostSaleInvoiceDetails([FromBody] SaleInvoiceDetailsEntity saleInvoiceDetails)
        {
            return await _saleInvoiceDetailsLogic.PostSaleInvoiceDetails(saleInvoiceDetails);
        }

        [HttpPut]
        public async Task<ActionResult<SaleInvoiceDetailsDto>> PutSaleInvoiceDetails([FromBody] SaleInvoiceDetailsEntity saleInvoiceDetails)
        {
            SaleInvoiceDetailsDto update = await _saleInvoiceDetailsLogic.PutSaleInvoiceDetails(saleInvoiceDetails);
            return Ok(update);
        }

        [HttpDelete]
        public async Task<ActionResult<SaleInvoiceDetailsDto>> DeleteSaleInvoiceDetails([FromBody] SaleInvoiceDetailsEntity saleInvoiceDetails)
        {
            SaleInvoiceDetailsDto delete = await _saleInvoiceDetailsLogic.DeleteSaleInvoiceDetails(saleInvoiceDetails);
            return Ok(delete);
        }
    }
}

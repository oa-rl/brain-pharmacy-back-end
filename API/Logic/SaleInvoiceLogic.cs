using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

namespace API.Logic
{
    public class SaleInvoiceLogic
    {
        private readonly IGenericRepository<SaleInvoiceEntity> _size;
        private readonly IMapper _mapper;


        public SaleInvoiceLogic(IGenericRepository<SaleInvoiceEntity> saleInvoice, IMapper mapper)
        {
            _size = saleInvoice;
            _mapper = mapper;
        }

        public async Task<Pagination<SaleInvoiceDto>> GetSaleInvoiceLogic(SaleInvoiceSpecParams saleInvoiceParams)
        {
            var spec = new SaleInvoiceFilterSpecification(saleInvoiceParams);
            var salesInvoice = await _size.ListWithSpecAsync(spec);
            var totalItems = await _size.CountAsync(spec);
            IReadOnlyList<SaleInvoiceDto> productsToReturn = _mapper.Map<IReadOnlyList<SaleInvoiceEntity>, IReadOnlyList<SaleInvoiceDto>>(salesInvoice);
            return new Pagination<SaleInvoiceDto>(saleInvoiceParams.PageIndex, saleInvoiceParams.PageSize, totalItems, productsToReturn);
        }

        public async Task<SaleInvoiceDto> GetSaleInvoiceIdLogic(int id)
        {
            var saleInvoice = await _size.GetByIdAsync(id);
            SaleInvoiceDto SaleInvoiceDto = _mapper.Map<SaleInvoiceEntity, SaleInvoiceDto>(saleInvoice);
            return SaleInvoiceDto;
        }

        public async Task<ResponseOk<SaleInvoiceDto>> PostSaleInvoice(SaleInvoiceEntity saleInvoice)
        {

            SaleInvoiceEntity SaleInvoiceEntity = await _size.Add(saleInvoice);
            SaleInvoiceDto SaleInvoiceDto = _mapper.Map<SaleInvoiceEntity, SaleInvoiceDto>(SaleInvoiceEntity);
            ResponseOk<SaleInvoiceDto> response = new(201, true, SaleInvoiceDto);
            return response;
        }

        public async Task<SaleInvoiceDto> PutSaleInvoice(SaleInvoiceEntity saleInvoice)
        {
            SaleInvoiceEntity SaleInvoiceEntity = await _size.Update(saleInvoice);
            SaleInvoiceDto SaleInvoiceDto = _mapper.Map<SaleInvoiceEntity, SaleInvoiceDto>(SaleInvoiceEntity);
            return SaleInvoiceDto;
        }

        public async Task<SaleInvoiceDto> DeleteSaleInvoice(SaleInvoiceEntity saleInvoice)
        {
            SaleInvoiceEntity SaleInvoiceEntity = await _size.Delete(saleInvoice);
            SaleInvoiceDto SaleInvoiceDto = _mapper.Map<SaleInvoiceEntity, SaleInvoiceDto>(SaleInvoiceEntity);
            return SaleInvoiceDto;
        }
    }
}

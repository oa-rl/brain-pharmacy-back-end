using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

namespace API.Logic
{
    public class SaleInvoiceDetailsLogic
    {
        private readonly IGenericRepository<SaleInvoiceDetailsEntity> _saleInvoiceDetails;
        private readonly IMapper _mapper;


        public SaleInvoiceDetailsLogic(IGenericRepository<SaleInvoiceDetailsEntity> saleInvoiceDetails, IMapper mapper)
        {
            _saleInvoiceDetails = saleInvoiceDetails;
            _mapper = mapper;
        }

        public async Task<Pagination<SaleInvoiceDetailsDto>> GetSaleInvoiceDetailsLogic(SaleInvoiceDetailsSpecParams saleInvoiceDetailsParams)
        {
            var spec = new SaleInvoiceDetailsFilterSpecification(saleInvoiceDetailsParams);
            var salesInvoiceDetails = await _saleInvoiceDetails.ListWithSpecAsync(spec);
            var totalItems = await _saleInvoiceDetails.CountAsync(spec);
            IReadOnlyList<SaleInvoiceDetailsDto> productsToReturn = _mapper.Map<IReadOnlyList<SaleInvoiceDetailsEntity>, IReadOnlyList<SaleInvoiceDetailsDto>>(salesInvoiceDetails);
            return new Pagination<SaleInvoiceDetailsDto>(saleInvoiceDetailsParams.PageIndex, saleInvoiceDetailsParams.PageSize, totalItems, productsToReturn);
        }

        public async Task<SaleInvoiceDetailsDto> GetSaleInvoiceDetailsIdLogic(int id)
        {
            var saleInvoiceDetails = await _saleInvoiceDetails.GetByIdAsync(id);
            SaleInvoiceDetailsDto SaleInvoiceDetailsDto = _mapper.Map<SaleInvoiceDetailsEntity, SaleInvoiceDetailsDto>(saleInvoiceDetails);
            return SaleInvoiceDetailsDto;
        }

        public async Task<ResponseOk<SaleInvoiceDetailsDto>> PostSaleInvoiceDetails(SaleInvoiceDetailsEntity saleInvoiceDetails)
        {

            SaleInvoiceDetailsEntity SaleInvoiceDetailsEntity = await _saleInvoiceDetails.Add(saleInvoiceDetails);
            SaleInvoiceDetailsDto SaleInvoiceDetailsDto = _mapper.Map<SaleInvoiceDetailsEntity, SaleInvoiceDetailsDto>(SaleInvoiceDetailsEntity);
            ResponseOk<SaleInvoiceDetailsDto> response = new(201, true, SaleInvoiceDetailsDto);
            return response;
        }

        public async Task<SaleInvoiceDetailsDto> PutSaleInvoiceDetails(SaleInvoiceDetailsEntity saleInvoiceDetails)
        {
            SaleInvoiceDetailsEntity SaleInvoiceDetailsEntity = await _saleInvoiceDetails.Update(saleInvoiceDetails);
            SaleInvoiceDetailsDto SaleInvoiceDetailsDto = _mapper.Map<SaleInvoiceDetailsEntity, SaleInvoiceDetailsDto>(SaleInvoiceDetailsEntity);
            return SaleInvoiceDetailsDto;
        }

        public async Task<SaleInvoiceDetailsDto> DeleteSaleInvoiceDetails(SaleInvoiceDetailsEntity saleInvoiceDetails)
        {
            SaleInvoiceDetailsEntity SaleInvoiceDetailsEntity = await _saleInvoiceDetails.Delete(saleInvoiceDetails);
            SaleInvoiceDetailsDto SaleInvoiceDetailsDto = _mapper.Map<SaleInvoiceDetailsEntity, SaleInvoiceDetailsDto>(SaleInvoiceDetailsEntity);
            return SaleInvoiceDetailsDto;
        }
    }
}

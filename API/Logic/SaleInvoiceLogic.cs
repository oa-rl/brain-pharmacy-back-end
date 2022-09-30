using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API.Logic
{
    public class SaleInvoiceLogic
    {
        private readonly IGenericRepository<SaleInvoiceEntity> _saleInvoice;
        private readonly IGenericRepository<ProductMovementEntity> _productMovement;
        private readonly IMapper _mapper;


        public SaleInvoiceLogic(IGenericRepository<SaleInvoiceEntity> saleInvoice, IMapper mapper, IGenericRepository<ProductMovementEntity> productMovement)
        {
            _saleInvoice = saleInvoice;
            _mapper = mapper;
            _productMovement = productMovement;
        }

        public async Task<Pagination<SaleInvoiceDto>> GetSaleInvoiceLogic(SaleInvoiceSpecParams saleInvoiceParams)
        {
            var spec = new SaleInvoiceFilterSpecification(saleInvoiceParams);
            var salesInvoice = await _saleInvoice.ListWithSpecAsync(spec);
            var totalItems = await _saleInvoice.CountAsync(spec);
            IReadOnlyList<SaleInvoiceDto> productsToReturn = _mapper.Map<IReadOnlyList<SaleInvoiceEntity>, IReadOnlyList<SaleInvoiceDto>>(salesInvoice);
            return new Pagination<SaleInvoiceDto>(saleInvoiceParams.PageIndex, saleInvoiceParams.PageSize, totalItems, productsToReturn);
        }

        public async Task<SaleInvoiceDto> GetSaleInvoiceIdLogic(SaleInvoiceSpecParams saleInvoiceParams)
        {

            var spec = new SaleInvoiceFilterSpecification(saleInvoiceParams);
            var salesInvoice = await _saleInvoice.GetWithSpecAsync(spec);
            SaleInvoiceDto saleInvoiceDto = _mapper.Map<SaleInvoiceEntity, SaleInvoiceDto>(salesInvoice);
            return saleInvoiceDto;

        }

        public async Task<ResponseOk<SaleInvoiceDto>> PostSaleInvoice(SaleInvoiceEntity saleInvoice, HeadersMap headers)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = new JwtSecurityToken(headers.Authorization);
            List<Claim> claims = new();
            claims.AddRange(token.Claims);
            int userId = Int32.Parse(claims.FirstOrDefault(claimRecord => claimRecord.Type == ClaimTypes.Sid)!.Value);
            saleInvoice.UserId = userId;
           SaleInvoiceEntity SaleInvoiceEntity = await _saleInvoice.Add(saleInvoice);


            foreach (SaleInvoiceDetailsEntity detail in saleInvoice.SaleInvoiceDetails!) {
                ProductMovementEntity movement = new()
                {
                    ProductCombinationId = detail.ProductCombinationId,
                    Quantity = (detail.Amount * -1),
                    OperationTypeId = 3,
                    SaleInvoiceId = SaleInvoiceEntity.Id,
                };
                await _productMovement.Add(movement);
            }
            



            SaleInvoiceDto SaleInvoiceDto = _mapper.Map<SaleInvoiceEntity, SaleInvoiceDto>(SaleInvoiceEntity);
            ResponseOk<SaleInvoiceDto> response = new(201, true, SaleInvoiceDto);
            return response;
        }

        public async Task<SaleInvoiceDto> PutSaleInvoice(SaleInvoiceEntity saleInvoice)
        {
            SaleInvoiceEntity SaleInvoiceEntity = await _saleInvoice.Update(saleInvoice);
            SaleInvoiceDto SaleInvoiceDto = _mapper.Map<SaleInvoiceEntity, SaleInvoiceDto>(SaleInvoiceEntity);
            return SaleInvoiceDto;
        }

        public async Task<SaleInvoiceDto> DeleteSaleInvoice(SaleInvoiceEntity saleInvoice)
        {
            SaleInvoiceEntity SaleInvoiceEntity = await _saleInvoice.Delete(saleInvoice);
            SaleInvoiceDto SaleInvoiceDto = _mapper.Map<SaleInvoiceEntity, SaleInvoiceDto>(SaleInvoiceEntity);
            return SaleInvoiceDto;
        }
    }
}

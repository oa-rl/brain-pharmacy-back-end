using System;
using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

namespace API.Logic
{
	public class SaleForLogic
	{
        private readonly IGenericRepository<SaleForEntity> _saleFor;
        private readonly IMapper _mapper;


        public SaleForLogic(IGenericRepository<SaleForEntity> saleFor, IMapper mapper)
        {
            _saleFor = saleFor;
            _mapper = mapper;
        }

        public async Task<Pagination<SaleForDto>> GetSaleForLogic(SaleForSpecParams saleForParams)
        {
            var spec = new SaleForFilterSpecification(saleForParams);
            var saleFor = await _saleFor.ListWithSpecAsync(spec);
            var totalItems = await _saleFor.CountAsync(spec);
            IReadOnlyList<SaleForDto> productsToReturn = _mapper.Map<IReadOnlyList<SaleForEntity>, IReadOnlyList<SaleForDto>>(saleFor);
            return new Pagination<SaleForDto>(saleForParams.PageIndex, saleForParams.PageSize, totalItems, productsToReturn);
        }
    }
}


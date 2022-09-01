using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

namespace API.Logic
{
    public class CompanyLogic
    {
        private readonly IGenericRepository<CompanyEntity> _company;
        private readonly IMapper _mapper;
        public CompanyLogic(IGenericRepository<CompanyEntity> company, IMapper mapper)
        {
            _company = company;
            _mapper = mapper;
        }
        public async Task<Pagination<CompanyDto>> GetCompanyLogic(CompanySpecParams companyParams)
        {
            var spec = new CompanyFilterSpecification(companyParams);
            var companies = await _company.ListWithSpecAsync(spec);
            var totalItems = await _company.CountAsync(spec);
            IReadOnlyList<CompanyDto> companiesToReturn = _mapper.Map<IReadOnlyList<CompanyEntity>, IReadOnlyList<CompanyDto>>(companies);
            return new Pagination<CompanyDto>(companyParams.PageIndex, companyParams.PageSize, totalItems, companiesToReturn);
        }
    }
}

using API.Dtos;
using API.Helpers;
using AutoMapper;
using core;
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

        public async Task<CompanyDto> GetCompanyIdLogic(int id) {
            var company = await _company.GetByIdAsync(id);
            CompanyDto companyDto = _mapper.Map<CompanyEntity, CompanyDto>(company);
            return companyDto;
        }

        public async Task<ResponseOk<CompanyDto>> PostCompany(CompanyEntity company) {
            
            CompanyEntity companyEntity =  await _company.Add(company);
            CompanyDto companyDto = _mapper.Map<CompanyEntity, CompanyDto>(companyEntity);
            ResponseOk<CompanyDto> response = new(201,true,companyDto);
            return response;
        }

        public async Task<CompanyDto> PutCompany(CompanyEntity company) {
            CompanyEntity companyEntity = await _company.Update(company);
            CompanyDto companyDto = _mapper.Map<CompanyEntity, CompanyDto>(companyEntity);
            return companyDto;
        }

        public async Task<CompanyDto> DeleteCompany(CompanyEntity company) { 
            CompanyEntity companyEntity = await _company.Delete(company);
            CompanyDto companyDto = _mapper.Map<CompanyEntity, CompanyDto>(companyEntity);
            return companyDto;
        }
    }
}

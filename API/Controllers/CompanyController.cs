using API.Dtos;
using API.Helpers;
using API.Logic;
using AutoMapper;
using core;
using Core;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CompanyController : BaseController
    {
        private readonly IGenericRepository<CompanyEntity> _company;
        private readonly IMapper _mapper;
        private readonly CompanyLogic _companyLogic;


        public CompanyController(IGenericRepository<CompanyEntity> company, IMapper mapper)
        {
            _company = company;
            _mapper = mapper;
            _companyLogic = new(_company, _mapper);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CompanyEntity>>> GetCompanies([FromQuery] CompanySpecParams companyParams)
        {
            Pagination<CompanyDto> company = await _companyLogic.GetCompanyLogic(companyParams);
            return Ok(company);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyEntity>> GetCompany(int id) { 
            CompanyDto company = await _companyLogic.GetCompanyIdLogic(id);
            return Ok(company);
        }

        [HttpPost]
        public async Task<ResponseOk<CompanyDto>> PostCompany([FromBody] CompanyEntity company)
        {
            return await _companyLogic.PostCompany(company);
        }

        [HttpPut]
        public async Task<ActionResult<CompanyDto>> PutCompany([FromBody] CompanyEntity company) { 
            CompanyDto update = await _companyLogic.PutCompany(company);
            return Ok(update);
        }

        [HttpDelete]
        public async Task<ActionResult<CompanyDto>> DeleteCompany([FromBody] CompanyEntity company) { 
            CompanyDto delete = await _companyLogic.DeleteCompany(company);
            return Ok(delete);
        }

    }
}

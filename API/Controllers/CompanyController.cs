using API.Dtos;
using API.Helpers;
using API.Logic;
using AutoMapper;
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
        public async Task<ActionResult<IReadOnlyList<CompanyEntity>>> GetCompany([FromQuery] CompanySpecParams companyParams)
        {
            Pagination<CompanyDto> company = await _companyLogic.GetCompanyLogic(companyParams);
            return Ok(company);
        }
    }
}

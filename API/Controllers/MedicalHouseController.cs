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
    public class MedicalHouseController: BaseController
    {

        private readonly IGenericRepository<MedicalHouseEntity> _medicalHosue;
        private readonly IMapper _mapper;
        private readonly MedicalHouseLogic _medicalHosueLogic;

        public MedicalHouseController(IGenericRepository<MedicalHouseEntity> medicalHouse, IMapper mapper)
        {
            _medicalHosue = medicalHouse;
            _mapper = mapper;
            _medicalHosueLogic = new(_medicalHosue, _mapper);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<MedicalHouseDto>>> GetMedicalHouses([FromQuery] MedicalHouseSpecParams productParams)
        {
            Pagination<MedicalHouseDto> medicalHouse = await _medicalHosueLogic.GetMedicalHosueogic(productParams);
            return Ok(medicalHouse);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalHouseDto>> GetMedicalHouse(int id)
        {
            MedicalHouseDto medicalHouse = await _medicalHosueLogic.GetMedicalHouseIdLogic(id);
            return Ok(medicalHouse);
        }

        [HttpPost]
        public async Task<ResponseOk<MedicalHouseDto>> PostMedicalHouse([FromBody] MedicalHouseEntity medicalHouse)
        {
            return await _medicalHosueLogic.PostMedicalHouse(medicalHouse);
        }

        [HttpPut]
        public async Task<ActionResult<MedicalHouseDto>> PutMedicalHouse([FromBody] MedicalHouseEntity medicalHouse)
        {
            MedicalHouseDto update = await _medicalHosueLogic.PutMedicalHosue(medicalHouse);
            return Ok(update);
        }

        [HttpDelete]
        public async Task<ActionResult<MedicalHouseDto>> DeleteMedicalHouse([FromBody] MedicalHouseEntity medicalHouse)
        {
            MedicalHouseDto delete = await _medicalHosueLogic.DeleteMedicalHouse(medicalHouse);
            return Ok(delete);
        }
    }
}

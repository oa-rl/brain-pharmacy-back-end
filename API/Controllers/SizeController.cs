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
    public class SizeController: BaseController
    {
        private readonly IGenericRepository<MedicalHouseEntity> _size;
        private readonly IMapper _mapper;
        private readonly SizeLogic _sizeLogic;
        
        public SizeController(IGenericRepository<MedicalHouseEntity> size, IMapper mapper)
        {
            _size = size;
            _mapper = mapper;
            _sizeLogic = new(_size, _mapper);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<SizeDto>>> GetProducts([FromQuery] SizeSpecParams sizeParams)
        {
            Pagination<SizeDto> product = await _sizeLogic.GetSizeLogic(sizeParams);
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SizeDto>> GetSize(int id)
        {
            SizeDto product = await _sizeLogic.GetSizeIdLogic(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ResponseOk<SizeDto>> PostSize([FromBody] MedicalHouseEntity size)
        {
            return await _sizeLogic.PostSize(size);
        }

        [HttpPut]
        public async Task<ActionResult<SizeDto>> PutSize([FromBody] MedicalHouseEntity size)
        {
            SizeDto update = await _sizeLogic.PutSize(size);
            return Ok(update);
        }

        [HttpDelete]
        public async Task<ActionResult<SizeDto>> DeleteSize([FromBody] MedicalHouseEntity size)
        {
            SizeDto delete = await _sizeLogic.DeleteSize(size);
            return Ok(delete);
        }
    }
}

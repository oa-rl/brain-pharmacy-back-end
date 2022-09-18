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
    public class OperationTypeController: BaseController
    {
        private readonly IGenericRepository<OperationTypeEntity> _operationType;
        private readonly IMapper _mapper;
        private readonly OperationTypeLogic _operationTypeLogic;

        public OperationTypeController(IGenericRepository<OperationTypeEntity> operationType, IMapper mapper)
        {
            _operationType = operationType;
            _mapper = mapper;
            _operationTypeLogic = new(_operationType, _mapper);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OperationTypeDto>>> GetOperationTypes([FromQuery] OperationTypeSpecParams OperationTypeParams)
        {
            Pagination<OperationTypeDto> product = await _operationTypeLogic.GetOperationTypeLogic(OperationTypeParams);
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OperationTypeDto>> GetOperationType(int id)
        {
            OperationTypeDto product = await _operationTypeLogic.GetOperationTypeIdLogic(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ResponseOk<OperationTypeDto>> PostOperationType([FromBody] OperationTypeEntity operationType)
        {
            return await _operationTypeLogic.PostOperationType(operationType);
        }

        [HttpPut]
        public async Task<ActionResult<OperationTypeDto>> PutOperationType([FromBody] OperationTypeEntity operationType)
        {
            OperationTypeDto update = await _operationTypeLogic.PutOperationType(operationType);
            return Ok(update);
        }

        [HttpDelete]
        public async Task<ActionResult<OperationTypeDto>> DeleteOperationType([FromBody] OperationTypeEntity operationType)
        {
            OperationTypeDto delete = await _operationTypeLogic.DeleteOperationType(operationType);
            return Ok(delete);
        }
    }
}

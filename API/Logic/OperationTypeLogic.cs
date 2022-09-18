using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

namespace API.Logic
{
    public class OperationTypeLogic
    {
        private readonly IGenericRepository<OperationTypeEntity> _operationType;
        private readonly IMapper _mapper;


        public OperationTypeLogic(IGenericRepository<OperationTypeEntity> operationType, IMapper mapper)
        {
            _operationType = operationType;
            _mapper = mapper;
        }

        public async Task<Pagination<OperationTypeDto>> GetOperationTypeLogic(OperationTypeSpecParams OperationTypeParams)
        {
            var spec = new OperationTypeFilterSpecification(OperationTypeParams);
            var operationTypes = await _operationType.ListWithSpecAsync(spec);
            var totalItems = await _operationType.CountAsync(spec);
            IReadOnlyList<OperationTypeDto> userToReturn = _mapper.Map<IReadOnlyList<OperationTypeEntity>, IReadOnlyList<OperationTypeDto>>(operationTypes);
            return new Pagination<OperationTypeDto>(OperationTypeParams.PageIndex, OperationTypeParams.PageSize, totalItems, userToReturn);
        }

        public async Task<OperationTypeDto> GetOperationTypeIdLogic(int id)
        {
            var operationType = await _operationType.GetByIdAsync(id);
            OperationTypeDto OperationTypeDto = _mapper.Map<OperationTypeEntity, OperationTypeDto>(operationType);
            return OperationTypeDto;
        }

        public async Task<ResponseOk<OperationTypeDto>> PostOperationType(OperationTypeEntity operationType)
        {

            OperationTypeEntity OperationTypeEntity = await _operationType.Add(operationType);
            OperationTypeDto OperationTypeDto = _mapper.Map<OperationTypeEntity, OperationTypeDto>(OperationTypeEntity);
            ResponseOk<OperationTypeDto> response = new(201, true, OperationTypeDto);
            return response;
        }

        public async Task<OperationTypeDto> PutOperationType(OperationTypeEntity operationType)
        {
            OperationTypeEntity OperationTypeEntity = await _operationType.Update(operationType);
            OperationTypeDto OperationTypeDto = _mapper.Map<OperationTypeEntity, OperationTypeDto>(OperationTypeEntity);
            return OperationTypeDto;
        }

        public async Task<OperationTypeDto> DeleteOperationType(OperationTypeEntity operationType)
        {
            OperationTypeEntity OperationTypeEntity = await _operationType.Delete(operationType);
            OperationTypeDto OperationTypeDto = _mapper.Map<OperationTypeEntity, OperationTypeDto>(OperationTypeEntity);
            return OperationTypeDto;
        }
    }
}

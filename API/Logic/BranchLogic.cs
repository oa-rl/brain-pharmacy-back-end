using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

namespace API.Logic
{
    public class BranchLogic
    {
        private readonly IGenericRepository<BranchEntity> _branch;
        private readonly IMapper _mapper;
        public BranchLogic(IGenericRepository<BranchEntity> branch, IMapper mapper)
        {
            _branch = branch;
            _mapper = mapper;
        }

        public async Task<Pagination<BranchDto>> GetBranchLogic(BranchSpecParams branchParams)
        {
            var spec = new BranchFilterSpecification(branchParams);
            var branches = await _branch.ListWithSpecAsync(spec);
            var totalItems = await _branch.CountAsync(spec);
            IReadOnlyList<BranchDto> branchToReturn = _mapper.Map<IReadOnlyList<BranchEntity>, IReadOnlyList<BranchDto>>(branches);
            return new Pagination<BranchDto>(branchParams.PageIndex, branchParams.PageSize, totalItems, branchToReturn);
        }

        public async Task<BranchDto> GetBranchIdLogic(int id)
        {
            var branch = await _branch.GetByIdAsync(id);
            BranchDto branchDto = _mapper.Map<BranchEntity, BranchDto>(branch);
            return branchDto;
        }

        public async Task<ResponseOk<BranchDto>> PostBranch(BranchEntity company)
        {

            BranchEntity BranchEntity = await _branch.Add(company);
            BranchDto BranchDto = _mapper.Map<BranchEntity, BranchDto>(BranchEntity);
            ResponseOk<BranchDto> response = new(201, true, BranchDto);
            return response;
        }

        public async Task<BranchDto> PutBranch(BranchEntity company)
        {
            BranchEntity BranchEntity = await _branch.Update(company);
            BranchDto BranchDto = _mapper.Map<BranchEntity, BranchDto>(BranchEntity);
            return BranchDto;
        }

        public async Task<BranchDto> DeleteBranch(BranchEntity company)
        {
            BranchEntity BranchEntity = await _branch.Delete(company);
            BranchDto BranchDto = _mapper.Map<BranchEntity, BranchDto>(BranchEntity);
            return BranchDto;
        }
    }
}

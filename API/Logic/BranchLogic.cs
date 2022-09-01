using API.Helpers;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

namespace API.Logic
{
    public class BranchLogic
    {
        private readonly IGenericRepository<BranchEntity> _branch;

        public BranchLogic(IGenericRepository<BranchEntity> branch)
        {
            _branch = branch;
        }

        public async Task<Pagination<BranchEntity>> GetBranchLogic(BranchSpecParams branchParams)
        {
            var spec = new BranchFilterSpecification(branchParams);
            var branches = await _branch.ListWithSpecAsync(spec);
            var totalItems = await _branch.CountAsync(spec);
            return new Pagination<BranchEntity>(branchParams.PageIndex, branchParams.PageSize, totalItems, branches);

        }
    }
}

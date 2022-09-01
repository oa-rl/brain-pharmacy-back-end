using API.Helpers;
using API.Logic;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BranchController : BaseController
    {
        private readonly IGenericRepository<BranchEntity> _branch;
        private readonly BranchLogic _branchLogic;

        public BranchController(IGenericRepository<BranchEntity> branch)
        {
            _branch = branch;
            _branchLogic = new(_branch);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BranchEntity>>> GetBranch([FromQuery] BranchSpecParams branchParams)
        {
            Pagination<BranchEntity> branch = await _branchLogic.GetBranchLogic(branchParams);
            return Ok(branch);
        }
    }
}

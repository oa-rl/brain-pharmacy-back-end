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
    public class BranchController : BaseController
    {
        private readonly IGenericRepository<BranchEntity> _branch;
        private readonly IMapper _mapper;
        private readonly BranchLogic _branchLogic;

        public BranchController(IGenericRepository<BranchEntity> branch, IMapper mapper)
        {
            _branch = branch;
            _mapper = mapper;
            _branchLogic = new(_branch, _mapper);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BranchDto>>> GetBranches([FromQuery] BranchSpecParams branchParams)
        {
            Pagination<BranchDto> branch = await _branchLogic.GetBranchLogic(branchParams);
            return Ok(branch);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BranchEntity>> GetBranch(int id)
        {
            BranchDto branch = await _branchLogic.GetBranchIdLogic(id);
            return Ok(branch);
        }

        [HttpPost]
        public async Task<ResponseOk<BranchDto>> PostBranch([FromBody] BranchEntity branch)
        {
            return await _branchLogic.PostBranch(branch);
        }

        [HttpPut]
        public async Task<ActionResult<BranchDto>> PutBranch([FromBody] BranchEntity branch)
        {
            BranchDto update = await _branchLogic.PutBranch(branch);
            return Ok(update);
        }

        [HttpDelete]
        public async Task<ActionResult<BranchDto>> DeleteBranch([FromBody] BranchEntity branch)
        {
            BranchDto delete = await _branchLogic.DeleteBranch(branch);
            return Ok(delete);
        }
    }
}

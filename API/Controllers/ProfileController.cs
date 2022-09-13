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
    public class ProfileController: BaseController
    {
        private readonly IGenericRepository<ProfileEntity> _profile;
        private readonly IMapper _mapper;
        private readonly ProfileLogic _profileLogic;

        public ProfileController(IGenericRepository<ProfileEntity> profile, IMapper mapper)
        {
            _profile = profile;
            _mapper = mapper;
            _profileLogic = new(_profile, _mapper);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProfileDto>>> GetProfiles([FromQuery] ProfileSpecParams profileParams)
        {
            Pagination<ProfileDto> product = await _profileLogic.GetProfileLogic(profileParams);
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileDto>> GetProfile(int id)
        {
            ProfileDto product = await _profileLogic.GetProfileIdLogic(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ResponseOk<ProfileDto>> PostProfile([FromBody] ProfileEntity profile)
        {
            return await _profileLogic.PostProfile(profile);
        }

        [HttpPut]
        public async Task<ActionResult<ProfileDto>> PutProfile([FromBody] ProfileEntity profile)
        {
            ProfileDto update = await _profileLogic.PutProfile(profile);
            return Ok(update);
        }

        [HttpDelete]
        public async Task<ActionResult<ProfileDto>> DeleteProfile([FromBody] ProfileEntity profile)
        {
            ProfileDto delete = await _profileLogic.DeleteProfile(profile);
            return Ok(delete);
        }
    }
}

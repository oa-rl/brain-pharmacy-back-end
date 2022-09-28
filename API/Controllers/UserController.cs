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
    public class UserController: BaseController
    {
        private readonly IGenericRepository<UserEntity> _user;
        private readonly IMapper _mapper;
        private readonly UserLogic _userLogic;
        private readonly IConfiguration _configuration;

        public UserController(IGenericRepository<UserEntity> user, IMapper mapper, IConfiguration configuration)
        {
            _user = user;
            _mapper = mapper;
            _configuration = configuration;
            _userLogic = new(_user, _mapper, _configuration);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<UserDto>>> GetUsers([FromQuery] UserSpecParams userParams)
        {
            Pagination<UserDto> product = await _userLogic.GetUserLogic(userParams);
            return Ok(product);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            UserDto product = await _userLogic.GetUserIdLogic(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ResponseOk<UserDto>> PostUser([FromBody] UserEntity user)
        {
            return await _userLogic.PostUser(user);
        }


        [HttpPost("login")]
        public async Task<ResponseOk<string>> Login([FromBody] LoginEntity login)
        {
            return await _userLogic.Login(login);
        }

        [HttpPut]
        public async Task<ActionResult<UserDto>> PutUser([FromBody] UserEntity user)
        {
            UserDto update = await _userLogic.PutUser(user);
            return Ok(update);
        }

        [HttpDelete]
        public async Task<ActionResult<UserDto>> DeleteUser([FromBody] UserEntity user)
        {
            UserDto delete = await _userLogic.DeleteUser(user);
            return Ok(delete);
        }
    }
}

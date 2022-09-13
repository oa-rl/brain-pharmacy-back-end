using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

namespace API.Logic
{
    public class UserLogic
    {
        private readonly IGenericRepository<UserEntity> _user;
        private readonly IMapper _mapper;


        public UserLogic(IGenericRepository<UserEntity> user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }

        public async Task<Pagination<UserDto>> GetUserLogic(UserSpecParams UserParams)
        {
            var spec = new UserFilterSpecification(UserParams);
            var products = await _user.ListWithSpecAsync(spec);
            var totalItems = await _user.CountAsync(spec);
            IReadOnlyList<UserDto> userToReturn = _mapper.Map<IReadOnlyList<UserEntity>, IReadOnlyList<UserDto>>(products);
            return new Pagination<UserDto>(UserParams.PageIndex, UserParams.PageSize, totalItems, userToReturn);
        }

        public async Task<UserDto> GetUserIdLogic(int id)
        {
            var user = await _user.GetByIdAsync(id);
            UserDto UserDto = _mapper.Map<UserEntity, UserDto>(user);
            return UserDto;
        }

        public async Task<ResponseOk<UserDto>> PostUser(UserEntity user)
        {

            UserEntity UserEntity = await _user.Add(user);
            UserDto UserDto = _mapper.Map<UserEntity, UserDto>(UserEntity);
            ResponseOk<UserDto> response = new(201, true, UserDto);
            return response;
        }

        public async Task<UserDto> PutUser(UserEntity user)
        {
            UserEntity UserEntity = await _user.Update(user);
            UserDto UserDto = _mapper.Map<UserEntity, UserDto>(UserEntity);
            return UserDto;
        }

        public async Task<UserDto> DeleteUser(UserEntity user)
        {
            UserEntity UserEntity = await _user.Delete(user);
            UserDto UserDto = _mapper.Map<UserEntity, UserDto>(UserEntity);
            return UserDto;
        }

    }
}

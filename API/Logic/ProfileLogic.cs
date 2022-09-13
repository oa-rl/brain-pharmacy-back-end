using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

namespace API.Logic
{
    public class ProfileLogic
    {
        private readonly IGenericRepository<ProfileEntity> _profile;
        private readonly IMapper _mapper;


        public ProfileLogic(IGenericRepository<ProfileEntity> profile, IMapper mapper)
        {
            _profile = profile;
            _mapper = mapper;
        }

        public async Task<Pagination<ProfileDto>> GetProfileLogic(ProfileSpecParams ProfileParams)
        {
            var spec = new ProfileFilterSpecification(ProfileParams);
            var profile = await _profile.ListWithSpecAsync(spec);
            var totalItems = await _profile.CountAsync(spec);
            IReadOnlyList<ProfileDto> userToReturn = _mapper.Map<IReadOnlyList<ProfileEntity>, IReadOnlyList<ProfileDto>>(profile);
            return new Pagination<ProfileDto>(ProfileParams.PageIndex, ProfileParams.PageSize, totalItems, userToReturn);
        }

        public async Task<ProfileDto> GetProfileIdLogic(int id)
        {
            var profile = await _profile.GetByIdAsync(id);
            ProfileDto ProfileDto = _mapper.Map<ProfileEntity, ProfileDto>(profile);
            return ProfileDto;
        }

        public async Task<ResponseOk<ProfileDto>> PostProfile(ProfileEntity profile)
        {

            ProfileEntity ProfileEntity = await _profile.Add(profile);
            ProfileDto ProfileDto = _mapper.Map<ProfileEntity, ProfileDto>(ProfileEntity);
            ResponseOk<ProfileDto> response = new(201, true, ProfileDto);
            return response;
        }

        public async Task<ProfileDto> PutProfile(ProfileEntity profile)
        {
            ProfileEntity ProfileEntity = await _profile.Update(profile);
            ProfileDto ProfileDto = _mapper.Map<ProfileEntity, ProfileDto>(ProfileEntity);
            return ProfileDto;
        }

        public async Task<ProfileDto> DeleteProfile(ProfileEntity profile)
        {
            ProfileEntity ProfileEntity = await _profile.Delete(profile);
            ProfileDto ProfileDto = _mapper.Map<ProfileEntity, ProfileDto>(ProfileEntity);
            return ProfileDto;
        }

    }
}

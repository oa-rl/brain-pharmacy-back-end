using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace API.Logic
{
    public class UserLogic
    {
        private readonly IGenericRepository<UserEntity> _user;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;


        public UserLogic(IGenericRepository<UserEntity> user, IMapper mapper, IConfiguration configuration)
        {
            _user = user;
            _mapper = mapper;
            _configuration = configuration;
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
            byte[] passwordHash;
            byte[] passwordSalt;
            CreatePasswordHash(user.Password, out  passwordHash, out passwordSalt);
            user.Password = "=>";
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
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

        public async Task<ResponseOk<string>> Login(LoginEntity login)
        {
            UserSpecParams userParams = new() { Search = login.Email };
            var spec = new UserFilterSpecification(userParams);
            UserEntity user = await _user.GetWithSpecAsync(spec);
            if (user.Id > 0 && VerifyPasswordHash(login.Password, user.PasswordHash!, user.PasswordSalt!))
            {
                string token = CreateToken(user);
                ResponseOk<string> response = new(200, true, token);
                return response;
            }
            else
            {
                throw new Exception("Error en usuario ó  contraseña");
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }


        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(UserEntity user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.ProfileId.ToString()),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }


      
    }
}

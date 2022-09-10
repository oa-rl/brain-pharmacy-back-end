using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

namespace API.Logic
{
    public class MedicalHouseLogic
    {
        private readonly IGenericRepository<MedicalHouseEntity> _medicalHouse;
        private readonly IMapper _mapper;


        public MedicalHouseLogic(IGenericRepository<MedicalHouseEntity> medicalHouse, IMapper mapper)
        {
            _medicalHouse = medicalHouse;
            _mapper = mapper;
        }

        public async Task<Pagination<MedicalHouseDto>> GetMedicalHosueogic(MedicalHouseSpecParams medicalHouseParams)
        {
            var spec = new MedicalHouseFilterSpecification(medicalHouseParams);
            var medicalHouses = await _medicalHouse.ListWithSpecAsync(spec);
            var totalItems = await _medicalHouse.CountAsync(spec);
            IReadOnlyList<MedicalHouseDto> medicalHousesToReturn = _mapper.Map<IReadOnlyList<MedicalHouseEntity>, IReadOnlyList<MedicalHouseDto>>(medicalHouses);
            return new Pagination<MedicalHouseDto>(medicalHouseParams.PageIndex, medicalHouseParams.PageSize, totalItems, medicalHousesToReturn);
        }

        public async Task<MedicalHouseDto> GetMedicalHouseIdLogic(int id)
        {
            var medicalHouse = await _medicalHouse.GetByIdAsync(id);
            MedicalHouseDto MedicalHouseDto = _mapper.Map<MedicalHouseEntity, MedicalHouseDto>(medicalHouse);
            return MedicalHouseDto;
        }

        public async Task<ResponseOk<MedicalHouseDto>> PostMedicalHouse(MedicalHouseEntity medicalHouse)
        {

            MedicalHouseEntity MedicalHouseEntity = await _medicalHouse.Add(medicalHouse);
            MedicalHouseDto MedicalHouseDto = _mapper.Map<MedicalHouseEntity, MedicalHouseDto>(MedicalHouseEntity);
            ResponseOk<MedicalHouseDto> response = new(201, true, MedicalHouseDto);
            return response;
        }

        public async Task<MedicalHouseDto> PutMedicalHosue(MedicalHouseEntity medicalHouse)
        {
            MedicalHouseEntity MedicalHouseEntity = await _medicalHouse.Update(medicalHouse);
            MedicalHouseDto MedicalHouseDto = _mapper.Map<MedicalHouseEntity, MedicalHouseDto>(MedicalHouseEntity);
            return MedicalHouseDto;
        }

        public async Task<MedicalHouseDto> DeleteMedicalHouse(MedicalHouseEntity medicalHouse)
        {
            MedicalHouseEntity MedicalHouseEntity = await _medicalHouse.Delete(medicalHouse);
            MedicalHouseDto MedicalHouseDto = _mapper.Map<MedicalHouseEntity, MedicalHouseDto>(MedicalHouseEntity);
            return MedicalHouseDto;
        }
    }
}

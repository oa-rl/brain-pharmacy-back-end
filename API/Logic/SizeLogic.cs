using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

namespace API.Logic
{
    public class SizeLogic
    {
        private readonly IGenericRepository<MedicalHouseEntity> _size;
        private readonly IMapper _mapper;


        public SizeLogic(IGenericRepository<MedicalHouseEntity> product, IMapper mapper)
        {
            _size = product;
            _mapper = mapper;
        }

        public async Task<Pagination<SizeDto>> GetSizeLogic(SizeSpecParams sizeParams)
        {
            var spec = new SizeFilterSpecification(sizeParams);
            var products = await _size.ListWithSpecAsync(spec);
            var totalItems = await _size.CountAsync(spec);
            IReadOnlyList<SizeDto> productsToReturn = _mapper.Map<IReadOnlyList<MedicalHouseEntity>, IReadOnlyList<SizeDto>>(products);
            return new Pagination<SizeDto>(sizeParams.PageIndex, sizeParams.PageSize, totalItems, productsToReturn);
        }

        public async Task<SizeDto> GetSizeIdLogic(int id)
        {
            var size = await _size.GetByIdAsync(id);
            SizeDto SizeDto = _mapper.Map<MedicalHouseEntity, SizeDto>(size);
            return SizeDto;
        }

        public async Task<ResponseOk<SizeDto>> PostSize(MedicalHouseEntity size)
        {

            MedicalHouseEntity SizeEntity = await _size.Add(size);
            SizeDto SizeDto = _mapper.Map<MedicalHouseEntity, SizeDto>(SizeEntity);
            ResponseOk<SizeDto> response = new(201, true, SizeDto);
            return response;
        }

        public async Task<SizeDto> PutSize(MedicalHouseEntity size)
        {
            MedicalHouseEntity SizeEntity = await _size.Update(size);
            SizeDto SizeDto = _mapper.Map<MedicalHouseEntity, SizeDto>(SizeEntity);
            return SizeDto;
        }

        public async Task<SizeDto> DeleteSize(MedicalHouseEntity size)
        {
            MedicalHouseEntity SizeEntity = await _size.Delete(size);
            SizeDto SizeDto = _mapper.Map<MedicalHouseEntity, SizeDto>(SizeEntity);
            return SizeDto;
        }

    }
}

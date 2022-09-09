using API.Dtos;
using API.Helpers;
using AutoMapper;
using core;
using core.Entities;
using core.Specifications;
using Core.Interfaces;

namespace API.Logic
{
    public class SizeLogic
    {
        private readonly IGenericRepository<SizeEntity> _size;
        private readonly IMapper _mapper;


        public SizeLogic(IGenericRepository<SizeEntity> product, IMapper mapper)
        {
            _size = product;
            _mapper = mapper;
        }

        public async Task<Pagination<SizeDto>> GetSizeLogic(SizeSpecParams sizeParams)
        {
            var spec = new SizeFilterSpecification(sizeParams);
            var products = await _size.ListWithSpecAsync(spec);
            var totalItems = await _size.CountAsync(spec);
            IReadOnlyList<SizeDto> productsToReturn = _mapper.Map<IReadOnlyList<SizeEntity>, IReadOnlyList<SizeDto>>(products);
            return new Pagination<SizeDto>(sizeParams.PageIndex, sizeParams.PageSize, totalItems, productsToReturn);
        }

        public async Task<SizeDto> GetSizeIdLogic(int id)
        {
            var size = await _size.GetByIdAsync(id);
            SizeDto SizeDto = _mapper.Map<SizeEntity, SizeDto>(size);
            return SizeDto;
        }

        public async Task<ResponseOk<SizeDto>> PostSize(SizeEntity size)
        {

            SizeEntity SizeEntity = await _size.Add(size);
            SizeDto SizeDto = _mapper.Map<SizeEntity, SizeDto>(SizeEntity);
            ResponseOk<SizeDto> response = new(201, true, SizeDto);
            return response;
        }

        public async Task<SizeDto> PutSize(SizeEntity size)
        {
            SizeEntity SizeEntity = await _size.Update(size);
            SizeDto SizeDto = _mapper.Map<SizeEntity, SizeDto>(SizeEntity);
            return SizeDto;
        }

        public async Task<SizeDto> DeleteSize(SizeEntity size)
        {
            SizeEntity SizeEntity = await _size.Delete(size);
            SizeDto SizeDto = _mapper.Map<SizeEntity, SizeDto>(SizeEntity);
            return SizeDto;
        }

    }
}

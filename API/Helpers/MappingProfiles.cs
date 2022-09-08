using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CompanyEntity, CompanyDto>();
            CreateMap<BranchEntity, BranchDto>();
            CreateMap<ProductEntity, ProductDto>();
        }
    }
}

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
            CreateMap<SizeEntity, SizeDto>();
            CreateMap<MedicalHouseEntity, MedicalHouseDto>();
            CreateMap<SaleForEntity, SaleForDto>();
            CreateMap<CustomerEntity, CustomerDto>();
            CreateMap<UserEntity, UserDto>();
            CreateMap<ProfileEntity, ProfileDto>();
            CreateMap<OperationTypeEntity, OperationTypeDto>();
            CreateMap<ProductMovementEntity, ProductMovementDto>();
            CreateMap<ProductCombinationEntity, ProductCombinationDto>();
            CreateMap<SaleInvoiceEntity, SaleInvoiceDto>();
            CreateMap<SaleInvoiceDetailsEntity, SaleInvoiceDetailsDto>();

        }
    }
}

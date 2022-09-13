using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;

namespace API.Logic
{
    public class CustomerLogic
    {
        private readonly IGenericRepository<CustomerEntity> _customer;
        private readonly IMapper _mapper;


        public CustomerLogic(IGenericRepository<CustomerEntity> customer, IMapper mapper)
        {
            _customer = customer;
            _mapper = mapper;
        }

        public async Task<Pagination<CustomerDto>> GetCustomerLogic(CustomerSpecParams customerParams)
        {
            var spec = new CustomerFilterSpecification(customerParams);
            var customers = await _customer.ListWithSpecAsync(spec);
            var totalItems = await _customer.CountAsync(spec);
            IReadOnlyList<CustomerDto> customersToReturn = _mapper.Map<IReadOnlyList<CustomerEntity>, IReadOnlyList<CustomerDto>>(customers);
            return new Pagination<CustomerDto>(customerParams.PageIndex, customerParams.PageSize, totalItems, customersToReturn);
        }

        public async Task<CustomerDto> GetCustomerIdLogic(int id)
        {
            var customer = await _customer.GetByIdAsync(id);
            CustomerDto CustomerDto = _mapper.Map<CustomerEntity, CustomerDto>(customer);
            return CustomerDto;
        }

        public async Task<ResponseOk<CustomerDto>> PostCustomer(CustomerEntity size)
        {

            CustomerEntity CustomerEntity = await _customer.Add(size);
            CustomerDto CustomerDto = _mapper.Map<CustomerEntity, CustomerDto>(CustomerEntity);
            ResponseOk<CustomerDto> response = new(201, true, CustomerDto);
            return response;
        }

        public async Task<CustomerDto> PutCustomer(CustomerEntity size)
        {
            CustomerEntity CustomerEntity = await _customer.Update(size);
            CustomerDto CustomerDto = _mapper.Map<CustomerEntity, CustomerDto>(CustomerEntity);
            return CustomerDto;
        }

        public async Task<CustomerDto> DeleteCustomer(CustomerEntity size)
        {
            CustomerEntity CustomerEntity = await _customer.Delete(size);
            CustomerDto CustomerDto = _mapper.Map<CustomerEntity, CustomerDto>(CustomerEntity);
            return CustomerDto;
        }

    }
}

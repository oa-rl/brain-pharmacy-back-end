using System;
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
	public class CustomerController : BaseController
    {
        private readonly IGenericRepository<CustomerEntity> _customer;
        private readonly IMapper _mapper;
        private readonly CustomerLogic _customerLogic;

        public CustomerController(IGenericRepository<CustomerEntity> size, IMapper mapper)
        {
            _customer = size;
            _mapper = mapper;
            _customerLogic = new(_customer, _mapper);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CustomerDto>>> GetCustomers([FromQuery] CustomerSpecParams customerParams)
        {
            Pagination<CustomerDto> customer = await _customerLogic.GetCustomerLogic(customerParams);
            return Ok(customer);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(int id)
        {
            CustomerDto customer = await _customerLogic.GetCustomerIdLogic(id);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ResponseOk<CustomerDto>> PostCustomer([FromBody] CustomerEntity size)
        {
            return await _customerLogic.PostCustomer(size);
        }

        [HttpPut]
        public async Task<ActionResult<CustomerDto>> PutCustomer([FromBody] CustomerEntity size)
        {
            CustomerDto update = await _customerLogic.PutCustomer(size);
            return Ok(update);
        }

        [HttpDelete]
        public async Task<ActionResult<CustomerDto>> DeleteCustomer([FromBody] CustomerEntity size)
        {
            CustomerDto delete = await _customerLogic.DeleteCustomer(size);
            return Ok(delete);
        }
    }
}


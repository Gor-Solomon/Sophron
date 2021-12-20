using AutoMapper;
using Sophron.Domain;
using Sophron.Dto;
using Sophron.Infrastructure.Repositories;

namespace Sophron.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public async Task<CustomerDto> CreateCustomer(CustomerDto customerDto)
        {
            //validate the dto bffore creating
            var customer =  _mapper.Map<Customer>(customerDto);
            _customerRepository.Add(customer);
            var rowsChanged = await _customerRepository.SaveChangesAsync();

            if (rowsChanged != 1)
            {
                throw new Exception("Error when creating cusotmer in db.");
            }

            var createdCustomerDto = _mapper.Map<CustomerDto>(customer);

            return createdCustomerDto;
        }
    }
}
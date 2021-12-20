using Sophron.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophron.Services
{
    public interface ICustomerService
    {
        Task<Sophron.Dto.CustomerDto> CreateCustomer(Sophron.Dto.CustomerDto customerDto);
        Task<CustomerDto> CreateMachine(Guid customerId, MachineDto machineDto);
    }
}

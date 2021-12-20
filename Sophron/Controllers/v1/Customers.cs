using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sophron.Dto;
using Sophron.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sophron.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class Customers : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMachineService _machineService;
        private readonly ILogger _logger;

        public Customers(ICustomerService customerService, IMachineService machineService, ILogger logger)
        {
            _customerService = customerService;
            _machineService = machineService;
            _logger = logger;
        }

        // POST api/<Customers>
        /// <summary>
        /// this is the method th
        /// </summary>
        /// <param name="customerDto"></param>
        /// <returns></returns>
        [HttpPost()]
        [Authorize(Policy = PolicyConstants.CustomerPolicy)]
        [ProducesResponseType(typeof(CustomerDto), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] CustomerDto customerDto)
        {
            IActionResult actionResult;

            try
            {
                CustomerDto createdCutomer = await _customerService.CreateCustomer(customerDto);
                actionResult = CreatedAtAction(nameof(Post), RouteData.Values["controller"].ToString(), new { id = createdCutomer.Id }, customerDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                actionResult = BadRequest(ex.Message);
            }


            return actionResult;
        }

        [HttpPost("{id}/machines")]
        [Authorize(Policy = PolicyConstants.MachinePolicy)]
        [ProducesResponseType(typeof(MachineDto), 200)]
        public async Task<IActionResult> Machines([FromQuery] Guid customerId, [FromBody] MachineDto machineDto)
        {
            IActionResult actionResult;

            try
            {
                CustomerDto createdMachine = await _customerService.CreateMachine(customerId, machineDto);
                actionResult = CreatedAtAction(nameof(Post), RouteData.Values["controller"].ToString(), new { id = createdMachine.Id }, createdMachine);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                actionResult = BadRequest(ex.Message);
            }


            return actionResult;
        }
    }
}

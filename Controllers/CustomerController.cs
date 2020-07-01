using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleApp.Models;
using SampleApp.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public object GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        public CustomerController()
        {
        }

        [HttpGet("GetAllCustomers")]
        public async Task<List<Customer>> GetAllCustomers(object p)
        {
            try
            {
                return await _customerService.GetAllCustomers();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        [HttpPost("AddNewCustomer")]
        public async Task<int?> AddNewCustomer(Customer customer)
        {
            try
            {
                return await _customerService.AddCustomer(customer);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        [HttpPost("DeleteAllCustomers")]
        public async Task DeleteAllCustomers()
        {
            try
            {
                await _customerService.DeleteAllCustomers();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        [HttpPost("DeleteCustomer")]
        public async Task DeleteCustomer(int id)
        {
            try
            {
                await _customerService.DeleteCustomer(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}

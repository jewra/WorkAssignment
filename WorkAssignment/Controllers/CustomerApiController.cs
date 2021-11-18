using System;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using WorkAssignment.Services;

namespace WorkAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerApiController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerApiController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/<ApiController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var customers = _customerService.GetAll();
                return Ok(customers);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                Log.Error(e.InnerException?.Message);
                throw;
            }
        }

        // GET api/<ApiController>/5
        [HttpGet("{contactNumber}")]
        public IActionResult Get(string contactNumber)
        {
            try
            {
                var customer = _customerService.GetByContactNumber(contactNumber);
                return Ok(customer);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                Log.Error(e.InnerException?.Message);
                throw;
            }
        }
    }
}
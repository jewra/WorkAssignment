using System;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using WorkAssignment.Services;

namespace WorkAssignment.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            try
            {
             
                var customers = _customerService.GetAll();
                return View(customers);
            }
            catch (Exception e)
            { 
                Log.Error(e.Message);
                Log.Error(e.InnerException?.Message);
                throw;
            }
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(string contactNumber)
        {
            try
            {
                var customer = _customerService.GetByContactNumber(contactNumber);
                return View(customer);
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
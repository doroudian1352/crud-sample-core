using Mc2.CrudTest.Common;
using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{

    
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger,ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;

        }

        [HttpGet]
        public List<CustomerDto> Get()
        {
            List <CustomerDto> response = _customerService.GetCustomers2();
            return response;
        }

        [HttpPost]
        public ResultDto<long> Add(CustomerDto customerDto)
        {
            ResultDto<long> response = _customerService.AddToCustomer(customerDto);
            return response;
        }

        [HttpDelete("{Id}")]
        public ResultDto Delete(long Id)
        {
            ResultDto response = _customerService.RemoveFromCustomer(Id);
            return response;
        }



    }
}

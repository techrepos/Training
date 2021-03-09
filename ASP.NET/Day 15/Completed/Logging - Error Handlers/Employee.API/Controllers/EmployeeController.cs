using Employee.Infrastructure.Entities;
using Employee.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;


namespace Employee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _empRepo;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(IEmployeeRepository EmpRepo, ILogger<EmployeeController> logger)
        {
            _empRepo = EmpRepo;
            _logger = logger;

        }

        [HttpGet]

        
        public ActionResult<List<EmployeeEntity>> Get()
        {
            throw new NotImplementedException();
            _logger.LogInformation(LogEvents.ListItems, "Entered Get method");
            var items = _empRepo.EmployeeList();
            _logger.LogInformation(LogEvents.GetItem, "Exiting Get method");
            return items;
        }

        [HttpGet]
        [Route("{id}")]

      
        public ActionResult<EmployeeEntity> GetEmployee([FromRoute] int Id)
        {
            using (_logger.BeginScope("using block message"))
            {
                _logger.LogInformation(LogEvents.GetItem, "Entered Get method to find {id}", Id);
                var item = _empRepo.GetEmployeeDetails(Id);
                if (item == null || item.Id <= 0)
                    _logger.LogInformation(LogEvents.GetItemNotFound, "Item not found for {id}", Id);
                else
                    _logger.LogInformation(LogEvents.GetItem, "Exiting Get method");
                return item;
            }
        }

        [HttpPost]
      
        public ActionResult<EmployeeEntity> Post(EmployeeEntity Employee)
        {
            var empId = _empRepo.AddEmployee(Employee);
            return CreatedAtAction(nameof(Post), new { id = empId }, _empRepo.GetEmployeeDetails(empId));
        }
    }
}

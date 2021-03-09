using Employee.Infrastructure.Entities;
using Employee.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
            _logger.LogInformation("Entered Get method");
            return _empRepo.EmployeeList();
        }

        [HttpGet]
        [Route("{id}")]

      
        public ActionResult<EmployeeEntity> GetEmployee([FromRoute] int Id)
        {
            return _empRepo.GetEmployeeDetails(Id);
        }

        [HttpPost]
      
        public ActionResult<EmployeeEntity> Post(EmployeeEntity Employee)
        {
            var empId = _empRepo.AddEmployee(Employee);
            return CreatedAtAction(nameof(Post), new { id = empId }, _empRepo.GetEmployeeDetails(empId));
        }
    }
}

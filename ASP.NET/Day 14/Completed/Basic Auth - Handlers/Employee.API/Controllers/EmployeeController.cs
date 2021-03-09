using Employee.Infrastructure.Entities;
using Employee.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace Employee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _empRepo;
        public EmployeeController(IEmployeeRepository EmpRepo)
        {
            _empRepo = EmpRepo;

        }

        [HttpGet]

        
        public ActionResult<List<EmployeeEntity>> Get()
        {
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

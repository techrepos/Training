using Employee.Infrastructure.Entities;
using Employee.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

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

        [HttpPost]

        //[Bind("FirstName,LastName,EmailAddress")]
        public ActionResult<EmployeeEntity> Post(  EmployeeEntity Employee)
        {
            var empId = _empRepo.AddEmployee(Employee);
            return CreatedAtAction(nameof(Post), new { id = empId }, _empRepo.GetEmployeeDetails(empId));
        }
    }
}

using Employee.Infrastructure.Entities;
using Employee.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.Controllers
{
    [Route("api/v{version:apiVersion}/employee")]
    [ApiController]
    [ApiVersion("2.0")]
    [ApiVersion("3.0")]
    public class EmployeeV2Controller : ControllerBase
    {
        private readonly IEmployeeRepository _empRepo;
        public EmployeeV2Controller(IEmployeeRepository EmpRepo)
        {
            _empRepo = EmpRepo;

        }

        [HttpGet]
        public IActionResult Get()
        {
            //throw new NotImplementedException("Exception occured");
            //return _empRepo.EmployeeList();
          return new OkObjectResult( new List<EmployeeEntity> {
                    new EmployeeEntity { Id = 2, Name = "Amal" },
                    new EmployeeEntity { Id = 1, Name = "Dev" }
                    });
        }

        [HttpGet]
        [HttpGet, MapToApiVersion("3.0")]
        public IActionResult GetV3()
        {
            dynamic output = new List<dynamic>();

            dynamic row = new ExpandoObject();
            row.Name = "Amal Dev";
            row.Id = "42";
            output.Add(row);

            row = new ExpandoObject();
            row.Name = "Dev";
            row.Id = "21";
            output.Add(row);
            //throw new NotImplementedException("Exception occured");
            //return _empRepo.EmployeeList();
            return new OkObjectResult(output);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<EmployeeEntity> GetEmployee([FromRoute] int Id)
        {
            //throw new NotImplementedException("Exception occured");
            return _empRepo.GetEmployeeDetails(Id);
        }

        [HttpPost]

       
        public ActionResult<EmployeeEntity> Post(  EmployeeEntity Employee)
        {
            var empId = _empRepo.AddEmployee(Employee);
            return CreatedAtAction(nameof(Post), new { id = empId }, _empRepo.GetEmployeeDetails(empId));
        }
    }
}

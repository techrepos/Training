using Employee.Infrastructure.Entities;
using Employee.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public async Task<ActionResult<List<EmployeeEntity>>> Get([FromBody] EmployeeSearchParams searchParams)
        {
            //throw new NotImplementedException("Exception occured");
            return await _empRepo.EmployeeList(searchParams);
         
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<EmployeeEntity>> GetEmployee([FromRoute] int Id)
        {
            //throw new NotImplementedException("Exception occured");
            return await _empRepo.GetEmployeeDetails(Id);
        }

        [HttpPost]

       
        public async Task<ActionResult<EmployeeEntity>> Post(  EmployeeEntity Employee)
        {
            var empId = await _empRepo.AddEmployee(Employee);
            return CreatedAtAction(nameof(Post), new { id = empId }, _empRepo.GetEmployeeDetails(empId));
        }


        [HttpOptions]
        public IActionResult Options()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(string.Empty);
            response.Content.Headers.Add("Allow", new[] { "GET", "POST", "OPTIONS" });
            response.Content.Headers.ContentType = null;
            return new OkObjectResult(response);
        }
    }
}

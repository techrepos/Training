﻿using Employee.Infrastructure.Entities;
using Employee.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
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
            //throw new NotImplementedException("Exception occured");
            //return _empRepo.EmployeeList();
          return  new List<EmployeeEntity> {
                    new EmployeeEntity { Id = 2, Name = "Amal", Country = "India" },
                    new EmployeeEntity { Id = 1, Name = "Dev", Country = "US" }
                    };
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

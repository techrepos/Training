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
    [Route("api/employee/{employeeId}/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {

        private readonly IEmployeeRepository _empRepo;
        public PaymentsController(IEmployeeRepository EmpRepo)
        {
            _empRepo = EmpRepo;

        }

        [HttpGet]
        public async Task<ActionResult<List<EmployeePayments>>> Get([FromRoute] int employeeId)
        {
            //throw new NotImplementedException("Exception occured");
            return await _empRepo.GetPaymentsByEmployee(employeeId);

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EmployeePayments>> GetPaymentDetail(int employeeId, int Id)
        {
            var retValue = await _empRepo.GetPaymentsByEmployee(employeeId);
            return  retValue.FirstOrDefault(x => x.Id.Equals(Id));
        }
    }
}

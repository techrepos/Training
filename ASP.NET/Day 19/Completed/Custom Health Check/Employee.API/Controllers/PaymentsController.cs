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
        public ActionResult<List<EmployeePayments>> Get(int employeeId)
        {
            //throw new NotImplementedException("Exception occured");
            return _empRepo.GetPaymentsByEmployee(employeeId);
           
        }

        [HttpGet("{id:int}")]
        public ActionResult<EmployeePayments> GetPaymentDetail(int employeeId, int Id)
        {
            return _empRepo.GetPaymentsByEmployee(employeeId).FirstOrDefault(x=>x.Id.Equals(Id));
        }

        
        [HttpPost]
        public ActionResult<EmployeePayments> Post(int EmployeeId, EmployeePayments Payment)
        {
            var employee = _empRepo.GetEmployeeDetails(EmployeeId);
            Payment.Employee = employee;
            var id= _empRepo.AddEmployeePayment(Payment);

            var payments = _empRepo.GetPaymentsByEmployee(id);
            return CreatedAtAction(nameof(Post), new { id = id }, payments);
        }

    }
}

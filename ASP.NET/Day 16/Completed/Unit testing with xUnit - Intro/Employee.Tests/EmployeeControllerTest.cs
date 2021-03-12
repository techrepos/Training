using Employee.API.Controllers;
using Employee.Infrastructure.Entities;
using Employee.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace Employee.Tests
{
    public class EmployeeControllerTest
    {
        private EmployeeController _empController;
        private IEmployeeRepository _empRepo;

        
        public EmployeeControllerTest()
        {
         
            _empRepo = new EmployeeRepositoryFake();
            _empController = new EmployeeController(_empRepo);
        }
        [Fact]
        public void GetEmployeeTest_OkResult()
        {
            var retdata = _empController.Get();

            Assert.IsNotType<OkObjectResult>(retdata.Result);

        }

        [Fact]
        public void GetEmployeeTest_ReturnList()
        {
            var retdata = _empController.Get();

            Assert.IsType<List<EmployeeEntity>>(retdata.Value);

        }

        
    }
}

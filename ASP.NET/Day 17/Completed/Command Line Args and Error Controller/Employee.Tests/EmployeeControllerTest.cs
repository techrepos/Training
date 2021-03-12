using Employee.API.Controllers;
using Employee.Infrastructure.Entities;
using Employee.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
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

            //Arrange
            _empRepo = SetUpFakeRepo();
            _empController = new EmployeeController(_empRepo);
        }

        private IEmployeeRepository SetUpFakeRepo()
        {
            var  _empRepoFake = new Mock<IEmployeeRepository>();
            _empRepoFake.Setup(x => x.GetEmployeeDetails(It.IsAny<int>()))
                .Returns(new EmployeeEntity { Id = 2, Name = "Amal", Country = "India" });

            _empRepoFake.Setup(x => x.EmployeeList())
                .Returns(new List<EmployeeEntity> {
                    new EmployeeEntity { Id = 2, Name = "Amal", Country = "India" },
                    new EmployeeEntity { Id = 1, Name = "Dev", Country = "US" }
                    });

            return _empRepoFake.Object;




        }
        [Fact]
        public void GetEmployeeTest_OkResult()
        {
            //Act
            var retdata = _empController.Get();

            //Assert
            Assert.IsNotType<OkObjectResult>(retdata.Result);

        }

        [Fact]
        public void GetEmployeeTest_ReturnList()
        {
            var retdata = _empController.Get();

            Assert.IsType<List<EmployeeEntity>>(retdata.Value);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(-1)]
        [InlineData(100)]
        public void GetEmployeeDetail_Test(int value)
        {
            var retdata = _empController.GetEmployee(value);

            Assert.IsType<ActionResult<EmployeeEntity>>(retdata);
        }
    }
}

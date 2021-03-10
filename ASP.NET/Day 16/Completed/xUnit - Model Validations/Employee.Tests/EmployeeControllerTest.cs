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
        Mock<IEmployeeRepository> _empRepoFake;

        public EmployeeControllerTest()
        {

            //Arrange
            _empRepo = SetUpFakeRepo();
            _empController = new EmployeeController(_empRepo);
        }

        private IEmployeeRepository SetUpFakeRepo()
        {
              _empRepoFake = new Mock<IEmployeeRepository>();
            _empRepoFake.Setup(x => x.GetEmployeeDetails(It.IsAny<int>()))
                .Returns(new EmployeeEntity { Id = 2, Name = "Amal", Country = "India", PrimaryEmailAddress ="ad@ad.com" });

            _empRepoFake.Setup(x => x.EmployeeList())
                .Returns(new List<EmployeeEntity> {
                    new EmployeeEntity { Id = 2, Name = "Amal", Country = "India" },
                    new EmployeeEntity { Id = 1, Name = "Dev", Country = "US" }
                    });

            _empRepoFake.Setup(x => x.AddEmployee(It.IsAny<EmployeeEntity>()))
        .           Verifiable();

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
        [Fact]
        public void AddEmployeeTest_ModelStateInvalid()
        {
            _empController.ModelState.AddModelError("Name", "Required");
            var employee = new EmployeeEntity { PrimaryEmailAddress = "test@tst.com", Country = "India" };

            var retValue = _empController.Post(employee);

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(retValue);
            Assert.IsType<SerializableError>(badRequestResult.Value);


        }

        [Fact]
        public void AddEmployeeTest_ModelStateValid()
        {
           
            var employee = new EmployeeEntity { Id= 5, PrimaryEmailAddress = "test@tst.com", Name = "Amal",  Country = "India" };
            _empController.ModelState.Clear();
           var retObj = _empController.Post(employee) as CreatedAtActionResult;

            var item = retObj.Value as EmployeeEntity;

           ////verifies the status code returns is correct
           Assert.IsType<CreatedAtActionResult>(retObj);

            Assert.IsType<EmployeeEntity>(item);
           

            //ensure that the method defined in the mock object is called when the test method is executed
            _empRepoFake.Verify();
            //
        }
    }
}

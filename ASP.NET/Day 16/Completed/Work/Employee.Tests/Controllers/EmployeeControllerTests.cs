using Employee.API;
using Employee.Infrastructure.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Employee.Tests.Controllers
{
    public class EmployeeControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public EmployeeControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CanGetEmployees()
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync("/api/employee");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var employees = JsonConvert.DeserializeObject<IEnumerable<EmployeeEntity>>(stringResponse);
            Assert.Contains(employees, p => p.Name == "Amal");
            Assert.Contains(employees, p => p.Name == "Dev");
        }


        [Fact]
        public async Task CanGetEmployeeById()
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync("/api/employee/1");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var employee = JsonConvert.DeserializeObject<EmployeeEntity>(stringResponse);
            Assert.Equal(1, employee.Id);
            Assert.Equal("Amal Dev", employee.Name);
        }
    }
}

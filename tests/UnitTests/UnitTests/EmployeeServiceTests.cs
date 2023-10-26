using NUnit.Framework;
using UPS.EmployeeManager.Services.Implementation;
using UPS.EmployeeManager.Services;
using UPS.EmployeeManager.Domain.Entities;
using UPS.EmployeeManager.Shared.Models;
using Moq;
using AutoMapper;
using UPS.EmployeeManager.Services.Mapping;
using Moq.Protected;

namespace UnitTests
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        private IEmployeeService _employeeService;
        private Mock<IHttpClientService> _httpClientService;
        [SetUp]
        public void Setup()
        {

            ////// Create a mock HttpClientFactory
            //_httpClientService = new Mock<IHttpClientService>(MockBehavior.Loose);
            //_httpClientService.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(new HttpClient());


            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
                httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                            "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage());


            var myProfile = new MappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            var mapper = new Mapper(configuration);

            _employeeService = new EmployeeService(_httpClientService.Object, mapper);

            //_employeeService = new EmployeeService(new MockHttpClientService());

        }
        [Test]
        public async Task GetEmployeesAsync_ReturnsEmployees()
        {
            // Arrange

            // Act
            var employees = await _employeeService.GetAllAsync();

            // Assert
            Assert.IsNotNull(employees);
            Assert.IsTrue(employees.Any());
        }

        [Test]
        public async Task CreateEmployeeAsync_CreatesEmployee()
        {
            // Arrange
            var newEmployee = new EmployeeModel
            {
                Name = "Ola Osborne",
                Email = "johndoe@upsexample.com",
                Gender = "male",
                Status = "active"
            };

            // Act
            var createdEmployee = await _employeeService.CreateAsync(newEmployee);

            // Assert
            Assert.IsNotNull(createdEmployee);
        }

        [Test]
        public async Task UpdateEmployeeAsync_UpdatesEmployee()
        {
            // Arrange
            int employeeId = 5507770; 
            var updatedEmployee = new EmployeeModel
            {
                Name = "Laolu olapegba",
                Email = "updated@example.com",
                Gender = "female",
                Status = "inactive"
            };

            // Act
            var updatedEmployeeResult = await _employeeService.UpdateAsync(employeeId, updatedEmployee);


            // Assert
            Assert.IsNotNull(updatedEmployeeResult);
            Assert.That(updatedEmployeeResult.Name, Is.EqualTo(updatedEmployee.Name));
            Assert.That(updatedEmployeeResult.Email, Is.EqualTo(updatedEmployee.Email));
            Assert.That(updatedEmployeeResult.Gender, Is.EqualTo(updatedEmployee.Gender));
            Assert.That(updatedEmployeeResult.Status, Is.EqualTo(updatedEmployee.Status));
        }

        [Test]
        public async Task DeleteEmployeeAsync_DeletesEmployee()
        {
            // Arrange
            int employeeId = 5507770; 

            // Act
            var result = await _employeeService.DeleteAsync(employeeId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task SearchEmployeesByNameAsync_ReturnsEmployees()
        {
            // Arrange
            string searchName = "john";

            // Act
            var employees = await _employeeService.SearchByNameAsync(searchName);

            // Assert
            Assert.IsNotNull(employees);
            Assert.IsTrue(employees.Any());
        }

        [Test]
        public async Task GetEmployeeByIdAsync_ReturnsEmployee()
        {
            // Arrange
            int employeeId = 5507770;

            // Act
            var employee = await _employeeService.GetByIdAsync(employeeId);

            // Assert
            Assert.IsNotNull(employee);
        }
    }
}
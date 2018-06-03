using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProjectPatricia.Application.Features.Employees;
using ProjectPatricia.Common.Tests.Features;
using ProjectPatricia.Domain.Exceptions;
using ProjectPatricia.Domain.Features.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Application.Tests.Features.Employees
{
    [TestFixture]

    public class EmployeesApplicationTest
    {
        private Mock<IEmployeeRepository> _mockRepository;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IEmployeeRepository>();

        }

        [Test]
        public void EmployeeService_Add_ShouldBeOK()
        {
            Employee employee = ObjectMother.GetEmployee();
            _mockRepository.Setup(m => m.Save(employee)).Returns(new Employee() { Id = 1 });
            EmployeeService service = new EmployeeService(_mockRepository.Object);

            Employee result = service.Save(employee);

            result.Should().NotBeNull();
            result.Id.Should().BeGreaterThan(0);
            _mockRepository.Verify(repository => repository.Save(employee));
        }

        [Test]
        public void EmployeeService_Update_ShouldBeOK()
        {
            Employee employee = ObjectMother.GetEmployee();
            employee.Id = 2;

            _mockRepository.Setup(m => m.Update(employee)).Returns(employee);

            EmployeeService service = new EmployeeService(_mockRepository.Object);


            Employee result = service.Update(employee);

            result.Should().NotBeNull();
            result.Name.Should().Be("Patricia");
            _mockRepository.Verify(repository => repository.Update(employee));
        }

        [Test]
        public void EmployeeService_Get_ShouldBeOk()
        {

            Employee employee = ObjectMother.GetEmployee();
            employee.Id = 3;

            _mockRepository.Setup(m => m.Get(3)).Returns(employee);

            EmployeeService service = new EmployeeService(_mockRepository.Object);
            Employee result = service.Get(3);

            result.Should().NotBeNull();
            _mockRepository.Verify(repository => repository.Get(3));
        }

        [Test]
        public void EmployeeService_GetAll_ShouldBeOk()
        {

            _mockRepository.Setup(m => m.GetAll()).Returns(new List<Employee>());

            EmployeeService service = new EmployeeService(_mockRepository.Object);

            IEnumerable<Employee> result = service.GetAll();

            result.Should().NotBeNull();
            _mockRepository.Verify(repository => repository.GetAll());
        }

        [Test]
        public void EmployeeService_Delete_ShouldBeOk()
        {
            Employee modelo = ObjectMother.GetEmployee();
            modelo.Id = 1;

            _mockRepository.Setup(m => m.Delete(modelo));


            EmployeeService service = new EmployeeService(_mockRepository.Object);

            service.Delete(modelo);

            _mockRepository.Verify(repository => repository.Delete(modelo));
        }


        [Test]
        public void EmployeeService_Add_ShouldBeFail()
        {

            Employee modelo = ObjectMother.GetInvalidNameEmployee();

            EmployeeService service = new EmployeeService(_mockRepository.Object);

            Action comparison = () => service.Save(modelo);

            comparison.Should().Throw<EmployeeEmptyNameException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void EmployeeService_Update_Invalid_Id_ShouldBeFail()
        {

            Employee modelo = ObjectMother.GetEmployee();
            modelo.Id = 0;

            EmployeeService service = new EmployeeService(_mockRepository.Object);

            Action update = () => service.Update(modelo);

            update.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void PostService_Get_Invalid_Id_ShouldBeFail()
        {

            EmployeeService service = new EmployeeService(_mockRepository.Object);
            Employee employee = new Employee()
            {
                Id = 0
            };
            Action comparison = () => service.Update(employee);

            comparison.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }
    }
}

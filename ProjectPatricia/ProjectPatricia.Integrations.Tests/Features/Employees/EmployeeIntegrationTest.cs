using FluentAssertions;
using NUnit.Framework;
using ProjectPatricia.Application.Features.Employees;
using ProjectPatricia.Common.Tests.Common;
using ProjectPatricia.Common.Tests.Features;
using ProjectPatricia.Domain.Exceptions;
using ProjectPatricia.Domain.Features.Employees;
using ProjetoPatricia.Infra.Data.Features.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Integrations.Tests.Features.Employees
{
    [TestFixture]
    public class EmployeeIntegrationTest
    {
        private EmployeeService _service;
        private IEmployeeRepository _repository;


        [SetUp]
        public void Setup()
        {
            BaseSQLTest.SeedDatabase();
            _repository = new EmployeeRepository();
            _service = new EmployeeService(_repository);
        }

        [Test]
        public void EmployeeIntegration_Add_ShouldBeOk()
        {
            Employee employee = _service.Save(ObjectMother.GetEmployee());

            employee.Id.Should().BeGreaterThan(0);

            var last = _service.Get(employee.Id);
            last.Should().NotBeNull();

            var employees = _service.GetAll();
            employees.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void EmployeeIntegration_Add_Nome_ShouldBeFail()
        {
            Employee employee = ObjectMother.GetInvalidNameEmployee();

            Action comparison = () => _service.Save(employee);

            comparison.Should().Throw<EmployeeEmptyNameException>();
        }

        [Test]
        public void EmployeeIntegration_Update_ShouldBeOk()
        {
            Employee model = ObjectMother.GetEmployee();
            model.Id = 1;

            Employee employee = _service.Update(model);

            employee.Should().NotBeNull();
            employee.Id.Should().Be(model.Id);
            employee.Name.Should().Be(model.Name);
        }

        [Test]
        public void EmployeeIntegration_Update_Invalid_Id_ShouldBeFail()
        {
            Employee model = ObjectMother.GetEmployee();

            Action comparison = () => _service.Update(model);

            comparison.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void EmployeeIntegration_Update_Nome_ShouldBeFail()
        {
            Employee model = ObjectMother.GetInvalidNameEmployee();
            model.Id = 1;

            Action comparison = () => _service.Update(model);

            comparison.Should().Throw<EmployeeEmptyNameException>();
        }

        [Test]
        public void EmployeeIntegration_Get_ShouldBeOk()
        {
            Employee post = _service.Get(1);

            post.Should().NotBeNull();

            List<Employee> employees = (List<Employee>)_service.GetAll();
            var found = employees.Find(x => x.Id == post.Id);
            post.Id.Should().Be(found.Id);
        }

        [Test]
        public void EmployeeIntegration_Get_ShouldBeFail()
        {
            Employee employee = _service.Get(3);

            employee.Should().BeNull();
        }

        [Test]
        public void EmployeeIntegration_Get_Invalid_Id_ShouldBeFail()
        {

            Action comparison = () => _service.Get(-1);

            comparison.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void EmployeeIntegration_GetAll_ShouldBeOk()
        {
            List<Employee> employees = _service.GetAll() as List<Employee>;

            employees.Should().NotBeNull();
            employees.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void EmployeeIntegration_Delete_ShouldBeOk()
        {
            Employee employee = ObjectMother.GetEmployee();
            employee.Id = 2;
            
            _service.Delete(employee);

            Employee employeedel = _service.Get(2);
            employeedel.Should().BeNull();

            List<Employee> employees = _service.GetAll() as List<Employee>;
            employees.Count().Should().Be(1);
        }

        [Test]
        public void EmployeeIntegration_Delete_ShouldBeFail()
        {
            Action comparison = () => _service.Delete(ObjectMother.GetEmployee());

            comparison.Should().Throw<IdentifierUndefinedException>();
        }
    }
}

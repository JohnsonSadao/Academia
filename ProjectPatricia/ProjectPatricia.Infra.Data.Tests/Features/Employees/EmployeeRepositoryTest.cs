using FluentAssertions;
using NUnit.Framework;
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

namespace ProjectPatricia.Infra.Data.Tests.Features.Employees
{
    public class EmployeeRepositoryTest
    {
        [TestFixture]
        public class EmployeeInfraTeste
        {
            EmployeeRepository _repository;
            [SetUp]
            public void Initialize()
            {
                _repository = new EmployeeRepository();
                BaseSQLTest.SeedDatabase();
            }

            [Test]
            public void EmployeeRepository_Save_ShouldBeOk()
            {
                Employee employee = ObjectMother.GetEmployee();
                employee.Id = 2;
                _repository.Save(employee);
                var employees = _repository.GetAll();
                employees.Count().Should().BeGreaterThan(0);
            }

            [Test]
            public void EmployeeRepository_Update_ShouldBeOk()
            {
                Employee employee = ObjectMother.GetEmployee();
                employee.Id = 2;
                var employeeEditar = _repository.Update(employee);
                employeeEditar.Name.Should().Be(employee.Name);
            }

            [Test]
            public void EmployeeRepository_Get_ShouldBeOk()
            {
                var employeeGet = _repository.Get(1);
                employeeGet.Name.Should().Be("Pedro");
            }

            [Test]
            public void EmployeeRepository_Delete_ShouldBeOk()
            {
                Employee employee = ObjectMother.GetEmployee();
                employee.Id = 2;

                _repository.Delete(employee);
                Employee deleteObject = _repository.Get(2);

                deleteObject.Should().BeNull();
            }

            [Test]
            public void EmployeeRepository_GetAll_ShouldBeOK()
            {
                var list = _repository.GetAll();
                list.Count().Should().BeGreaterThan(0);
            }

            [Test]
            public void EmployeeRepository_SaveValidate_ShouldBeFail()
            {
                Employee employee = ObjectMother.GetInvalidNameEmployee();
                Action salvar = () => _repository.Save(employee);
                salvar.Should().Throw<EmployeeEmptyNameException>();
            }

            [Test]
            public void EmployeeRepository_Update_ShouldBeFail()
            {
                Employee employee = ObjectMother.GetEmployee();
                employee.Id = 0;
                Action update = () => _repository.Update(employee);
                update.Should().Throw<IdentifierUndefinedException>();
            }

            [Test]
            public void EmployeeRepository_Get_ShouldBeFail()
            {
                Action get = () => _repository.Get(0);
                get.Should().Throw<IdentifierUndefinedException>();
            }

            [Test]
            public void EmployeeRepository_Delete_ShouldBeFail()
            {
                Employee employee = ObjectMother.GetEmployee();
                Action delete = () => _repository.Delete(employee);
                delete.Should().Throw<IdentifierUndefinedException>();
            }

        }
    }
}

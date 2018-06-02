using FluentAssertions;
using NUnit.Framework;
using ProjectPatricia.Common.Tests.Features;
using ProjectPatricia.Domain.Features.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Domain.Test.Features.Employees
{
    [TestFixture]
    public class EmployeeDomainTest
    {
        [Test]
        public void Employee_Validate_ShouldBeOk()
        {
            Employee employee = ObjectMother.GetEmployee();
            Action validate = () => employee.Validate();
            validate.Should().NotThrow<Exception>();
        }

        [Test]
        public void Employee_Validate_Invalid_Name_ShouldBeFail()
        {
            Employee employee = ObjectMother.GetInvalidNameEmployee();
            Action validate = () => employee.Validate();
            validate.Should().Throw<EmployeeEmptyNameException>();
        }

        [Test]
        public void Employee_Validate_Invalid_Branch_ShouldBeFail()
        {
            Employee employee = ObjectMother.GetInvalidBranchEmployee();
            Action validate = () => employee.Validate();
            validate.Should().Throw<EmployeeEmptyBranchException>();
        }

        [Test]
        public void Employee_Validate_Invalid_Position_ShouldBeFail()
        {
            Employee employee = ObjectMother.GetInvalidPositionEmployee();
            Action validate = () => employee.Validate();
            validate.Should().Throw<EmployeeEmptyPositionException>();
        }

    }
}

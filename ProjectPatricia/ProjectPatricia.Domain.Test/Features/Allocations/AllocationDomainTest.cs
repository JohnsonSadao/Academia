using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProjectPatricia.Common.Tests.Features;
using ProjectPatricia.Domain.Features.Allocations;
using ProjectPatricia.Domain.Features.Employees;
using ProjectPatricia.Domain.Features.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Domain.Test.Features.Allocations
{
    [TestFixture]
    public class AllocationDomainTest
    {
        private Mock<Employee> fakeEmployee;
        private Mock<Room> fakeRoom;

        [SetUp]
        public void Initialize()
        {
            fakeEmployee = new Mock<Employee>();
            fakeEmployee.Setup(x => x.Validate());
            fakeRoom = new Mock<Room>();
            fakeRoom.Setup(r => r.Validate());
        }

        [Test]
        public void Allocation_Validate_ShouldBeOK()
        {
            Allocation allocation = ObjectMother.GetAllocation(fakeEmployee.Object, fakeRoom.Object);
            Action validate = () => allocation.Validate();
            validate.Should().NotThrow<Exception>();
        }

        [Test]
        public void Allocation_Validate_Invalid_StartDate_ShouldBeFail()
        {
            Allocation allocation = ObjectMother.GetInvalidPastStartHourAllocation(fakeEmployee.Object, fakeRoom.Object);
            Action validate = () => allocation.Validate();
            validate.Should().Throw<AllocationPastHourInvalid>();
        }

        [Test]
        public void Allocation_Validate_Invalid_EndHour_ShouldBeFail()
        {
            Allocation allocation = ObjectMother.GetInvalidEndHourAllocation(fakeEmployee.Object, fakeRoom.Object);
            Action validate = () => allocation.Validate();
            validate.Should().Throw<AllocationEndHourEarlyThanStartException>();
        }

        [Test]
        public void Allocation_Validate_Invalid_NullEmployee_ShouldBeFail()
        {
            Allocation allocation = ObjectMother.GetAllocation(null, fakeRoom.Object);
            Action validate = () => allocation.Validate();
            validate.Should().Throw<AllocationNullEmployeeException>();
        }

        [Test]
        public void Allocation_Validate_Invalid_NullRoom_ShouldBeFail()
        {
            Allocation allocation = ObjectMother.GetAllocation(fakeEmployee.Object, null);
            Action validate = () => allocation.Validate();
            validate.Should().Throw<AllocationNullRoomException>();
        }
        
        [Test]
        public void Allocation_Validate_Invalid_Room_ShouldBeFail()
        {
            Allocation allocation = ObjectMother.GetAllocation(fakeEmployee.Object, ObjectMother.GetInvalidAccentsRoom());
            Action validate = () => allocation.Validate();
            validate.Should().Throw<RoomInvalidAccentsNumberException>();
        }


        [Test]
        public void Allocation_Validate_Invalid_Employee_ShouldBeOK()
        {
            Allocation allocation = ObjectMother.GetAllocation(ObjectMother.GetInvalidBranchEmployee(), fakeRoom.Object);
            Action validate = () => allocation.Validate();
            validate.Should().Throw<EmployeeEmptyBranchException>();
        }
    }
}

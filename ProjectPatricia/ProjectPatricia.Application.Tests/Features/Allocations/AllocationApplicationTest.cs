using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProjectPatricia.Application.Features.Allocations;
using ProjectPatricia.Common.Tests.Features;
using ProjectPatricia.Domain.Exceptions;
using ProjectPatricia.Domain.Features.Allocations;
using ProjectPatricia.Domain.Features.Employees;
using ProjectPatricia.Domain.Features.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Application.Tests.Features.Allocations
{
    [TestFixture]
    class AllocationApplicationTest
    {
        private Mock<IAllocationRepository> _mockRepository;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IAllocationRepository>();
        }

        [Test]
        public void AllocationService_Add_ShouldBeOK()
        {
            Employee employee = ObjectMother.GetEmployee();
            Room room = ObjectMother.GetRoom();
            employee.Id = 1;
            room.Id = 1;
            Allocation allocation = ObjectMother.GetAllocation(employee, room);
            _mockRepository.Setup(m => m.Save(allocation)).Returns(new Allocation() { Id = 1 });
            AllocationService service = new AllocationService(_mockRepository.Object);

            Allocation result = service.Save(allocation);

            result.Should().NotBeNull();
            result.Id.Should().BeGreaterThan(0);
            _mockRepository.Verify(repository => repository.Save(allocation));
        }
        [Test]
        public void AllocationService_Add_SameHour_ShouldBeFail()
        {
            Employee employee = ObjectMother.GetEmployee();
            Room room = ObjectMother.GetRoom();
            employee.Id = 1;
            room.Id = 1;
            Allocation allocation = ObjectMother.GetAllocation(employee, room);           
            _mockRepository.Setup(m => m.GetAll()).Returns(new List<Allocation> {
                ObjectMother.GetSameHourAllocation(employee, room)
            });
            AllocationService service = new AllocationService(_mockRepository.Object);

            Action addSameHour = () => service.Save(allocation);

            addSameHour.Should().Throw<AllocationSameHourException>();
           
        }

        [Test]
        public void AllocationService_Update_ShouldBeOK()
        {
            Employee employee = ObjectMother.GetEmployee();
            Room room = ObjectMother.GetRoom();
            employee.Id = 1;
            room.Id = 1;
            Allocation allocation = ObjectMother.GetAllocation(employee, room);
            allocation.Id = 2;

            _mockRepository.Setup(m => m.Update(allocation)).Returns(allocation);

            AllocationService service = new AllocationService(_mockRepository.Object);


            Allocation result = service.Update(allocation);

            result.Should().NotBeNull();
            result.Employee.Name.Should().Be("Patricia");
            _mockRepository.Verify(repository => repository.Update(allocation));
        }

        [Test]
        public void AllocationService_Get_ShouldBeOk()
        {
            Employee employee = ObjectMother.GetEmployee();
            Room room = ObjectMother.GetRoom();
            employee.Id = 1;
            room.Id = 1;
            Allocation allocation = ObjectMother.GetAllocation(employee, room);
            allocation.Id = 3;

            _mockRepository.Setup(m => m.Get(3)).Returns(allocation);

            AllocationService service = new AllocationService(_mockRepository.Object);
            Allocation result = service.Get(3);

            result.Should().NotBeNull();
            _mockRepository.Verify(repository => repository.Get(3));
        }

        [Test]
        public void AllocationService_GetAll_ShouldBeOk()
        {
            _mockRepository.Setup(m => m.GetAll()).Returns(new List<Allocation>());

            AllocationService service = new AllocationService(_mockRepository.Object);

            IEnumerable<Allocation> result = service.GetAll();

            result.Should().NotBeNull();
            _mockRepository.Verify(repository => repository.GetAll());
        }

        [Test]
        public void AllocationService_Delete_ShouldBeOk()
        {
            Allocation modelo = ObjectMother.GetAllocation(ObjectMother.GetEmployee(), ObjectMother.GetRoom());
            modelo.Id = 1;

            _mockRepository.Setup(m => m.Delete(modelo));


            AllocationService service = new AllocationService(_mockRepository.Object);

            service.Delete(modelo);

            _mockRepository.Verify(repository => repository.Delete(modelo));
        }


        [Test]
        public void AllocationService_Add_ShouldBeFail()
        {

            Allocation modelo = ObjectMother.GetInvalidEndHourAllocation(ObjectMother.GetEmployee(), ObjectMother.GetRoom());

            AllocationService service = new AllocationService(_mockRepository.Object);

            Action comparison = () => service.Save(modelo);

            comparison.Should().Throw<AllocationEndHourEarlyThanStartException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void AllocationService_Update_Invalid_Id_ShouldBeFail()
        {

            Allocation modelo = ObjectMother.GetAllocation(ObjectMother.GetEmployee(), ObjectMother.GetRoom());
            modelo.Id = 0;

            AllocationService service = new AllocationService(_mockRepository.Object);

            Action update = () => service.Update(modelo);

            update.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void PostService_Get_Invalid_Id_ShouldBeFail()
        {

            AllocationService service = new AllocationService(_mockRepository.Object);
            Allocation allocation = new Allocation()
            {
                Id = 0
            };
            Action comparison = () => service.Update(allocation);

            comparison.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }
    }
}

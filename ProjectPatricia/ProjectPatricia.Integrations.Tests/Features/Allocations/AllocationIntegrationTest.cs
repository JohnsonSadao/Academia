using FluentAssertions;
using NUnit.Framework;
using ProjectPatricia.Application.Features.Allocations;
using ProjectPatricia.Common.Tests.Common;
using ProjectPatricia.Common.Tests.Features;
using ProjectPatricia.Domain.Exceptions;
using ProjectPatricia.Domain.Features.Allocations;
using ProjectPatricia.Domain.Features.Employees;
using ProjectPatricia.Domain.Features.Rooms;
using ProjetoPatricia.Infra.Data.Features.Allocations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Integrations.Tests.Features.Allocations
{
    [TestFixture]
    public class AllocationIntegrationTest
    {
        private AllocationService _service;
        private IAllocationRepository _repository;


        [SetUp]
        public void Setup()
        {
            BaseSQLTest.SeedDatabase();
            _repository = new AllocationRepository();
            _service = new AllocationService(_repository);
        }

        [Test]
        public void AllocationIntegration_Add_ShouldBeOk()
        {
            Allocation allocation = _service.Save(ObjectMother.GetAllocation(ObjectMother.GetEmployee(), ObjectMother.GetRoom()));

            allocation.Id.Should().BeGreaterThan(0);

            var last = _service.Get(allocation.Id);
            last.Should().NotBeNull();

            var allocations = _service.GetAll();
            allocations.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void AllocationIntegration_Add_Nome_ShouldBeFail()
        {
            Allocation allocation = ObjectMother.GetInvalidEndHourAllocation(ObjectMother.GetEmployee(), ObjectMother.GetRoom());

            Action comparison = () => _service.Save(allocation);

            comparison.Should().Throw<AllocationEndHourEarlyThanStartException>();
        }

        [Test]
        public void AllocationIntegration_Update_ShouldBeOk()
        {
            Employee employee = ObjectMother.GetEmployee();
            employee.Id = 1;
            Room room = ObjectMother.GetRoom();
            room.Id = 1;
            Allocation model = ObjectMother.GetAllocation(employee, room);
            model.Id = 1;

            Allocation allocation = _service.Update(model);

            allocation.Should().NotBeNull();
            allocation.Id.Should().Be(model.Id);
            allocation.Employee.Name.Should().Be(model.Employee.Name);
        }

        [Test]
        public void AllocationIntegration_Update_Invalid_Id_ShouldBeFail()
        {
            Allocation model = ObjectMother.GetAllocation(ObjectMother.GetEmployee(), ObjectMother.GetRoom());

            Action comparison = () => _service.Update(model);

            comparison.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void AllocationIntegration_Update_Nome_ShouldBeFail()
        {
            Allocation model = ObjectMother.GetInvalidEndHourAllocation(ObjectMother.GetEmployee(), ObjectMother.GetRoom());
            model.Id = 1;

            Action comparison = () => _service.Update(model);

            comparison.Should().Throw<AllocationEndHourEarlyThanStartException>();
        }

        [Test]
        public void AllocationIntegration_Get_ShouldBeOk()
        {
            Allocation post = _service.Get(1);

            post.Should().NotBeNull();

            List<Allocation> allocations = (List<Allocation>)_service.GetAll();
            var found = allocations.Find(x => x.Id == post.Id);
            post.Id.Should().Be(found.Id);
        }

        [Test]
        public void AllocationIntegration_Get_ShouldBeFail()
        {
            Allocation allocation = _service.Get(3);

            allocation.Should().BeNull();
        }

        [Test]
        public void AllocationIntegration_Get_Invalid_Id_ShouldBeFail()
        {

            Action comparison = () => _service.Get(-1);

            comparison.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void AllocationIntegration_GetAll_ShouldBeOk()
        {
            List<Allocation> allocations = _service.GetAll() as List<Allocation>;

            allocations.Should().NotBeNull();
            allocations.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void AllocationIntegration_Delete_ShouldBeOk()
        {
            Allocation allocation = ObjectMother.GetAllocation(ObjectMother.GetEmployee(), ObjectMother.GetRoom());
            allocation.Id = 2;

            _service.Delete(allocation);

            Allocation allocationdel = _service.Get(2);
            allocationdel.Should().BeNull();

            List<Allocation> allocations = _service.GetAll() as List<Allocation>;
            allocations.Count().Should().Be(1);
        }

        [Test]
        public void AllocationIntegration_Delete_ShouldBeFail()
        {
            Action comparison = () => _service.Delete(ObjectMother.GetAllocation(ObjectMother.GetEmployee(), ObjectMother.GetRoom()));

            comparison.Should().Throw<IdentifierUndefinedException>();
        }
    }
}

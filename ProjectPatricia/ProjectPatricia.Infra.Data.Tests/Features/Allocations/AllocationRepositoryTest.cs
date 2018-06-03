using FluentAssertions;
using NUnit.Framework;
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

namespace ProjectPatricia.Infra.Data.Tests.Features.Allocations
{
    [TestFixture]
    public class AllocationRepositoryTest
    {
        AllocationRepository _repository;
        [SetUp]
        public void Initialize()
        {
            _repository = new AllocationRepository();
            BaseSQLTest.SeedDatabase();
        }

        [Test]
        public void AllocationRepository_Save_ShouldBeOk()
        {
            Allocation allocation = ObjectMother.GetAllocation(ObjectMother.GetEmployee(), ObjectMother.GetRoom());
            allocation.Id = 2;
            _repository.Save(allocation);
            var allocations = _repository.GetAll();
            allocations.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void AllocationRepository_Update_ShouldBeOk()
        {
            Employee employee = ObjectMother.GetEmployee();
            employee.Id = 1;
            Room room = ObjectMother.GetRoom();
            room.Id = 1;
            Allocation allocation = ObjectMother.GetAllocation(employee,room);
            allocation.Id = 1;
            var allocationEditar = _repository.Update(allocation);
            allocationEditar.Employee.Name.Should().Be(allocation.Employee.Name);
        }

        [Test]
        public void AllocationRepository_Get_ShouldBeOk()
        {
            var allocationPego = _repository.Get(1);
            allocationPego.Employee.Name.Should().Be("Pedro");
        }

        [Test]
        public void AllocationRepository_Delete_ShouldBeOk()
        {
            Allocation allocation = ObjectMother.GetAllocation(ObjectMother.GetEmployee(), ObjectMother.GetRoom());
            allocation.Id = 2;

            _repository.Delete(allocation);
            Allocation deleteObject = _repository.Get(2);

            deleteObject.Should().BeNull();
        }

        [Test]
        public void AllocationRepository_GetAll_ShouldBeOK()
        {
            var list = _repository.GetAll();
            list.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void AllocationRepository_SaveValidate_ShouldBeFail()
        {
            Allocation allocation = ObjectMother.GetInvalidEndHourAllocation(ObjectMother.GetEmployee(), ObjectMother.GetRoom());
            Action salvar = () => _repository.Save(allocation);
            salvar.Should().Throw<AllocationEndHourEarlyThanStartException>();
        }

        [Test]
        public void AllocationRepository_Update_ShouldBeFail()
        {
            Allocation allocation = ObjectMother.GetAllocation(ObjectMother.GetEmployee(), ObjectMother.GetRoom());
            allocation.Id = 0;
            Action update = () => _repository.Update(allocation);
            update.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void AllocationRepository_Get_ShouldBeFail()
        {
            Action get = () => _repository.Get(0);
            get.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void AllocationRepository_Delete_ShouldBeFail()
        {
            Allocation allocation = ObjectMother.GetAllocation(ObjectMother.GetEmployee(),ObjectMother.GetRoom());
            Action delete = () => _repository.Delete(allocation);
            delete.Should().Throw<IdentifierUndefinedException>();
        }

        
    }
}

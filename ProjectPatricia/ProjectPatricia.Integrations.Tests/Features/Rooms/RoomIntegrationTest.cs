using FluentAssertions;
using NUnit.Framework;
using ProjectPatricia.Application.Features.Rooms;
using ProjectPatricia.Common.Tests.Common;
using ProjectPatricia.Common.Tests.Features;
using ProjectPatricia.Domain.Exceptions;
using ProjectPatricia.Domain.Features.Rooms;
using ProjetoPatricia.Infra.Data.Features.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Integrations.Tests.Features.Rooms
{
    [TestFixture]
    public class RoomIntegrationTest
    {
        private RoomService _service;
        private IRoomRepository _repository;


        [SetUp]
        public void Setup()
        {
            BaseSQLTest.SeedDatabase();
            _repository = new RoomRepository();
            _service = new RoomService(_repository);
        }

        [Test]
        public void RoomIntegration_Add_ShouldBeOk()
        {
            Room room = _service.Save(ObjectMother.GetRoom());

            room.Id.Should().BeGreaterThan(0);

            var last = _service.Get(room.Id);
            last.Should().NotBeNull();

            var rooms = _service.GetAll();
            rooms.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void RoomIntegration_Add_Nome_ShouldBeFail()
        {
            Room room = ObjectMother.GetInvalidNameRoom();

            Action comparison = () => _service.Save(room);

            comparison.Should().Throw<RoomEmptyNameException>();
        }

        [Test]
        public void RoomIntegration_Update_ShouldBeOk()
        {
            Room model = ObjectMother.GetRoom();
            model.Id = 1;

            Room room = _service.Update(model);

            room.Should().NotBeNull();
            room.Id.Should().Be(model.Id);
            room.Name.Should().Be(model.Name);
        }

        [Test]
        public void RoomIntegration_Update_Invalid_Id_ShouldBeFail()
        {
            Room model = ObjectMother.GetRoom();

            Action comparison = () => _service.Update(model);

            comparison.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void RoomIntegration_Update_Nome_ShouldBeFail()
        {
            Room model = ObjectMother.GetInvalidNameRoom();
            model.Id = 1;

            Action comparison = () => _service.Update(model);

            comparison.Should().Throw<RoomEmptyNameException>();
        }

        [Test]
        public void RoomIntegration_Get_ShouldBeOk()
        {
            Room post = _service.Get(1);

            post.Should().NotBeNull();

            List<Room> rooms = (List<Room>)_service.GetAll();
            var found = rooms.Find(x => x.Id == post.Id);
            post.Id.Should().Be(found.Id);
        }

        [Test]
        public void RoomIntegration_Get_ShouldBeFail()
        {
            Room room = _service.Get(3);

            room.Should().BeNull();
        }

        [Test]
        public void RoomIntegration_Get_Invalid_Id_ShouldBeFail()
        {

            Action comparison = () => _service.Get(-1);

            comparison.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void RoomIntegration_GetAll_ShouldBeOk()
        {
            List<Room> rooms = _service.GetAll() as List<Room>;

            rooms.Should().NotBeNull();
            rooms.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void RoomIntegration_Delete_ShouldBeOk()
        {
            Room room = ObjectMother.GetRoom();
            room.Id = 2;

            _service.Delete(room);

            Room roomdel = _service.Get(2);
            roomdel.Should().BeNull();

            List<Room> rooms = _service.GetAll() as List<Room>;
            rooms.Count().Should().Be(1);
        }

        [Test]
        public void RoomIntegration_Delete_ShouldBeFail()
        {
            Action comparison = () => _service.Delete(ObjectMother.GetRoom());

            comparison.Should().Throw<IdentifierUndefinedException>();
        }
    }
}

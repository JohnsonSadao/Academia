using FluentAssertions;
using NUnit.Framework;
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

namespace ProjectPatricia.Infra.Data.Tests.Features.Rooms
{
    public class RoomRepositoryTest
    {
        [TestFixture]
        public class RoomInfraTeste
        {
            RoomRepository _repository;
            [SetUp]
            public void Initialize()
            {
                _repository = new RoomRepository();
                BaseSQLTest.SeedDatabase();
            }

            [Test]
            public void RoomRepository_Save_ShouldBeOk()
            {
                Room room = ObjectMother.GetRoom();
                room.Id = 2;
                _repository.Save(room);
                var rooms = _repository.GetAll();
                rooms.Count().Should().BeGreaterThan(0);
            }

            [Test]
            public void RoomRepository_Update_ShouldBeOk()
            {
                Room room = ObjectMother.GetRoom();
                room.Id = 2;
                var roomEditar = _repository.Update(room);
                roomEditar.Name.Should().Be(room.Name);
            }

            [Test]
            public void RoomRepository_Get_ShouldBeOk()
            {
                var roomPego = _repository.Get(1);
                roomPego.Name.Should().Be("Sala de Treinamento");
            }

            [Test]
            public void RoomRepository_Delete_ShouldBeOk()
            {
                Room room = ObjectMother.GetRoom();
                room.Id = 2;

                _repository.Delete(room);
                Room deleteObject = _repository.Get(2);

                deleteObject.Should().BeNull();
            }

            [Test]
            public void RoomRepository_GetAll_ShouldBeOK()
            {
                var list = _repository.GetAll();
                list.Count().Should().BeGreaterThan(0);
            }

            [Test]
            public void RoomRepository_SaveValidate_ShouldBeFail()
            {
                Room room = ObjectMother.GetInvalidNameRoom();
                Action salvar = () => _repository.Save(room);
                salvar.Should().Throw<RoomEmptyNameException>();
            }

            [Test]
            public void RoomRepository_Update_ShouldBeFail()
            {
                Room room = ObjectMother.GetRoom();
                room.Id = 0;
                Action update = () => _repository.Update(room);
                update.Should().Throw<IdentifierUndefinedException>();
            }

            [Test]
            public void RoomRepository_Get_ShouldBeFail()
            {
                Action get = () => _repository.Get(0);
                get.Should().Throw<IdentifierUndefinedException>();
            }

            [Test]
            public void RoomRepository_Delete_ShouldBeFail()
            {
                Room room = ObjectMother.GetRoom();
                Action delete = () => _repository.Delete(room);
                delete.Should().Throw<IdentifierUndefinedException>();
            }

        }
    }
}

using FluentAssertions;
using NUnit.Framework;
using ProjectPatricia.Common.Tests.Features;
using ProjectPatricia.Domain.Features.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Domain.Test.Features.Rooms
{
    public class RoomDomainTest
    {
        [Test]
        public void Room_Validate_ShouldBeOk()
        {
            Room room = ObjectMother.GetRoom();
            Action validate = () => room.Validate();
            validate.Should().NotThrow<Exception>();
        }

        [Test]
        public void Room_Validate_Invalid_Name_ShouldBeFail()
        {
            Room room = ObjectMother.GetInvalidNameRoom();
            Action validate = () => room.Validate();
            validate.Should().Throw<RoomEmptyNameException>();
        }


        [Test]
        public void Room_Validate_Invalid_Accents_ShouldBeFail()
        {
            Room room = ObjectMother.GetInvalidAccentsRoom();
            Action validate = () => room.Validate();
            validate.Should().Throw<RoomInvalidAccentsNumberException>();
        }
    }
}

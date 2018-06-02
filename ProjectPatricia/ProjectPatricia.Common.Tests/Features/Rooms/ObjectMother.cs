using ProjectPatricia.Domain.Features.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Common.Tests.Features
{
    public partial class ObjectMother
    {
        public static Room GetRoom()
        {
            return new Room()
            {
                Accents = 3,
                Name = "Sala de reunião"                
            };
        }

        public static Room GetInvalidAccentsRoom()
        {
            return new Room()
            {
                Accents = 0,
                Name = "Sala de reunião"
            };
        }

        public static Room GetInvalidNameRoom()
        {
            return new Room()
            {
                Accents = 3,
                Name = ""
            };
        }

    }
}

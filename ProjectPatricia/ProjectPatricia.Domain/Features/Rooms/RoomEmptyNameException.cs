using ProjectPatricia.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Domain.Features.Rooms
{
    public class RoomEmptyNameException : BusinessException
    {
        public RoomEmptyNameException() : base("O nome não pode ser vazio ou nulo")
        {
        }
    }
}

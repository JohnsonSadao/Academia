using ProjectPatricia.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Domain.Features.Rooms
{
    public class RoomInvalidAccentsNumberException : BusinessException
    {
        public RoomInvalidAccentsNumberException() : base("O número de lugares deve ser maior que zero")
        {
        }
    }
}

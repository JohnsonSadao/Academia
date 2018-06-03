using ProjectPatricia.Domain.Features.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Application.Features.Rooms
{
    public interface IRoomService
    {
        Room Save(Room room);
        Room Update(Room room);
        Room Get(long id);
        IEnumerable<Room> GetAll();
        void Delete(Room room);
    }
}

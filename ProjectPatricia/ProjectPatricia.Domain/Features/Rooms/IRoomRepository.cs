using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Domain.Features.Rooms
{
    public interface IRoomRepository
    {
        Room Save(Room room);
        Room Update(Room room);
        Room Get(long id);
        IEnumerable<Room> GetAll();
        void Delete(Room room);
    }
}

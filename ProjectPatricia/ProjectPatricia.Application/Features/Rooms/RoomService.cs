using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPatricia.Domain.Exceptions;
using ProjectPatricia.Domain.Features.Rooms;

namespace ProjectPatricia.Application.Features.Rooms
{
    public class RoomService : IRoomService
    {
        private IRoomRepository _repository;

        public RoomService(IRoomRepository repository)
        {
            _repository = repository;
        }
        public void Delete(Room room)
        {
            if (room.Id < 1)
                throw new IdentifierUndefinedException();
            _repository.Delete(room);
        }

        public Room Get(long id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();
            return _repository.Get(id);
        }

        public IEnumerable<Room> GetAll()
        {
            return _repository.GetAll();
        }

        public Room Save(Room room)
        {
            room.Validate();
            return _repository.Save(room);
        }

        public Room Update(Room room)
        {
            if (room.Id < 1)
                throw new IdentifierUndefinedException();
            room.Validate();
            return _repository.Update(room);
        }
    }
}

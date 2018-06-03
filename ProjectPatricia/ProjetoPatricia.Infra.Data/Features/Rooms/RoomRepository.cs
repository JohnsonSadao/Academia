using ProjectPatricia.Domain.Exceptions;
using ProjectPatricia.Domain.Features.Rooms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPatricia.Infra.Data.Features.Rooms
{
    public class RoomRepository : IRoomRepository
    {
        public void Delete(Room room)
        {
            if (room.Id < 1)
                throw new IdentifierUndefinedException();
            string sql = "DELETE FROM TBRoom WHERE Id = @Id";
            Db.Delete(sql, new object[]{ "@Id", room.Id });
        }

        public Room Get(long id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();
            string sql = "SELECT * FROM TBRoom WHERE Id = @Id";
            return Db.Get(sql,Make,new object[] { "@Id", id });
        }

        public IEnumerable<Room> GetAll()
        {
            string sql = "SELECT * FROM TBRoom";
            return Db.GetAll(sql,Make);
        }

        public Room Save(Room room)
        {
            room.Validate();
            string sql = "INSERT INTO TBRoom(NameRoom, Accents) VALUES (@Name, @Accents)";
            room.Id = Db.Insert(sql,Take(room,false));
            return room;
        }

        public Room Update(Room room)
        {
            if (room.Id < 1)
                throw new IdentifierUndefinedException();
            string sql = "UPDATE TBRoom SET NameRoom = @Name, Accents = @Accents WHERE Id = @Id";
            Db.Update(sql, Take(room));
            return room;
        }

        /// <summary>
        /// Cria um objeto Customer baseado no DataReader.
        /// </summary>
        private static Func<IDataReader, Room> Make = reader =>
          new Room
          {
              Id = Convert.ToInt64(reader["Id"]),
              Name = reader["NameRoom"].ToString(),
              Accents = Convert.ToInt32(reader["Accents"])

          };


        /// <summary>
        /// Cria a lista de parametros do objeto Post para passar para o comando Sql
        /// </summary>
        /// <param name="post">Post.</param>
        /// <returns>lista de parametros</returns>
        private object[] Take(Room room, bool hasId = true)
        {
            object[] parametros = null;

            if (hasId)
            {
                parametros = new object[]
                {

                "@Id", room.Id,
                "@Name", room.Name,
                "@Accents", room.Accents
                };
            }
            else
            {
                parametros = new object[]
                {
                "@Name", room.Name,
                "@Accents", room.Accents
                };
            }

            return parametros;
        }
    }
}

using ProjectPatricia.Domain.Exceptions;
using ProjectPatricia.Domain.Features.Allocations;
using ProjectPatricia.Domain.Features.Employees;
using ProjectPatricia.Domain.Features.Rooms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPatricia.Infra.Data.Features.Allocations
{
    public class AllocationRepository : IAllocationRepository
    {
        public void Delete(Allocation allocation)
        {
            if (allocation.Id < 1)
                throw new IdentifierUndefinedException();
            string sql = "DELETE FROM TBAllocation WHERE Id = @Id";
            Db.Delete(sql, new object[] { "@Id", allocation.Id });
        }

        public Allocation Get(long id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();
            string sql = @"SELECT A.Id,A.StartHour,A.EndHour,A.EmployeeId,A.RoomId,E.NameEmployee,
                            E.Branch,E.Position,R.NameRoom,R.Accents FROM TBAllocation AS A
                            INNER JOIN TBRoom AS R ON A.RoomId = R.Id
                            INNER JOIN TBEmployee AS E ON A.EmployeeId = E.Id WHERE A.Id = @Id";
            return Db.Get(sql,Make, new object[] { "@Id", id });
        }

        public IEnumerable<Allocation> GetAll()
        {
            string sql = @"SELECT A.Id,A.StartHour,A.EndHour,A.EmployeeId,A.RoomId,E.NameEmployee,
                            E.Branch,E.Position,R.NameRoom,R.Accents FROM TBAllocation AS A
                            INNER JOIN TBRoom AS R ON A.RoomId = R.Id
                            INNER JOIN TBEmployee AS E ON A.EmployeeId = E.Id";
            return Db.GetAll(sql, Make);
        }

        public Allocation Save(Allocation allocation)
        {
            allocation.Validate();
            string sql = "INSERT INTO TBAllocation(StartHour, EndHour, RoomId, EmployeeId) VALUES('2018-05-23T14:25:00', '2018-05-23T15:00:00', 1, 1)";
            allocation.Id = Db.Insert(sql, Take(allocation, false));
            return allocation;
        }

        public Allocation Update(Allocation allocation)
        {
            if (allocation.Id < 1)
                throw new IdentifierUndefinedException();
            string sql = "UPDATE TBAllocation SET StartHour = @StartHour, EndHour = @EndHour, EmployeeId = @EmployeeId, RoomId = @RoomId";
            Db.Update(sql, Take(allocation));
            return allocation;
        }

        /// <summary>
        /// Cria um objeto Customer baseado no DataReader.
        /// </summary>
        private static Func<IDataReader, Allocation> Make = reader =>
          new Allocation
          {
              Id = Convert.ToInt64(reader["Id"]),
              StartHour = Convert.ToDateTime(reader["StartHour"]),
              EndHour = Convert.ToDateTime(reader["EndHour"]),
              Employee = new Employee
              {
                  Id = Convert.ToInt64(reader["EmployeeId"]),
                  Branch = reader["Branch"].ToString(),
                  Name = reader["NameEmployee"].ToString(),
                  Position = reader["Position"].ToString()
              },
              Room = new Room
              {
                  Id = Convert.ToInt64(reader["RoomId"]),
                  Name = reader["NameRoom"].ToString(),
                  Accents = Convert.ToInt32(reader["Accents"])
              }

          };


        /// <summary>
        /// Cria a lista de parametros do objeto Post para passar para o comando Sql
        /// </summary>
        /// <param name="post">Post.</param>
        /// <returns>lista de parametros</returns>
        private object[] Take(Allocation allocation, bool hasId = true)
        {
            object[] parametros = null;

            if (hasId)
            {
                parametros = new object[]
                {

                "@Id", allocation.Id,
                "@StartHour", allocation.StartHour,
                "@EndHour", allocation.EndHour,
                "@EmployeeId", allocation.Employee.Id,
                "@RoomId", allocation.Room.Id
                };
            }
            else
            {
                parametros = new object[]
                {
                "@StartHour", allocation.StartHour,
                "@EndHour", allocation.EndHour,
                "@EmployeeId", allocation.Employee.Id,
                "@RoomId", allocation.Room.Id
                };
            }

            return parametros;
        }
    }
}

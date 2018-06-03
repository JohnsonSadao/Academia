using ProjectPatricia.Domain.Exceptions;
using ProjectPatricia.Domain.Features.Employees;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPatricia.Infra.Data.Features.Employees
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public void Delete(Employee employee)
        {
            if (employee.Id < 1)
                throw new IdentifierUndefinedException();
            string sql = "DELETE FROM TBEmployee WHERE Id = @Id";
            Db.Delete(sql, new object[]{ "@Id", employee.Id });
        }

        public Employee Get(long id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();
            string sql = "SELECT * FROM TBEmployee WHERE Id = @Id";
            return Db.Get(sql, Make, new object[] { "@Id", id });

        }

        public IEnumerable<Employee> GetAll()
        {
            string sql = "SELECT * FROM TBEmployee";
            return Db.GetAll(sql, Make);
        }

        public Employee Save(Employee employee)
        {
            employee.Validate();
            string sql = "INSERT INTO TBEmployee(NameEmployee,Branch,Position) VALUES (@Name, @Branch, @Position)";
            employee.Id = Db.Insert(sql, Take(employee, false));
            return employee;

        }

        public Employee Update(Employee employee)
        {
            if (employee.Id < 1)
                throw new IdentifierUndefinedException();
            string sql = "UPDATE TBEmployee SET NameEmployee = @Name, Branch = @Branch, Position = @Position WHERE Id = @Id";
            Db.Update(sql,Take(employee));
            return employee;
        }

        /// <summary>
        /// Cria um objeto Customer baseado no DataReader.
        /// </summary>
        private static Func<IDataReader, Employee> Make = reader =>
          new Employee
          {
              Id = Convert.ToInt64(reader["Id"]),
              Branch = reader["Branch"].ToString(),
              Name = reader["NameEmployee"].ToString(),
              Position = reader["Position"].ToString()

          };


        /// <summary>
        /// Cria a lista de parametros do objeto Post para passar para o comando Sql
        /// </summary>
        /// <param name="post">Post.</param>
        /// <returns>lista de parametros</returns>
        private object[] Take(Employee employee, bool hasId = true)
        {
            object[] parametros = null;

            if (hasId)
            {
                parametros = new object[]
                {

                "@Id", employee.Id,
                "@Position", employee.Position,
                "@Name", employee.Name,
                "@Branch", employee.Branch
                };
            }
            else
            {
                parametros = new object[]
                {
                "@Position", employee.Position,
                "@Name", employee.Name,
                "@Branch", employee.Branch
                };
            }

            return parametros;
        }
    }
}

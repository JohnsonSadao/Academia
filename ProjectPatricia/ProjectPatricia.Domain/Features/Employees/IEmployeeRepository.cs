using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Domain.Features.Employees
{
    public interface IEmployeeRepository
    {
        Employee Save(Employee employee);
        Employee Update(Employee employee);
        Employee Get(long id);
        IEnumerable<Employee> GetAll();
        void Delete(Employee employee);
    }
}

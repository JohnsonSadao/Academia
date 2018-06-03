using ProjectPatricia.Domain.Features.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Application.Features.Employees
{
    public interface IEmployeeService
    {
        Employee Save(Employee employee);
        Employee Update(Employee employee);
        Employee Get(long id);
        IEnumerable<Employee> GetAll();
        void Delete(Employee employee);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectPatricia.Domain.Exceptions;
using ProjectPatricia.Domain.Features.Employees;

namespace ProjectPatricia.Application.Features.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _repository;
        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public void Delete(Employee employee)
        {
            if (employee.Id < 1)
                throw new IdentifierUndefinedException();
            _repository.Delete(employee);
        }

        public Employee Get(long id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();
            return _repository.Get(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _repository.GetAll();
        }

        public Employee Save(Employee employee)
        {
            employee.Validate();
            return _repository.Save(employee);  
        }

        public Employee Update(Employee employee)
        {
            if (employee.Id < 1)
                throw new IdentifierUndefinedException();
            employee.Validate();
            return _repository.Update(employee);
        }
    }
}

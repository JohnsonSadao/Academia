using ProjectPatricia.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Domain.Features.Employees
{
    public class EmployeeEmptyNameException : BusinessException
    {
        public EmployeeEmptyNameException() : base("O nome do funcionário não pode ser vazio ou nulo")
        {
        }
    }
}

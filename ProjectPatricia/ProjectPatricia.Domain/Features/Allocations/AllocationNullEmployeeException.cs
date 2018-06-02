using ProjectPatricia.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Domain.Features.Allocations
{
    public class AllocationNullEmployeeException : BusinessException
    {
        public AllocationNullEmployeeException() : base("Nenhum Funcionario selecionado")
        {
        }
    }
}

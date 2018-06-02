using ProjectPatricia.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Domain.Features.Allocations
{
    public class AllocationPastHourInvalid : BusinessException
    {
        public AllocationPastHourInvalid() : base("Não é possivel cadastrar um horario antes da data atual")
        {
        }
    }
}

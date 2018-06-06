using ProjectPatricia.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Domain.Features.Allocations
{
    public class AllocationSameHourException : BusinessException
    {
        public AllocationSameHourException() : base("Já existe uma reunião nesse mesmo horário")
        {

        }
    }
}

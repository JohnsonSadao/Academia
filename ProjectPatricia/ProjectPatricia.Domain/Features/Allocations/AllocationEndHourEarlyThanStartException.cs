using ProjectPatricia.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Domain.Features.Allocations
{
    public class AllocationEndHourEarlyThanStartException : BusinessException
    {
        public AllocationEndHourEarlyThanStartException() : base("A hora de inicio deve ser menos que a hora de fim")
        {
        }
    }
}

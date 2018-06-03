using ProjectPatricia.Domain.Features.Allocations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Application.Features.Allocations
{
    public interface IAllocationService
    {
        Allocation Save(Allocation allocation);
        Allocation Update(Allocation allocation);
        Allocation Get(long id);
        IEnumerable<Allocation> GetAll();
        void Delete(Allocation allocation);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Domain.Features.Allocations
{
    public interface IAllocationRepository
    {
        Allocation Save(Allocation allocation);
        Allocation Update(Allocation allocation);
        Allocation Get(long id);
        IEnumerable<Allocation> GetAll();
        void Delete(Allocation allocation);
    }
}

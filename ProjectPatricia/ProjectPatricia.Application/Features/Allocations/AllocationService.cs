using ProjectPatricia.Domain.Features.Allocations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Application.Features.Allocations
{
    public class AllocationService: IAllocationService
    {
        public IAllocationRepository _repository;
        public AllocationService(IAllocationRepository repository)
        {
            repository = _repository;
        }

        public void Delete(Allocation allocation)
        {
            throw new NotImplementedException();
        }

        public Allocation Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Allocation> GetAll()
        {
            throw new NotImplementedException();
        }

        public Allocation Save(Allocation allocation)
        {
            throw new NotImplementedException();
        }

        public Allocation Update(Allocation allocation)
        {
            throw new NotImplementedException();
        }
    }
}

using ProjectPatricia.Domain.Exceptions;
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
            _repository = repository;
        }

        public void Delete(Allocation allocation)
        {
            if (allocation.Id < 1)
                throw new IdentifierUndefinedException();
            _repository.Delete(allocation);
        }

        public Allocation Get(long id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();
            return _repository.Get(id);
        }

        public IEnumerable<Allocation> GetAll()
        {
            return _repository.GetAll();
        }

        public Allocation Save(Allocation allocation)
        {
            allocation.Validate();
            return _repository.Save(allocation);
        }

        public Allocation Update(Allocation allocation)
        {
            if (allocation.Id < 1)
                throw new IdentifierUndefinedException();
            return _repository.Update(allocation);
        }
    }
}

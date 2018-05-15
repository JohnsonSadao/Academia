using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DonaLaura.Domain.Exceptions.Comum;
using DonaLaura.Domain.Modelo.Vendas;

namespace DonaLaura.Application.Features.Vendas
{
    public class VendaService : IVendaService
    {
        private IVendaRepository _repository;

        public VendaService(IVendaRepository repository)
        {
            _repository = repository;
        }
        public void Delete(Venda venda)
        {
            _repository.Delete(venda);

        }

        public Venda Get(long id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();
            return _repository.Get(id);
        }

        public IEnumerable<Venda> GetAll()
        {
            return _repository.GetAll();
        }

        public Venda Save(Venda venda)
        {
            venda.Validate();
            return _repository.Save(venda);
        }

        public Venda Update(Venda venda)
        {
            if (venda.Id < 1)
                throw new IdentifierUndefinedException();
            venda.Validate();
            return _repository.Update(venda);
        }
    }
}

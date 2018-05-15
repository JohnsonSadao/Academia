using DonaLaura.Domain.Modelo.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Application.Features.Vendas
{
    public interface IVendaService
    {
        Venda Save(Venda venda);
        Venda Update(Venda venda);
        Venda Get(long id);
        IEnumerable<Venda> GetAll();
        void Delete(Venda venda);
    }
}

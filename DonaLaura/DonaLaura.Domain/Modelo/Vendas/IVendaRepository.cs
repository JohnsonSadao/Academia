using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Modelo.Vendas
{
    public interface IVendaRepository
    {
        Venda Save(Venda venda);
        Venda Update(Venda venda);
        Venda Get(long id);
        IEnumerable<Venda> GetAll();
        void Delete(Venda venda);
    }
}

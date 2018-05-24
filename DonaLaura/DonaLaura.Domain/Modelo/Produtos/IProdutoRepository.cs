using DonaLaura.Domain.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Infra.Data.Produtos
{
    public interface IProdutoRepository
    {
        Produto Save(Produto produto);
        Produto Update(Produto produto);
        Produto Get(long id);
        IEnumerable<Produto> GetAll();
        void Delete(Produto produto);
    }
}

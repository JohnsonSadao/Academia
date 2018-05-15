using DonaLaura.Domain.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Application.Features.Produtos
{
    public interface IProdutoService
    {
        Produto Save(Produto produto);
        Produto Update(Produto produto);
        Produto Get(long id);
        IEnumerable<Produto> GetAll();
        void Delete(Produto produto);
        bool RegisterWithDependency(int id);
    }
}

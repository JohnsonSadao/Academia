using DonaLaura.Domain.Base;
using DonaLaura.Domain.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Infra.Data.Produtos
{
    public interface IProdutoRepository: IRepository<Produto>
    {
        bool Existe(string nome);

        bool RegistroComDependencia(int id);
    }
}

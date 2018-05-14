using DonaLaura.Domain.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Base
{
    public interface IRepository<T> where T : Entidade
    {
        T Adicionar(T novaEntidade);

        T Editar(T entidadeEditada);

        T SelecionaPorId(int id);

        List<T> SelecionaTudo();

        void Deletar(int id);
    }
}

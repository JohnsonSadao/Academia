using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRosangela.Domain.Caracteristicas.Livros
{
    public interface ILivroRepository
    {
        Livro Salvar(Livro livro);
        Livro Atualizar(Livro livro);
        Livro Obter(long id);
        IEnumerable<Livro> ObterTodos();
        void Delete(Livro livro);
    }
}

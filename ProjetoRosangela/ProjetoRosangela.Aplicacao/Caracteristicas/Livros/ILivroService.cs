using ProjetoRosangela.Domain.Caracteristicas.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRosangela.Aplicacao.Caracteristicas.Livros
{
    public interface ILivroService
    {
        Livro Salvar(Livro livro);
        Livro Atualizar(Livro livro);
        Livro Obter(long id);
        IEnumerable<Livro> ObterTodos();
        void Deletar(Livro livro);
    }
}

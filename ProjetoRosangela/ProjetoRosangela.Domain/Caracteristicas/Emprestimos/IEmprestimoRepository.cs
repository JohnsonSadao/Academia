using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRosangela.Domain.Caracteristicas.Emprestimos
{
    public interface IEmprestimoRepository
    {
        Emprestimo Salvar(Emprestimo emprestimo);
        Emprestimo Atualizar(Emprestimo emprestimo);
        Emprestimo Obter(long id);
        IEnumerable<Emprestimo> ObterTodos();
        void Delete(Emprestimo emprestimo);
    }
}

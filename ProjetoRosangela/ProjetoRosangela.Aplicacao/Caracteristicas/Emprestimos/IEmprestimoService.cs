using ProjetoRosangela.Domain.Caracteristicas.Emprestimos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRosangela.Aplicacao.Caracteristicas.Emprestimos
{
    public interface IEmprestimoService
    {
        Emprestimo Salvar(Emprestimo emprestimo);
        Emprestimo Atualizar(Emprestimo emprestimo);
        Emprestimo Obter(long id);
        IEnumerable<Emprestimo> ObterTodos();
        void Deletar(Emprestimo emprestimo);
    }
}

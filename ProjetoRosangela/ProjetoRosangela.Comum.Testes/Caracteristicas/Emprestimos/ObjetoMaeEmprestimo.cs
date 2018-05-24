using ProjetoRosangela.Comum.Testes.Caracteristicas.Livros;
using ProjetoRosangela.Domain.Caracteristicas.Emprestimos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRosangela.Comum.Testes.Caracteristicas.Emprestimos
{
    public static class ObjetoMaeEmprestimo
    {
        public static Emprestimo obterEmprestimo()
        {
            Emprestimo emprestimo = new Emprestimo();
            emprestimo.DataDevolucao = DateTime.Now.AddDays(3);
            emprestimo.Cliente = "João";
            emprestimo.Livro = ObjetoMaeLivro.obterLivro();
            return emprestimo;
        }
    }
}

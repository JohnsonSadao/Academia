using ProjetoRosangela.Domain.Caracteristicas.Base;
using ProjetoRosangela.Domain.Caracteristicas.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRosangela.Domain.Caracteristicas.Emprestimos
{
    public class Emprestimo : Entidade
    {
        public string Cliente { get; set; }
        public Livro Livro { get; set; }
        public DateTime DataDevolucao { get; set; }
        public double Multa {
            get
            {
                return (DateTime.Now - DataDevolucao).TotalDays * 0.5;
            }
        }

        public override void Validar()
        {
            if (Livro.Disponibilidade == false)
                throw new DisponibilidadeException();
        }
    }
}

using ProjetoRosangela.Domain.Caracteristicas.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRosangela.Domain.Caracteristicas.Emprestimos
{
    public class DisponibilidadeException : BusinessException
    {
        public DisponibilidadeException() : base("Livro não disponivel")
        {
        }
    }
}

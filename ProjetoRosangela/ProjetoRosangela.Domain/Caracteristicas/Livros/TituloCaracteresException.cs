using ProjetoRosangela.Domain.Caracteristicas.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRosangela.Domain.Caracteristicas.Livros
{
    public class TituloCaracteresException : BusinessException
    {
        public TituloCaracteresException() : base("Titulo deve deve ter mais de 4 caracteres")
        {
        }
    }
}

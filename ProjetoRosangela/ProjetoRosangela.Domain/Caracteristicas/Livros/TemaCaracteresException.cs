using ProjetoRosangela.Domain.Caracteristicas.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRosangela.Domain.Caracteristicas.Livros
{
    public class TemaCaracteresException : BusinessException
    {
        public TemaCaracteresException() : base("Tema deve ter mais de 4 caracteres")
        {
        }
    }
}

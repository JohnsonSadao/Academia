using ProjetoRosangela.Domain.Caracteristicas.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRosangela.Domain.Caracteristicas.Livros
{
    public class AutorCaracteresException : BusinessException
    {
        public AutorCaracteresException( ) : base("Autor deve ter mais de 4 caracteres")
        {
        }
    }
}

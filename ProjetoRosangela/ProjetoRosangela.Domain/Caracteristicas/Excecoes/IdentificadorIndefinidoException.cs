using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRosangela.Domain.Caracteristicas.Excecoes
{
    public class IdentificadorIndefinidoException : BusinessException
    {
        public IdentificadorIndefinidoException() : base("Id invalido")
        {
        }
    }
}

using ProjetoRosangela.Domain.Caracteristicas.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRosangela.Domain.Caracteristicas.Livros
{
    public class VolumeException : BusinessException
    {
        public VolumeException() : base("Volume deve ser maior que 0")
        {
        }
    }
}

using ProjetoRosangela.Domain.Caracteristicas.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRosangela.Domain.Caracteristicas.Livros
{
    public class Livro : Entidade
    {
        public string Titulo { get; set; }
        public string Tema { get; set; }
        public string Autor { get; set; }

        public override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}

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
        public int Volume { get; set; }
        public DateTime DataPublicacao { get; set; }
        public bool Disponibilidade { get; set; }

        public override void Validar()
        {
            if (Titulo.Length < 4)
                throw new TituloCaracteresException();
            if (Tema.Length < 4)
                throw new TemaCaracteresException();
            if (Autor.Length < 4)
                throw new AutorCaracteresException();
            if (Volume < 1)
                throw new VolumeException();
        }
    }
}

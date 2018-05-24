using ProjetoRosangela.Domain.Caracteristicas.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRosangela.Comum.Testes.Caracteristicas.Livros
{
    public static class ObjetoMaeLivro
    {
        public static Livro obterLivro()
        {
            Livro livro = new Livro();
            livro.Titulo = "Dom Casmurro";
            livro.Autor = "Machado de Assis";
            livro.Tema = "Drama";
            livro.Volume = 1;
            livro.DataPublicação = DateTime.Now.AddDays(-40);
            livro.Disponibilidade = true;
            return livro;
        }

  
    }
}

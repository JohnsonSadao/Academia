using FluentAssertions;
using NUnit.Framework;
using ProjetoRosangela.Comum.Testes.Caracteristicas.Livros;
using ProjetoRosangela.Domain.Caracteristicas.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRosangela.Domain.Testes.Caracteristicas.Livros
{
    [TestFixture]
    public class LivroDomainTestes
    {

        [Test]
        public void Livro_ShouldBeOk()
        {
            Livro livro = ObjetoMaeLivro.obterLivro();
            Action validar = () => livro.Validar();
            validar.Should().NotThrow<Exception>();
        }

        [Test]
        public void Livro_TituloException_ShouldBeFail()
        {
            Livro livro = ObjetoMaeLivro.obterLivro();
            livro.Titulo = "asd";
            Action validar = () => livro.Validar();
            validar.Should().Throw<TituloCaracteresException>();

        }
        [Test]
        public void Livro_TemaException_ShouldBeFail()
        {
            Livro livro = ObjetoMaeLivro.obterLivro();
            livro.Tema = "asd";
            Action validar = () => livro.Validar();
            validar.Should().Throw<TemaCaracteresException>();

        }
        [Test]
        public void Livro_AutorException_ShouldBeFail()
        {
            Livro livro = ObjetoMaeLivro.obterLivro();
            livro.Autor = "asd";
            Action validar = () => livro.Validar();
            validar.Should().Throw<AutorCaracteresException>();

        }
        [Test]
        public void Livro_VolumeException_ShouldBeFail()
        {
            Livro livro = ObjetoMaeLivro.obterLivro();
            livro.Volume = 0;
            Action validar = () => livro.Validar();
            validar.Should().Throw<VolumeException>();
        }

    }
}

using FluentAssertions;
using NUnit.Framework;
using ProjetoRosangela.Comum.Testes.Caracteristicas.Livros;
using ProjetoRosangela.Comum.Testes.Comum;
using ProjetoRosangela.Domain.Caracteristicas.Excecoes;
using ProjetoRosangela.Domain.Caracteristicas.Livros;
using ProjetoRosangela.Infra.Data.Caracteristicas.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRosangela.Infra.Data.Test.Caracteristicas.Livros
{
    [TestFixture]
    public class LivroInfraTeste
    {
        LivroRepository _repository;
        [SetUp]
        public void Initialize()
        {
            _repository = new LivroRepository();
            BaseSQLTest.SeedDatabase();
        }

        [Test]
        public void LivroRespository_Add_ShouldBeOk()
        {
            Livro livro = ObjetoMaeLivro.obterLivro();
            livro.Id = 2;
            _repository.Salvar(livro);
            var livros = _repository.ObterTodos();
            livros.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void LivroRepository_Update_ShouldBeOk()
        {
            Livro livro = ObjetoMaeLivro.obterLivro();
            livro.Id = 2;
            var livroEditar = _repository.Atualizar(livro);
            livroEditar.Autor.Should().Be(livro.Autor);
        }

        [Test]
        public void LivroRepository_Get_ShouldBeOk()
        {
            var livroPego = _repository.Obter(1);
            livroPego.Titulo.Should().Be("O Cortiço");
        }

        [Test]
        public void LivroRepository_Delete_ShouldBeOk()
        {
            Livro livro = ObjetoMaeLivro.obterLivro();
            livro.Id = 2;

            _repository.Delete(livro);
            Livro deleteObject = _repository.Obter(2);

            deleteObject.Should().BeNull();
        }

        [Test]
        public void LivroRepository_GetAll_ShouldBeOK()
        {
            var list = _repository.ObterTodos();
            list.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void LivroRespository_AddValidate_ShouldBeFail()
        {
            Livro livro = ObjetoMaeLivro.obterLivro();
            livro.Id = 2;
            livro.Autor = "asd";
            Action salvar = () => _repository.Salvar(livro);
            salvar.Should().Throw<AutorCaracteresException>();
        }

        [Test]
        public void LivroRepository_Update_ShouldBeFail()
        {
            Livro livro = ObjetoMaeLivro.obterLivro();
            livro.Id = 0;
            Action update = () => _repository.Atualizar(livro);
            update.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void LivroRepository_Get_ShouldBeFail()
        {
            Action get = () => _repository.Obter(0);
            get.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void LivroRepository_Delete_ShouldBeFail()
        {
            Livro livro = ObjetoMaeLivro.obterLivro();
            Action delete = () => _repository.Delete(livro);
            delete.Should().Throw<IdentificadorIndefinidoException>();
        }


    }
}

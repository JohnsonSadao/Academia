using FluentAssertions;
using NUnit.Framework;
using ProjetoRosangela.Aplicacao.Caracteristicas.Livros;
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

namespace ProjetoRosangela.Integracao.Caracteristicas.Livros
{
    [TestFixture]
    public class LivroIntegracaoTest
    {
        private LivroService _service;
        private ILivroRepository _repository;


        [SetUp]
        public void Setup()
        {
            BaseSQLTest.SeedDatabase();
            _repository = new LivroRepository();
            _service = new LivroService(_repository);
        }

        [Test]
        public void LivroIntegracao_Adicionar_ShouldBeOk()
        {
            //Executa
            Livro livro = _service.Salvar(ObjetoMaeLivro.obterLivro());

            //Saída
            livro.Id.Should().BeGreaterThan(0);

            var last = _service.Obter(livro.Id);
            last.Should().NotBeNull();

            var posts = _service.ObterTodos();
            posts.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void LivroIntegracao_Adicionar_Titulo_ShouldBeFail()
        {
            Livro livro = ObjetoMaeLivro.obterLivro();
            livro.Autor = "asd";

            Action comparison = () => _service.Salvar(livro);

            comparison.Should().Throw<AutorCaracteresException>();
        }

        [Test]
        public void LivroIntegracao_Atualizar_ShouldBeOk()
        {
            //Cenário
            Livro modelo = ObjetoMaeLivro.obterLivro();
            modelo.Id = 1;

            //Executa
            Livro livro = _service.Atualizar(modelo);

            //Saída
            livro.Should().NotBeNull();
            livro.Id.Should().Be(modelo.Id);
            livro.Titulo.Should().Be(modelo.Titulo);
        }

        [Test]
        public void LivroIntegracao_Atualizar_Id_Invalido_ShouldBeFail()
        {
            //Cenário
            Livro modelo = ObjetoMaeLivro.obterLivro();

            //Executa
            Action comparison = () => _service.Atualizar(modelo);

            //Saída
            comparison.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void LivroIntegracao_Atualizar_Titulo_ShouldBeFail()
        {
            //Cenário
            Livro modelo = ObjetoMaeLivro.obterLivro();
            modelo.Id = 1;
            modelo.Titulo = "as";

            //Executa
            Action comparison = () => _service.Atualizar(modelo);

            //Saída
            comparison.Should().Throw<TituloCaracteresException>();
        }

        [Test]
        public void LivroIntegracao_Obter_ShouldBeOk()
        {
            //Executa
            Livro post = _service.Obter(1);

            //Saída
            post.Should().NotBeNull();

            List<Livro> posts = (List<Livro>)_service.ObterTodos();
            var found = posts.Find(x => x.Id == post.Id);
            post.Id.Should().Be(found.Id);
        }

        [Test]
        public void LivroIntegracao_Obter_ShouldBeFail()
        {
            //Executa
            Livro livro = _service.Obter(3);

            //Saída
            livro.Should().BeNull();
        }

        [Test]
        public void LivroIntegracao_Obter_Invalid_Id_ShouldBeFail()
        {
            //Executa
            Action comparison = () => _service.Obter(-1);

            //Saída
            comparison.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void LivroIntegracao_ObterAll_ShouldBeOk()
        {
            //Executa
            List<Livro> posts = _service.ObterTodos() as List<Livro>;

            //Saída
            posts.Should().NotBeNull();
            posts.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void LivroIntegracao_Delete_ShouldBeOk()
        {
            Livro livro = ObjetoMaeLivro.obterLivro();
            livro.Id = 2;
            //Executa
            _service.Deletar(livro);

            //Saída
            Livro livrodel = _service.Obter(2);
            livrodel.Should().BeNull();

            List<Livro> posts = _service.ObterTodos() as List<Livro>;
            posts.Count().Should().Be(1);
        }

        [Test]
        public void LivroIntegracao_Delete_ShouldBeFail()
        {
            //Executa
            Action comparison = () => _service.Deletar(ObjetoMaeLivro.obterLivro());

            //Saída
            comparison.Should().Throw<IdentificadorIndefinidoException>();
        }
    }
}

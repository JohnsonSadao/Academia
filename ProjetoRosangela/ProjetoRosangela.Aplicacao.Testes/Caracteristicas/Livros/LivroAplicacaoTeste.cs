using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProjetoRosangela.Aplicacao.Caracteristicas.Livros;
using ProjetoRosangela.Comum.Testes.Caracteristicas.Livros;
using ProjetoRosangela.Domain.Caracteristicas.Excecoes;
using ProjetoRosangela.Domain.Caracteristicas.Livros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRosangela.Aplicacao.Testes.Caracteristicas.Livros
{
    [TestFixture]
    class LivroAplicacaoTeste
    {

        private Mock<ILivroRepository> _mockRepository;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<ILivroRepository>();

        }

        [Test]
        public void LivroService_Add_ShouldBeOK()
        {
            Livro livro = ObjetoMaeLivro.obterLivro();
            _mockRepository.Setup(m => m.Salvar(livro)).Returns(new Livro() { Id = 1 });
            LivroService service = new LivroService(_mockRepository.Object);

            Livro resultado = service.Salvar(livro);

            resultado.Should().NotBeNull();
            resultado.Id.Should().BeGreaterThan(0);
            _mockRepository.Verify(repository => repository.Salvar(livro));
        }

        [Test]
        public void LivroService_Update_ShouldBeOK()
        {
            Livro livro = ObjetoMaeLivro.obterLivro();
            livro.Id = 2;

            _mockRepository.Setup(m => m.Atualizar(livro)).Returns(livro);

            LivroService service = new LivroService(_mockRepository.Object);


            Livro resultado = service.Atualizar(livro);

            resultado.Should().NotBeNull();
            resultado.Titulo.Should().Be("Dom Casmurro");
            _mockRepository.Verify(repository => repository.Atualizar(livro));
        }

        [Test]
        public void LivroService_Get_ShouldBeOk()
        {

            Livro livro = ObjetoMaeLivro.obterLivro();
            livro.Id = 3;

            _mockRepository.Setup(m => m.Obter(3)).Returns(livro);

            LivroService service = new LivroService(_mockRepository.Object);
            Livro resultado = service.Obter(3);

            resultado.Should().NotBeNull();
            _mockRepository.Verify(repository => repository.Obter(3));
        }

        [Test]
        public void LivroService_GetAll_ShouldBeOk()
        {

            _mockRepository.Setup(m => m.ObterTodos()).Returns(new List<Livro>());

            LivroService service = new LivroService(_mockRepository.Object);

            IEnumerable<Livro> resultado = service.ObterTodos();

            resultado.Should().NotBeNull();
            _mockRepository.Verify(repository => repository.ObterTodos());
        }

        [Test]
        public void LivroService_Delete_ShouldBeOk()
        {
            Livro modelo = ObjetoMaeLivro.obterLivro();
            modelo.Id = 1;

            _mockRepository.Setup(m => m.Delete(modelo));


            LivroService service = new LivroService(_mockRepository.Object);

            service.Deletar(modelo);

            _mockRepository.Verify(repository => repository.Delete(modelo));
        }


        [Test]
        public void LivroService_Add_ShouldBeFail()
        {

            Livro modelo = ObjetoMaeLivro.obterLivro();
            modelo.Titulo = "por";

            LivroService service = new LivroService(_mockRepository.Object);

            Action comparison = () => service.Salvar(modelo);

            comparison.Should().Throw<TituloCaracteresException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void LivroService_Update_Invalid_Id_ShouldBeFail()
        {

            Livro modelo = ObjetoMaeLivro.obterLivro();
            modelo.Id = 0;

            LivroService service = new LivroService(_mockRepository.Object);

            Action update = () => service.Atualizar(modelo);

            update.Should().Throw<IdentificadorIndefinidoException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void PostService_Get_Invalid_Id_ShouldBeFail()
        {

            LivroService service = new LivroService(_mockRepository.Object);
            Livro livro = new Livro()
            {
                Id = 0
            };
            Action comparison = () => service.Atualizar(livro);

            comparison.Should().Throw<IdentificadorIndefinidoException>();
            _mockRepository.VerifyNoOtherCalls();
        }
    }
}

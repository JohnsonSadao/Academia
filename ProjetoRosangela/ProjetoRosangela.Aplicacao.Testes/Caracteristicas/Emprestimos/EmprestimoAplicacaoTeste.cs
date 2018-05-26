using FluentAssertions;
using Moq;
using NUnit.Framework;
using ProjetoRosangela.Aplicacao.Caracteristicas.Emprestimos;
using ProjetoRosangela.Comum.Testes.Caracteristicas.Emprestimos;
using ProjetoRosangela.Domain.Caracteristicas.Emprestimos;
using ProjetoRosangela.Domain.Caracteristicas.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRosangela.Aplicacao.Testes.Caracteristicas.Emprestimos
{
    [TestFixture]
    class EmprestimoAplicacaoTeste
    {

        private Mock<IEmprestimoRepository> _mockRepository;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IEmprestimoRepository>();

        }

        [Test]
        public void EmprestimoService_Add_ShouldBeOK()
        {
            Emprestimo emprestimo = ObjetoMaeEmprestimo.obterEmprestimo();
            _mockRepository.Setup(m => m.Salvar(emprestimo)).Returns(new Emprestimo() { Id = 1 });
            EmprestimoService service = new EmprestimoService(_mockRepository.Object);

            Emprestimo resultado = service.Salvar(emprestimo);

            resultado.Should().NotBeNull();
            resultado.Id.Should().BeGreaterThan(0);
            _mockRepository.Verify(repository => repository.Salvar(emprestimo));
        }

        [Test]
        public void EmprestimoService_Update_ShouldBeOK()
        {
            Emprestimo emprestimo = ObjetoMaeEmprestimo.obterEmprestimo();
            emprestimo.Id = 2;

            _mockRepository.Setup(m => m.Atualizar(emprestimo)).Returns(emprestimo);

            EmprestimoService service = new EmprestimoService(_mockRepository.Object);


            Emprestimo resultado = service.Atualizar(emprestimo);

            resultado.Should().NotBeNull();
            resultado.Cliente.Should().Be("João");
            _mockRepository.Verify(repository => repository.Atualizar(emprestimo));
        }

        [Test]
        public void EmprestimoService_Get_ShouldBeOk()
        {

            Emprestimo emprestimo = ObjetoMaeEmprestimo.obterEmprestimo();
            emprestimo.Id = 3;

            _mockRepository.Setup(m => m.Obter(3)).Returns(emprestimo);

            EmprestimoService service = new EmprestimoService(_mockRepository.Object);
            Emprestimo resultado = service.Obter(3);

            resultado.Should().NotBeNull();
            _mockRepository.Verify(repository => repository.Obter(3));
        }

        [Test]
        public void EmprestimoService_GetAll_ShouldBeOk()
        {

            _mockRepository.Setup(m => m.ObterTodos()).Returns(new List<Emprestimo>());

            EmprestimoService service = new EmprestimoService(_mockRepository.Object);

            IEnumerable<Emprestimo> resultado = service.ObterTodos();

            resultado.Should().NotBeNull();
            _mockRepository.Verify(repository => repository.ObterTodos());
        }

        [Test]
        public void EmprestimoService_Delete_ShouldBeOk()
        {
            Emprestimo modelo = ObjetoMaeEmprestimo.obterEmprestimo();
            modelo.Id = 1;

            _mockRepository.Setup(m => m.Delete(modelo));


            EmprestimoService service = new EmprestimoService(_mockRepository.Object);

            service.Deletar(modelo);

            _mockRepository.Verify(repository => repository.Delete(modelo));
        }


        [Test]
        public void EmprestimoService_Add_ShouldBeFail()
        {

            Emprestimo modelo = ObjetoMaeEmprestimo.obterEmprestimo();
            modelo.Livro.Disponibilidade = false;

            EmprestimoService service = new EmprestimoService(_mockRepository.Object);

            Action comparison = () => service.Salvar(modelo);

            comparison.Should().Throw<DisponibilidadeException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void EmprestimoService_Update_Invalid_Id_ShouldBeFail()
        {

            Emprestimo modelo = ObjetoMaeEmprestimo.obterEmprestimo();
            modelo.Id = 0;

            EmprestimoService service = new EmprestimoService(_mockRepository.Object);

            Action update = () => service.Atualizar(modelo);

            update.Should().Throw<IdentificadorIndefinidoException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void PostService_Get_Invalid_Id_ShouldBeFail()
        {

            EmprestimoService service = new EmprestimoService(_mockRepository.Object);
            Emprestimo emprestimo = new Emprestimo()
            {
                Id = 0
            };
            Action comparison = () => service.Atualizar(emprestimo);

            comparison.Should().Throw<IdentificadorIndefinidoException>();
            _mockRepository.VerifyNoOtherCalls();
        }
    }
}


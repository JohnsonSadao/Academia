using FluentAssertions;
using NUnit.Framework;
using ProjetoRosangela.Aplicacao.Caracteristicas.Emprestimos;
using ProjetoRosangela.Comum.Testes.Caracteristicas.Emprestimos;
using ProjetoRosangela.Comum.Testes.Comum;
using ProjetoRosangela.Domain.Caracteristicas.Emprestimos;
using ProjetoRosangela.Domain.Caracteristicas.Excecoes;
using ProjetoRosangela.Infra.Data.Caracteristicas.Emprestimos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRosangela.Integracao.Caracteristicas.Emprestimos
{
    [TestFixture]
    public class EmprestimoIntegracaoTest
    {
        private EmprestimoService _service;
        private IEmprestimoRepository _repository;


        [SetUp]
        public void Setup()
        {
            BaseSQLTest.SeedDatabase();
            _repository = new EmprestimoRepository();
            _service = new EmprestimoService(_repository);
        }

        [Test]
        public void EmprestimoIntegracao_Adicionar_ShouldBeOk()
        {
            //Executa
            Emprestimo emprestimo = ObjetoMaeEmprestimo.obterEmprestimo();
            emprestimo.Livro.Id = 1;
            Emprestimo emprestimoAdd = _service.Salvar(emprestimo);
            
            //Saída
            emprestimo.Id.Should().BeGreaterThan(0);

            var last = _service.Obter(emprestimo.Id);
            last.Should().NotBeNull();

            var posts = _service.ObterTodos();
            posts.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void EmprestimoIntegracao_Adicionar_Titulo_ShouldBeFail()
        {
            Emprestimo emprestimo = ObjetoMaeEmprestimo.obterEmprestimo();
            emprestimo.Livro.Disponibilidade = false;

            Action comparison = () => _service.Salvar(emprestimo);

            comparison.Should().Throw<DisponibilidadeException>();
        }

        [Test]
        public void EmprestimoIntegracao_Atualizar_ShouldBeOk()
        {
            //Cenário
            Emprestimo modelo = ObjetoMaeEmprestimo.obterEmprestimo();
            modelo.Id = 2;

            //Executa
            Emprestimo emprestimo = _service.Atualizar(modelo);

            //Saída
            emprestimo.Should().NotBeNull();
            emprestimo.Id.Should().Be(modelo.Id);
            emprestimo.Cliente.Should().Be(modelo.Cliente);
        }

        [Test]
        public void EmprestimoIntegracao_Atualizar_Id_Invalido_ShouldBeFail()
        {
            //Cenário
            Emprestimo modelo = ObjetoMaeEmprestimo.obterEmprestimo();

            //Executa
            Action comparison = () => _service.Atualizar(modelo);

            //Saída
            comparison.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void EmprestimoIntegracao_Atualizar_Titulo_ShouldBeFail()
        {
            //Cenário
            Emprestimo modelo = ObjetoMaeEmprestimo.obterEmprestimo();
            modelo.Id = 1;
            modelo.Livro.Disponibilidade = false;

            //Executa
            Action comparison = () => _service.Atualizar(modelo);

            //Saída
            comparison.Should().Throw<DisponibilidadeException>();
        }

        [Test]
        public void EmprestimoIntegracao_Obter_ShouldBeOk()
        {
            //Executa
            Emprestimo post = _service.Obter(1);

            //Saída
            post.Should().NotBeNull();

            List<Emprestimo> posts = (List<Emprestimo>)_service.ObterTodos();
            var found = posts.Find(x => x.Id == post.Id);
            post.Id.Should().Be(found.Id);
        }

        [Test]
        public void EmprestimoIntegracao_Obter_ShouldBeFail()
        {
            //Executa
            Emprestimo emprestimo = _service.Obter(3);

            //Saída
            emprestimo.Should().BeNull();
        }

        [Test]
        public void EmprestimoIntegracao_Obter_Invalid_Id_ShouldBeFail()
        {
            //Executa
            Action comparison = () => _service.Obter(-1);

            //Saída
            comparison.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void EmprestimoIntegracao_ObterAll_ShouldBeOk()
        {
            //Executa
            List<Emprestimo> posts = _service.ObterTodos() as List<Emprestimo>;

            //Saída
            posts.Should().NotBeNull();
            posts.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void EmprestimoIntegracao_Delete_ShouldBeOk()
        {
            Emprestimo emprestimo = ObjetoMaeEmprestimo.obterEmprestimo();
            emprestimo.Id = 2;
            //Executa
            _service.Deletar(emprestimo);

            //Saída
            Emprestimo emprestimodel = _service.Obter(2);
            emprestimodel.Should().BeNull();

            List<Emprestimo> posts = _service.ObterTodos() as List<Emprestimo>;
            posts.Count().Should().Be(1);
        }

        [Test]
        public void EmprestimoIntegracao_Delete_ShouldBeFail()
        {
            //Executa
            Action comparison = () => _service.Deletar(ObjetoMaeEmprestimo.obterEmprestimo());

            //Saída
            comparison.Should().Throw<IdentificadorIndefinidoException>();
        }
    }
}

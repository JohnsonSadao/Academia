using FluentAssertions;
using NUnit.Framework;
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

namespace ProjetoRosangela.Infra.Data.Test.Caracteristicas.Emprestimos
{
    [TestFixture]
    public class EmprestimoInfraTeste
    {
        EmprestimoRepository _repository;
        [SetUp]
        public void Initialize()
        {
            _repository = new EmprestimoRepository();
            BaseSQLTest.SeedDatabase();
        }

        [Test]
        public void EmprestimoRespository_Add_ShouldBeOk()
        {
            Emprestimo emprestimo = ObjetoMaeEmprestimo.obterEmprestimo();
            emprestimo.Id = 2;
            emprestimo.Livro.Id = 1;
            _repository.Salvar(emprestimo);
            var emprestimos = _repository.ObterTodos();
            emprestimos.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void EmprestimoRepository_Update_ShouldBeOk()
        {
            Emprestimo emprestimo = ObjetoMaeEmprestimo.obterEmprestimo();
            emprestimo.Id = 2;
            var emprestimoEditar = _repository.Atualizar(emprestimo);
            emprestimoEditar.Cliente.Should().Be(emprestimo.Cliente);
        }

        [Test]
        public void EmprestimoRepository_Get_ShouldBeOk()
        {
            var emprestimoPego = _repository.Obter(1);
            emprestimoPego.Cliente.Should().Be("Pedro");
        }

        [Test]
        public void EmprestimoRepository_Delete_ShouldBeOk()
        {
            Emprestimo emprestimo = ObjetoMaeEmprestimo.obterEmprestimo();
            emprestimo.Id = 2;

            _repository.Delete(emprestimo);
            Emprestimo deleteObject = _repository.Obter(2);

            deleteObject.Should().BeNull();
        }

        [Test]
        public void EmprestimoRepository_GetAll_ShouldBeOK()
        {
            var list = _repository.ObterTodos();
            list.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void EmprestimoRespository_AddValidate_ShouldBeFail()
        {
            Emprestimo emprestimo = ObjetoMaeEmprestimo.obterEmprestimo();
            emprestimo.Id = 2;
            emprestimo.Livro.Disponibilidade = false ;
            Action salvar = () => _repository.Salvar(emprestimo);
            salvar.Should().Throw<DisponibilidadeException>();
        }

        [Test]
        public void EmprestimoRepository_Update_ShouldBeFail()
        {
            Emprestimo emprestimo = ObjetoMaeEmprestimo.obterEmprestimo();
            emprestimo.Id = 0;
            Action update = () => _repository.Atualizar(emprestimo);
            update.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void EmprestimoRepository_get_ShouldBeFail()
        {
            Action get = () => _repository.Obter(0);
            get.Should().Throw<IdentificadorIndefinidoException>();
        }

        [Test]
        public void EmprestimoRepository_Delete_ShouldBeFail()
        {
            Emprestimo emprestimo = ObjetoMaeEmprestimo.obterEmprestimo();
            Action delete = () => _repository.Delete(emprestimo);
            delete.Should().Throw<IdentificadorIndefinidoException>();
        }
    }
}

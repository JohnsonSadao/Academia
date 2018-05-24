using FluentAssertions;
using NUnit.Framework;
using ProjetoRosangela.Comum.Testes.Caracteristicas.Emprestimos;
using ProjetoRosangela.Domain.Caracteristicas.Emprestimos;
using ProjetoRosangela.Domain.Caracteristicas.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRosangela.Domain.Testes.Caracteristicas.Emprestimos
{
    [TestFixture]
    public class EmprestimoDominioTestes
    {
        [Test]
        public void Emprestimo_ShouldBeOk()
        {
            Emprestimo emprestimo = ObjetoMaeEmprestimo.obterEmprestimo();
            Action validar = () => emprestimo.Validar();
            validar.Should().NotThrow<BusinessException>();
        }
        [Test]
        public void Emprestimo_Disponibilidade_ShouldBeFail()
        {
            Emprestimo emprestimo = ObjetoMaeEmprestimo.obterEmprestimo();
            emprestimo.Livro.Disponibilidade = false;
            Action validar = () => emprestimo.Validar();
            validar.Should().Throw<DisponibilidadeException>();
        }
    }
}

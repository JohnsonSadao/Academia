using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Exceptions.Vendas;
using DonaLaura.Domain.Modelo.Vendas;
using DonaLauraComum.Vendas;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Test.Vendas
{
    [TestFixture]
    public class VendaDomainTest
    {
        [Test]
        public void Venda_Validate_ShouldBeOK()
        {
            Venda venda = ObjectMotherVenda.getValidVenda();
            Action validate = () => venda.Validate();
            validate.Should().NotThrow<Exception>();
        }

        [Test]
        public void Venda_ValidateValidade_ShouldBeOK()
        {
            Venda venda = ObjectMotherVenda.getValidVenda();
            venda.produtoVenda.DataValidade = DateTime.Now.AddDays(-9);
            Action validate = () => venda.Validate();
            validate.Should().Throw<ValidadeException>();
        }

        [Test]
        public void Venda_ValidateDisponibilidade_ShouldBeOK()
        {
            Venda venda = ObjectMotherVenda.getValidVenda();
            venda.produtoVenda.Disponibilidade = false;
            Action validate = () => venda.Validate();
            validate.Should().Throw<DisponibilidadeException>();
        }

    }
}

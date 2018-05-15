using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Exceptions.Comum;
using DonaLaura.Domain.Modelo.Vendas;
using DonaLaura.Infra.Data.Vendas;
using DonaLauraComum.Base;
using DonaLauraComum.Vendas;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Infra.Data.Test
{
    [TestFixture]
    public class VendaRepositoryTest
    {
        public VendaRepository _repository;

        [SetUp]
        public void Initialize()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new VendaRepository();
        }
        [Test]
        public void VendaRespository_Add_ShouldBeOk()
        {
            Venda venda = ObjectMotherVenda.getValidVenda();
            venda.Id = 2;
            _repository.Save(venda);
            var vendas =  _repository.GetAll();
            vendas.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void VendaRepository_Update_ShouldBeOk()
        {
            Venda venda = ObjectMotherVenda.getValidVenda();
            venda.Id = 2;
            var vendaEditar = _repository.Update(venda);
            vendaEditar.cliente.Should().Be(venda.cliente);
        }

        [Test]
        public void VendaRepository_Get_ShouldBeOk()
        {
            var vendaPega = _repository.Get(1);
            vendaPega.cliente.Should().Be("Pedro");
        }

        [Test]
        public void VendaRepository_Delete_ShouldBeOk()
        {
            Venda venda = ObjectMotherVenda.getValidVenda();
            venda.Id = 1;

            _repository.Delete(venda);
            Venda deleteObject = _repository.Get(1);

            deleteObject.Should().BeNull();
        }

        [Test]
        public void VendaRepository_GetAll_ShouldBeOK()
        {
            var list = _repository.GetAll();
            list.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void VendaRespository_AddValidate_ShouldBeFail()
        {
            Venda venda = ObjectMotherVenda.getValidVenda();
            venda.Id = 2;
            venda.produtoVenda.DataValidade = DateTime.Now.AddDays(-8);
            Action salvar = () => _repository.Save(venda);
            salvar.Should().Throw<ValidadeException>();
        }

        [Test]
        public void VendaRepository_Update_ShouldBeFail()
        {
            Venda venda = ObjectMotherVenda.getValidVenda();
            venda.Id = 0;
            Action update = () => _repository.Update(venda);
            update.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void VendaRepository_get_ShouldBeFail()
        {
            Action get = () => _repository.Get(0);
            get.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void VendaRepository_Delete_ShouldBeFail()
        {
            Venda vendas = ObjectMotherVenda.getValidVenda();
            Action delete = () => _repository.Delete(vendas);
            delete.Should().Throw<IdentifierUndefinedException>();
        }
    }
}

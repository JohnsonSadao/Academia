using DonaLaura.Application.Features.Vendas;
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

namespace DonaLaura.Integration.Test.Features.Vendas
{
    class VendaIntegrationTest
    {
        private VendaService _service;
        private IVendaRepository _repository;


        [SetUp]
        public void Setup()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new VendaRepository();
            _service = new VendaService(_repository);
        }

        [Test]
        public void VendaIntegration_Add_ShouldBeOk()
        {
            //Executa
            Venda venda = _service.Save(ObjectMotherVenda.getValidVenda());

            //Saída
            venda.Id.Should().BeGreaterThan(0);

            var last = _service.Get(venda.Id);
            last.Should().NotBeNull();

            var posts = _service.GetAll();
            posts.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void VendaIntegration_Add_Nome_ShouldBeFail()
        {
            Venda venda = ObjectMotherVenda.getValidVenda();
            venda.produtoVenda.DataValidade = DateTime.Now.AddDays(-9);

            Action comparison = () => _service.Save(venda);

            comparison.Should().Throw<ValidadeException>();
        }

        [Test]
        public void VendaIntegration_Update_ShouldBeOk()
        {
            //Cenário
            Venda modelo = ObjectMotherVenda.getValidVenda();
            modelo.Id = 1;

            //Executa
            Venda venda = _service.Update(modelo);

            //Saída
            venda.Should().NotBeNull();
            venda.Id.Should().Be(modelo.Id);
            venda.cliente.Should().Be(modelo.cliente);
        }

        [Test]
        public void VendaIntegration_Update_Invalid_Id_ShouldBeFail()
        {
            //Cenário
            Venda modelo = ObjectMotherVenda.getValidVenda();

            //Executa
            Action comparison = () => _service.Update(modelo);

            //Saída
            comparison.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void VendaIntegration_Update_Nome_ShouldBeFail()
        {
            //Cenário
            Venda modelo = ObjectMotherVenda.getValidVenda();
            modelo.Id = 1;
            modelo.produtoVenda.DataValidade = DateTime.Now.AddDays(-9);

            //Executa
            Action comparison = () => _service.Update(modelo);

            //Saída
            comparison.Should().Throw<ValidadeException>();
        }

        [Test]
        public void VendaIntegration_Get_ShouldBeOk()
        {
            //Executa
            Venda post = _service.Get(1);

            //Saída
            post.Should().NotBeNull();

            List<Venda> posts = (List<Venda>)_service.GetAll();
            var found = posts.Find(x => x.Id == post.Id);
            post.Id.Should().Be(found.Id);
        }

        [Test]
        public void VendaIntegration_Get_ShouldBeFail()
        {
            //Executa
            Venda venda = _service.Get(3);

            //Saída
            venda.Should().BeNull();
        }

        [Test]
        public void VendaIntegration_Get_Invalid_Id_ShouldBeFail()
        {
            //Executa
            Action comparison = () => _service.Get(-1);

            //Saída
            comparison.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void VendaIntegration_GetAll_ShouldBeOk()
        {
            //Executa
            List<Venda> posts = _service.GetAll() as List<Venda>;

            //Saída
            posts.Should().NotBeNull();
            posts.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void VendaIntegration_Delete_ShouldBeOk()
        {
            Venda venda = ObjectMotherVenda.getValidVenda();
            venda.Id = 2;
            //Executa
            _service.Delete(venda);

            //Saída
            Venda vendadel = _service.Get(2);
            vendadel.Should().BeNull();

            List<Venda> posts = _service.GetAll() as List<Venda>;
            posts.Count().Should().Be(1);
        }

        [Test]
        public void VendaIntegration_Delete_ShouldBeFail()
        {
            //Executa
            Action comparison = () => _service.Delete(ObjectMotherVenda.getValidVenda());

            //Saída
            comparison.Should().Throw<IdentifierUndefinedException>();
        }
    }
}

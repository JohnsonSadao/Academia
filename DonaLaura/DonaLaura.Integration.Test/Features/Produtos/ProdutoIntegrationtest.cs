using DonaLaura.Application.Features.Produtos;
using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Exceptions.Comum;
using DonaLaura.Domain.Modelo;
using DonaLaura.Infra.Data.Produtos;
using DonaLauraComum.Base;
using DonaLauraComum.Produtos;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Integration.Test.Features.Produtos
{
    [TestFixture]
    public class ProdutoIntegrationtest
    {
        private ProdutoService _service;
        private IProdutoRepository _repository;


        [SetUp]
        public void Setup()
        {
            BaseSqlTest.SeedDatabase();
            _repository = new ProdutoRepository();
            _service = new ProdutoService(_repository);
        }

        [Test]
        public void ProdutoIntegration_Add_ShouldBeOk()
        {
            //Executa
            Produto produto = _service.Save(ObjectMother.ObterProdutoValido());

            //Saída
            produto.Id.Should().BeGreaterThan(0);

            var last = _service.Get(produto.Id);
            last.Should().NotBeNull();

            var posts = _service.GetAll();
            posts.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void ProdutoIntegration_Add_Nome_ShouldBeFail()
        {
            Produto produto = ObjectMother.ObterProdutoValido();
            produto.Nome = "asd";

            Action comparison = () => _service.Save(produto);
            
            comparison.Should().Throw<NomeException>();
        }

        [Test]
        public void ProdutoIntegration_Update_ShouldBeOk()
        {
            //Cenário
            Produto modelo = ObjectMother.ObterProdutoValido();
            modelo.Id = 1;

            //Executa
            Produto produto = _service.Update(modelo);

            //Saída
            produto.Should().NotBeNull();
            produto.Id.Should().Be(modelo.Id);
            produto.Nome.Should().Be(modelo.Nome);
        }

        [Test]
        public void ProdutoIntegration_Update_Invalid_Id_ShouldBeFail()
        {
            //Cenário
            Produto modelo = ObjectMother.ObterProdutoValido();

            //Executa
            Action comparison = () => _service.Update(modelo);

            //Saída
            comparison.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void ProdutoIntegration_Update_Nome_ShouldBeFail()
        {
            //Cenário
            Produto modelo = ObjectMother.ObterProdutoValido();
            modelo.Id = 1;
            modelo.Nome = "as";

            //Executa
            Action comparison = () => _service.Update(modelo);

            //Saída
            comparison.Should().Throw<NomeException>();
        }

        [Test]
        public void ProdutoIntegration_Get_ShouldBeOk()
        {
            //Executa
            Produto post = _service.Get(1);

            //Saída
            post.Should().NotBeNull();

            List<Produto> posts = (List<Produto>)_service.GetAll();
            var found = posts.Find(x => x.Id == post.Id);
            post.Id.Should().Be(found.Id);
        }

        [Test]
        public void ProdutoIntegration_Get_ShouldBeFail()
        {
            //Executa
            Produto produto = _service.Get(3);

            //Saída
            produto.Should().BeNull();
        }

        [Test]
        public void ProdutoIntegration_Get_Invalid_Id_ShouldBeFail()
        {
            //Executa
            Action comparison = () => _service.Get(-1);

            //Saída
            comparison.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void ProdutoIntegration_GetAll_ShouldBeOk()
        {
            //Executa
            List<Produto> posts = _service.GetAll() as List<Produto>;

            //Saída
            posts.Should().NotBeNull();
            posts.Count.Should().BeGreaterThan(0);
        }

        [Test]
        public void ProdutoIntegration_Delete_ShouldBeOk()
        {
            Produto produto = ObjectMother.ObterProdutoValido();
            //Executa
            _service.Delete(produto);

            //Saída
            Produto produtodel = _service.Get(1);
            produtodel.Should().BeNull();

            List<Produto> posts = _service.GetAll() as List<Produto>;
            posts.Count().Should().Be(0);
        }

        [Test]
        public void ProdutoIntegration_Delete_ShouldBeFail()
        {
            //Executa
            Action comparison = () => _service.Delete(ObjectMother.ObterProdutoValido());

            //Saída
            comparison.Should().Throw<IdentifierUndefinedException>();
        }
    }
}

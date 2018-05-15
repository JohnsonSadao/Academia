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

namespace DonaLaura.Infra.Test.Produtos
{
    [TestFixture]
    public class ProdutoRepositoryTest
    {
        ProdutoRepository _repository;
        Produto produto;
       [SetUp]
        public void Initialize()
        {
           
           _repository = new ProdutoRepository();
            BaseSqlTest.SeedDatabase();
        }

        [Test]
        public void ProdutoRespository_Add_ShouldBeOk()
        {
            Produto produto = ObjectMotherProduto.getValidProduto();
            produto.Id = 2;
            _repository.Save(produto);
            var produtos =  _repository.GetAll();
            produtos.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void ProdutoRepository_Update_ShouldBeOk()
        {
            Produto produto = ObjectMotherProduto.getValidProduto();
            produto.Id = 2;
            var produtoEditar = _repository.Update(produto);
            produtoEditar.Nome.Should().Be(produto.Nome);
        }

        [Test]
        public void ProdutoRepository_Get_ShouldBeOk()
        {
            var produtoPego = _repository.Get(1);
            produtoPego.Nome.Should().Be("Arroz");
        }

        [Test]
        public void ProdutoRepository_Delete_ShouldBeOk()
        {
            Produto produto = ObjectMotherProduto.getValidProduto();
            produto.Id = 2;

            _repository.Delete(produto);
            Produto deleteObject = _repository.Get(2);

            deleteObject.Should().BeNull();
        }

        [Test]
        public void ProdutoRepository_GetAll_ShouldBeOK()
        {
            var list = _repository.GetAll();
            list.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void ProdutoRespository_AddValidate_ShouldBeFail()
        {
            Produto produto = ObjectMotherProduto.getValidProduto();
            produto.Id = 2;
            produto.Nome = "asd";
            Action salvar = () => _repository.Save(produto);
            salvar.Should().Throw<NomeException>();
        }

        [Test]
        public void ProdutoRepository_Update_ShouldBeFail()
        {
            Produto produto = ObjectMotherProduto.getValidProduto();
            produto.Id = 0;
            Action update = () => _repository.Update(produto);
            update.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void ProdutoRepository_get_ShouldBeFail()
        {
            Action get = () => _repository.Get(0);
            get.Should().Throw<IdentifierUndefinedException>();
        }

        [Test]
        public void ProdutoRepository_Delete_ShouldBeFail()
        {
            Produto produto = ObjectMotherProduto.getValidProduto();
            Action delete = () => _repository.Delete(produto);
            delete.Should().Throw<IdentifierUndefinedException>();
        }
    }
}

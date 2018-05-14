using DonaLaura.Domain.Modelo;
using DonaLaura.Infra.Data.Produtos;
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
        ProdutoRepository _repositorio;
        Produto produto;
       [SetUp]
        public void Initialize()
        {
            produto = ObjectMother.ObterProdutoValido();
           _repositorio = new ProdutoRepository();
        }

        [Test]
        public void ProdutoRespository_Add_ShouldBeOk()
        {
            _repositorio.Adicionar(produto);
            List<Produto> produtos =  _repositorio.SelecionaTudo();
            produtos.Count().Should().BeGreaterThan(1);
        }
    }
}

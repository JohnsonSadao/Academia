using DonaLaura.Application.Features.Produtos;
using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Exceptions.Comum;
using DonaLaura.Domain.Modelo;
using DonaLaura.Infra.Data.Produtos;
using DonaLauraComum.Produtos;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Application.Test.Produtos
{
    [TestFixture]
    public class ProdutoServiceTest
    {
        private Mock<IProdutoRepository> _mockRepository;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IProdutoRepository>();
        }

        [Test]
        public void ProdutoService_Add_ShouldBeOK()
        {
            Produto produto = ObjectMotherProduto.getValidProduto();
            _mockRepository.Setup(m => m.Save(produto)).Returns(new Produto() { Id = 1 });
            ProdutoService service = new ProdutoService(_mockRepository.Object);

            Produto resultado = service.Save(produto);
            
            resultado.Should().NotBeNull();
            resultado.Id.Should().BeGreaterThan(0);
            _mockRepository.Verify(repository => repository.Save(produto));
        }

        [Test]
        public void ProdutoService_Update_ShouldBeOK()
        {
            Produto produto = ObjectMotherProduto.getValidProduto();
            produto.Id = 2;

            _mockRepository.Setup(m => m.Update(produto)).Returns(new Produto()
            {
                Id = 2,
                Nome = "Feijão"
            });
            
            ProdutoService service = new ProdutoService(_mockRepository.Object);
           
            
            Produto resultado = service.Update(produto);
            
            resultado.Should().NotBeNull();
            resultado.Nome.Should().Be("Feijão");
            _mockRepository.Verify(repository => repository.Update(produto));
        }

        [Test]
        public void ProdutoService_Get_ShouldBeOk()
        {
            
            Produto produto = ObjectMotherProduto.getValidProduto();
            produto.Id = 3;
                        
            _mockRepository.Setup(m => m.Get(3)).Returns(produto);
                        
            ProdutoService service = new ProdutoService(_mockRepository.Object);
            Produto resultado = service.Get(3);

            resultado.Should().NotBeNull();
            _mockRepository.Verify(repository => repository.Get(3));
        }

        [Test]
        public void ProdutoService_GetAll_ShouldBeOk()
        {
            
            _mockRepository.Setup(m => m.GetAll()).Returns(new List<Produto>());
            
            ProdutoService service = new ProdutoService(_mockRepository.Object);
            
            IEnumerable<Produto> resultado = service.GetAll();
            
            resultado.Should().NotBeNull();
            _mockRepository.Verify(repository => repository.GetAll());
        }

        [Test]
        public void ProdutoService_Delete_ShouldBeOk()
        {
            Produto modelo = ObjectMotherProduto.getValidProduto();
            modelo.Id = 1;
            
            _mockRepository.Setup(m => m.Delete(modelo));

            
            ProdutoService service = new ProdutoService(_mockRepository.Object);
                        
            service.Delete(modelo);

            _mockRepository.Verify(repository => repository.Delete(modelo));
        }


        [Test]
        public void ProdutoService_Add_ShouldBeFail()
        {

            Produto modelo = ObjectMotherProduto.getValidProduto();
            modelo.Nome = "asd";
            
            ProdutoService service = new ProdutoService(_mockRepository.Object);
            
            Action comparison = () => service.Save(modelo);

            comparison.Should().Throw<NomeException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void ProdutoService_Update_Invalid_Id_ShouldBeFail()
        {

            Produto modelo = ObjectMotherProduto.getValidProduto();
            modelo.Id = 0;
            
            ProdutoService service = new ProdutoService(_mockRepository.Object);
           
            Action comparison = () => service.Update(modelo);
            
            comparison.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void PostService_Get_Invalid_Id_ShouldBeFail()
        {
            
            ProdutoService service = new ProdutoService(_mockRepository.Object);
            // Fim Cenario

            //Executa
            Action comparison = () => service.Get(0);

            //Saída
            comparison.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }


    }
}

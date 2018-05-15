using DonaLaura.Application.Features.Vendas;
using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Exceptions.Comum;
using DonaLaura.Domain.Modelo.Vendas;
using DonaLauraComum.Vendas;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Application.Test.Vendas
{
    [TestFixture]
    public class VendaServiceTest
    {
        private Mock<IVendaRepository> _mockRepository;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IVendaRepository>();
        }

        [Test]
        public void VendaService_Add_ShouldBeOK()
        {
            Venda produto = ObjectMotherVenda.getValidVenda();
            _mockRepository.Setup(m => m.Save(produto)).Returns(new Venda() { Id = 1 });
            VendaService service = new VendaService(_mockRepository.Object);

            Venda resultado = service.Save(produto);

            resultado.Should().NotBeNull();
            resultado.Id.Should().BeGreaterThan(0);
            _mockRepository.Verify(repository => repository.Save(produto));
        }

        [Test]
        public void VendaService_Update_ShouldBeOK()
        {
            Venda produto = ObjectMotherVenda.getValidVenda();
            produto.Id = 2;

            _mockRepository.Setup(m => m.Update(produto)).Returns(new Venda()
            {
                Id = 2,
                cliente = "Pedro",
                quantidade = 1
            });

            VendaService service = new VendaService(_mockRepository.Object);


            Venda resultado = service.Update(produto);

            resultado.Should().NotBeNull();
            resultado.cliente.Should().Be("Pedro");
            _mockRepository.Verify(repository => repository.Update(produto));
        }

        [Test]
        public void VendaService_Get_ShouldBeOk()
        {

            Venda produto = ObjectMotherVenda.getValidVenda();
            produto.Id = 3;

            _mockRepository.Setup(m => m.Get(3)).Returns(produto);

            VendaService service = new VendaService(_mockRepository.Object);
            Venda resultado = service.Get(3);

            resultado.Should().NotBeNull();
            _mockRepository.Verify(repository => repository.Get(3));
        }

        [Test]
        public void VendaService_GetAll_ShouldBeOk()
        {

            _mockRepository.Setup(m => m.GetAll()).Returns(new List<Venda>());

            VendaService service = new VendaService(_mockRepository.Object);

            IEnumerable<Venda> resultado = service.GetAll();

            resultado.Should().NotBeNull();
            _mockRepository.Verify(repository => repository.GetAll());
        }

        [Test]
        public void VendaService_Delete_ShouldBeOk()
        {
            Venda modelo = ObjectMotherVenda.getValidVenda();
            modelo.Id = 1;

            _mockRepository.Setup(m => m.Delete(modelo));


            VendaService service = new VendaService(_mockRepository.Object);

            service.Delete(modelo);

            _mockRepository.Verify(repository => repository.Delete(modelo));
        }


        [Test]
        public void VendaService_Add_ShouldBeFail()
        {

            Venda modelo = ObjectMotherVenda.getValidVenda();
            modelo.produtoVenda.DataValidade = DateTime.Now.AddDays(-9);

            VendaService service = new VendaService(_mockRepository.Object);

            Action comparison = () => service.Save(modelo);

            comparison.Should().Throw<ValidadeException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void VendaService_Update_Invalid_Id_ShouldBeFail()
        {

            Venda modelo = ObjectMotherVenda.getValidVenda();
            modelo.Id = 0;

            VendaService service = new VendaService(_mockRepository.Object);

            Action comparison = () => service.Update(modelo);

            comparison.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }

        [Test]
        public void PostService_Get_Invalid_Id_ShouldBeFail()
        {

            VendaService service = new VendaService(_mockRepository.Object);
            // Fim Cenario

            //Executa
            Action comparison = () => service.Get(0);

            //Saída
            comparison.Should().Throw<IdentifierUndefinedException>();
            _mockRepository.VerifyNoOtherCalls();
        }
    }
}

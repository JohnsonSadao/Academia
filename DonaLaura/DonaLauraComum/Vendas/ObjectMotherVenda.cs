using DonaLaura.Domain.Modelo.Vendas;
using DonaLauraComum.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLauraComum.Vendas
{
    public static class ObjectMotherVenda
    {
        public static Venda getValidVenda()
        {
            Venda venda = new Venda();
            venda.produtoVenda = ObjectMotherProduto.getValidProduto();
            venda.produtoVenda.Id = 1;
            venda.cliente = "Pedro";
            venda.quantidade = 1;
            return venda;
        }
    }
}

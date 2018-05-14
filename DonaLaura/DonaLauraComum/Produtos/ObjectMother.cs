using DonaLaura.Domain.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLauraComum.Produtos
{
    public static class ObjectMother
    {
        public static Produto ObterProdutoValido()
        {
            Produto produto = new Produto();
            produto.Nome = "Arroz";
            produto.PrecoCusto = 2.90;
            produto.PrecoVenda = 3.90;
            produto.Disponibilidade = true;
            produto.DataFabricacao = DateTime.Now;
            produto.DataValidade = DateTime.Now.AddDays(49);
            
            return produto;
        }

       
    }
}

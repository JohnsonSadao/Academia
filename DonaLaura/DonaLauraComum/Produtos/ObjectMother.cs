using DonaLaura.Domain.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLauraComum.Produtos
{
    public class ObjectMother
    {
        public Produto ObterProdutoValido()
        {
            Produto produto = new Produto();
            produto.nome = "Arroz";
            produto.precoCusto = 2.90;
            produto.precoVenda = 3.90;
            produto.disp = true;
            produto.dataFabricacao = DateTime.Now;
            produto.dataValidade = DateTime.Now + TimeSpan.FromDays(80);
            
            return produto;
        }
    }
}

using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Exceptions.Vendas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Modelo.Vendas
{
    public class Venda : Entidade
    {
        public Produto produtoVenda { get; set; }
        public string cliente { get; set; }
        public int quantidade { get; set; }
        public double lucro
        {
            get
            {
                return (produtoVenda.PrecoVenda - produtoVenda.PrecoCusto) * quantidade;
            }
        }

        
        public override void Validate()
        {
           if(produtoVenda.DataValidade < DateTime.Now)
                throw new ValidadeException();
            if (produtoVenda.Disponibilidade == false)
                throw new DisponibilidadeException();

        }


    }
}

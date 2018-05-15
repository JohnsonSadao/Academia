using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Exceptions.Produto
{
    public class CustoException: Exception
    {
        public CustoException() : base("O preço de custo deve ser menor que o preço de venda")
        {
        }
    }
}
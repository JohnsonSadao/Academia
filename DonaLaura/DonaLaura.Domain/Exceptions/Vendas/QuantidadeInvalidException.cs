
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Exceptions.Vendas
{
    class QuantidadeInvalidException: Exception
    {
        public QuantidadeInvalidException() : base("Quantidade deve ser maior que 0")
        {
        }
    }
}

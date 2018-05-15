using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Exceptions.Vendas
{
    public class DisponibilidadeException : Exception
    {
        public DisponibilidadeException() : base("Produto não disponivel")
        {
        }
    }
}

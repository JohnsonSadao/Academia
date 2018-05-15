using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Exceptions
{
    public class ValidadeException: Exception
    {
        public ValidadeException() : base("Produto fora do prazo de validade")
        {
        }
    }
}

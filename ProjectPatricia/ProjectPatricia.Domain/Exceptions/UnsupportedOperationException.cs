using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Domain.Exceptions
{
    public class UnsupportedOperationException : BusinessException
    {
        public UnsupportedOperationException() : base("Operação não suportada")
        {

        }
    }
}

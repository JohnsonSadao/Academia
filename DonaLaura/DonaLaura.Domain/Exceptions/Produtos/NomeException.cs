using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Exceptions
{
    public class NomeException : Exception
    {
         public NomeException() : base("Nome deve ser maior que 4 caracteres")
        {
        }


    }
}

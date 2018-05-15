using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Exceptions.Comum
{
    public class IdentifierUndefinedException: Exception
    {
        public IdentifierUndefinedException() : base("Id deve ser valido")
        {
        }
    }
}

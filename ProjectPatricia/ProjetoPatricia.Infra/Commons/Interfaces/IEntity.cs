using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPatricia.Infra.Commons.Interfaces
{
    public interface IEntity
    {
        long Id { get; set; }

        void Validate();
    }
}

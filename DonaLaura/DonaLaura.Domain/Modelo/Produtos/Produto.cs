using DonaLaura.Domain.Exceptions;
using DonaLaura.Domain.Exceptions.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Modelo
{
    public class Produto : Entidade
    {
        public string Nome { get; set; }
        public double PrecoVenda { get; set; }
        public double PrecoCusto { get; set; }
        public bool Disponibilidade { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }

        public override void Validate()
        {
            if (Nome.Length < 4)
                throw new NomeException();
            if (DataFabricacao > DataValidade)
                throw new DataValidadeException();
            if (PrecoVenda < PrecoCusto)
                throw new CustoException();
        }
    }
}

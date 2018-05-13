using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Domain.Modelo
{
    public class Produto : Entidade
    {
        public string nome { get; set; }
        public double precoVenda { get; set; }
        public double precoCusto { get; set; }
        public bool disp { get; set; }
        public DateTime dataFabricacao { get; set; }
        public DateTime dataValidade { get; set; }

        public override void Validacoes()
        {
            throw new NotImplementedException();
        }
    }
}

using DonaLaura.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLauraComum.Base
{

    public static class BaseSqlTest
    {
        private const string RECREATE_PRODUTO_TABLE = "TRUNCATE TABLE [dbo].[TBProduto] ";
        private const string INSERT_PRODUTO = "INSERT INTO TBProduto(Nome,PrecoVenda,PrecoCusto,Disponibilidade,DataFabricacao,DataValidade) VALUES ('Post de Teste', GETDATE())";

        public static void SeedDatabase()
        {
            Db.Update(RECREATE_PRODUTO_TABLE);
            Db.Update(INSERT_PRODUTO);
        }
    }

}

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
        private const string RECREATE_PRODUTO_TABLE = "TRUNCATE TABLE [dbo].[TBVenda]; DELETE FROM TBProduto DBCC CHECKIDENT('DBDonaLaura.Dbo.TBProduto',RESEED,0)";
        private const string INSERT_PRODUTO = "INSERT INTO TBProduto(Nome,PrecoVenda,PrecoCusto,Disponibilidade,DataFabricacao,DataValidade) VALUES ('Arroz', 2.90, 1.90, 1, '2018-07-06', '2018-08-06')";

        public static void SeedDatabase()
        {
            Db.Update(RECREATE_PRODUTO_TABLE);
            Db.Update(INSERT_PRODUTO);
        }
    }

}

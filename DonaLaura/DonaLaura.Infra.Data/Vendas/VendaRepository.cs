using DonaLaura.Domain.Exceptions.Comum;
using DonaLaura.Domain.Modelo;
using DonaLaura.Domain.Modelo.Vendas;
using DonaLaura.Infra.Data.Produtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Infra.Data.Vendas
{
    public class VendaRepository : IVendaRepository
    {
        private ProdutoRepository _produtoRepository;
        
        public void Delete(Venda venda)
        {
            if (venda.Id < 1)
                throw new IdentifierUndefinedException();
            string sql = "DELETE FROM TBVenda WHERE Id = @Id";
            Db.Delete(sql, new object[] { "@Id", venda.Id });
        }

        public Venda Get(long id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();
            string sql = @"SELECT
                V.Id,
                V.NomeCliente,
                V.Quantidade,
                V.ProdutoId,
                P.Nome,
			    P.PrecoVenda,
			    P.PrecoCusto,
			    P.Disponibilidade,
			    P.DataFabricacao,
			    P.DataValidade		
            FROM
                TBVenda AS V
				INNER JOIN
				TBProduto AS P ON P.Id = V.ProdutoId
                WHERE V.Id = @Id";
            return Db.Get(sql, Make, new object[] { "@Id", id });
        }

        public IEnumerable<Venda> GetAll()
        {
            string sql = @"SELECT
                V.Id,
                V.NomeCliente,
                V.Quantidade,
                V.ProdutoId,
                P.Nome,
			    P.PrecoVenda,
			    P.PrecoCusto,
			    P.Disponibilidade,
			    P.DataFabricacao,
			    P.DataValidade		
            FROM
                TBVenda AS V
				INNER JOIN
				TBProduto AS P ON P.Id = V.ProdutoId";
            return Db.GetAll(sql,Make);
        }

        public Venda Save(Venda venda)
        {
            if (venda.Id < 1)
                throw new IdentifierUndefinedException();
            venda.Validate();
            string sql = "INSERT INTO TBVenda(ProdutoId,NomeCliente,Quantidade) VALUES (@ProdutoId, @NomeCliente, @Quantidade)";
            venda.Id = Db.Insert(sql, Take(venda, false));

            return venda;

        }

        public Venda Update(Venda venda)
        {

            if (venda.Id < 1)
                throw new IdentifierUndefinedException();
            venda.Validate();
            string sql = "UPDATE TBVenda SET NomeCliente = @NomeCliente, ProdutoId = @ProdutoId, Quantidade = @Quantidade WHERE Id = @Id"; 
            Db.Update(sql, Take(venda));

            return venda;
        }

        /// <summary>
        /// Cria um objeto Customer baseado no DataReader.
        /// </summary>
        private static Func<IDataReader, Venda> Make = reader =>
          new Venda
          {
              Id = Convert.ToInt64(reader["Id"]),
              cliente = Convert.ToString(reader["NomeCliente"]),
              quantidade = Convert.ToInt32(reader["Quantidade"]),
              produtoVenda = new Produto
              {
                  Id = Convert.ToInt64(reader["ProdutoId"]),
                  Nome = reader["Nome"].ToString(),
                  PrecoCusto = Convert.ToDouble(reader["PrecoCusto"]),
                  PrecoVenda = Convert.ToDouble(reader["PrecoVenda"]),
                  Disponibilidade = Convert.ToBoolean(reader["Disponibilidade"]),
                  DataFabricacao = Convert.ToDateTime(reader["DataFabricacao"]),
                  DataValidade = Convert.ToDateTime(reader["DataValidade"])
              }
          };


        /// <summary>
        /// Cria a lista de parametros do objeto Post para passar para o comando Sql
        /// </summary>
        /// <param name="post">Post.</param>
        /// <returns>lista de parametros</returns>
        private object[] Take(Venda venda, bool hasId = true)
        {
            object[] parametros = null;

            if (hasId)
            {
                parametros = new object[]
                {

                "@Id", venda.Id,
                "@NomeCliente", venda.cliente,
                "@Quantidade", venda.quantidade,
                "@ProdutoId",venda.produtoVenda.Id,
                };
            }
            else
            {
                parametros = new object[]
                {
                "@NomeCliente", venda.cliente,
                "@Quantidade", venda.quantidade,
                "@ProdutoId",venda.produtoVenda.Id,
                };
            }

            return parametros;
        }
    }
}

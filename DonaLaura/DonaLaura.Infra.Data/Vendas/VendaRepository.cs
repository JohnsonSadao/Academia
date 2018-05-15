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
            throw new NotImplementedException();
        }

        public Venda Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Venda> GetAll()
        {
            string sql = "SELECT * FROM TBVenda";
            return Db.GetAll(sql,Make);
        }

        public Venda Save(Venda venda)
        {
            string sql = "INSERT INTO TBVenda(ProdutoId,NomeCliente,Quantidade) VALUES (@ProdutoId, @NomeCliente, @Quantidade)";
            venda.Id = Db.Insert(sql, Take(venda, false));

            return venda;

        }

        public Venda Update(Venda venda)
        {
            throw new NotImplementedException();
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

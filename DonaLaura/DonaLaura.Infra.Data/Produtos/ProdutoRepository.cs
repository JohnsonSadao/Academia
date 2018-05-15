using DonaLaura.Domain.Exceptions.Comum;
using DonaLaura.Domain.Modelo;
using DonaLaura.Infra.Data.Produtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonaLaura.Infra.Data.Produtos
{
    public class ProdutoRepository : IProdutoRepository
    {
        public Produto Save(Produto produto)
        {
            produto.Validate();

            string sql = "INSERT INTO TBProduto(Nome,PrecoVenda,PrecoCusto,Disponibilidade, DataFabricacao,DataValidade) " +
                "VALUES (@Nome,@PrecoVenda,@PrecoCusto,@Disponibilidade,@DataFabricacao,@DataValidade)";
            produto.Id = Db.Insert(sql, Take(produto,false));

            return produto;
        }


        public Produto Update(Produto produto)
        {
            produto.Validate();
            if (produto.Id < 1)
                throw new IdentifierUndefinedException();
            string sql = "UPDATE TBProduto SET Nome = @Nome, PrecoVenda = @PrecoVenda, " +
                 "PrecoCusto = @PrecoCusto,Disponibilidade = @Disponibilidade," +
                 "DataFabricacao = @DataFabricacao, DataValidade = @DataValidade" +
                 " WHERE Id = @Id";
            Db.Update(sql, Take(produto));

            return produto;
        }

        public Produto Get(long id)
        {
            if (id < 1)
                throw new IdentifierUndefinedException();
            string sql = "SELECT *FROM TBProduto WHERE Id = @Id";
            return Db.Get<Produto>(sql, Make, new object[] { "@Id", id });
        }

        public IEnumerable<Produto> GetAll()
        {
            string sql = "SELECT * FROM TBProduto";
            return Db.GetAll<Produto>(sql,Make);
        }

        public void Delete(Produto produto)
        {
            if (produto.Id < 1)
                throw new IdentifierUndefinedException();
            string sql = "DELETE FROM TBProduto WHERE Id=@Id";
            Db.Delete(sql, new object[] { "@Id", produto.Id });
        }

        /// <summary>
        /// Cria um objeto Customer baseado no DataReader.
        /// </summary>
        private static Func<IDataReader, Produto> Make = reader =>
          new Produto
          {
              Id = Convert.ToInt64(reader["Id"]),
              Nome = reader["Nome"].ToString(),
              PrecoCusto = Convert.ToDouble(reader["PrecoCusto"]),
              PrecoVenda = Convert.ToDouble(reader["PrecoVenda"]),
              Disponibilidade = Convert.ToBoolean(reader["Disponibilidade"]),
              DataFabricacao = Convert.ToDateTime(reader["DataFabricacao"]),
              DataValidade = Convert.ToDateTime(reader["DataValidade"])

          };


        /// <summary>
        /// Cria a lista de parametros do objeto Post para passar para o comando Sql
        /// </summary>
        /// <param name="post">Post.</param>
        /// <returns>lista de parametros</returns>
        private object[] Take(Produto produto, bool hasId = true)
        {
            object[] parametros = null;

            if (hasId)
            {
                parametros = new object[]
                {

                "@Id", produto.Id,
                "@Nome", produto.Nome,
                "@PrecoVenda", produto.PrecoVenda,
                "@PrecoCusto", produto.PrecoCusto,
                "@Disponibilidade", produto.Disponibilidade,
                "@DataFabricacao", produto.DataFabricacao,
                "@DataValidade", produto.DataValidade,
                };
            }
            else
            {
                parametros = new object[]
                {
                "@Nome", produto.Nome,
                "@PrecoVenda", produto.PrecoVenda,
                "@PrecoCusto", produto.PrecoCusto,
                "@Disponibilidade", produto.Disponibilidade,
                "@DataFabricacao", produto.DataFabricacao,
                "@DataValidade", produto.DataValidade,  
                };
            }

            return parametros;
        }

        public bool RegisterWithDependency(int id)
        {
            throw new NotImplementedException();
        }
    }
}

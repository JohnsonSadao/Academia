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
        #region QUERYS

        private const string SqlInsereProduto =
            @"INSERT INTO TBProduto
                (Nome,
                 PrecoVenda,
                 PrecoCusto,
                 Disponibilidade,
                 DataFabricacao,
                 DataValidade   
                 )
            VALUES
                ({0}Nome,
                 {0}PrecoVenda,
                 {0}PrecoCusto,
                 {0}Disponibilidade,
                 {0}DataFabricacao,
                 {0}DataValidade)";

        private const string SqlEditaProduto =
            @"UPDATE TBDISCIPLINA
                SET
                    Nome = {0}Nome,
                    PrecoVenda = {0}Precovenda,
                    PrecoCusto = {0}PrecoCusto,
                    Disponibilidade = {0}Disponibilidade,
                    DataFabricacao = {0}DataFabricacao,
                    DataValidade =   {0}DataValidade

                WHERE Id = {0}Id";

        private const string SqlDeletaProduto =
           @"DELETE FROM TBDISCIPLINA
                WHERE Id = {0}Id";

        private const string SqlSelecionaTodosProdutos =
           @"SELECT
                Id,
                Nome
            FROM
                TBProduto";

        private const string SqlSelecionaProdutoPorId =
           @"SELECT
                Id,
                Nome
            FROM
                TBProduto
            WHERE Id = {0}Id";

        private const string SqlVerificaDependencia =
           @"SELECT
                Nome
            FROM
                TBVenda
            WHERE ProdutoId = {0}Id";

        #endregion QUERYS
        public Produto Adicionar(Produto novoProduto)
        {
            novoProduto.Id = Db.Insert(SqlInsereProduto, GetParametros(novoProduto));

            return novoProduto;
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public Produto Editar(Produto entidadeEditada)
        {
            throw new NotImplementedException();
        }

        public bool Existe(string nome)
        {
            throw new NotImplementedException();
        }

        public bool RegistroComDependencia(int id)
        {
            throw new NotImplementedException();
        }

        public Produto SelecionaPorId(int id)
        {
            throw new NotImplementedException();
        }

        private Dictionary<string, object> GetParametros(Produto produto)
        {
            return new Dictionary<string, object>
            {
                { "Id", produto.Id },
                { "Nome", produto.Nome },
                { "PrecoVenda", produto.PrecoVenda },
                { "PrecoCusto", produto.PrecoCusto },
                { "Disponibilidade", produto.Disponibilidade },
                { "DataFabricacao", produto.DataFabricacao },
                { "DataValidade", produto.DataValidade }
            };
        }

        public List<Produto> SelecionaTudo()
        {
            return Db.GetAll(SqlSelecionaTodosProdutos, Converter);
        }

        private static Func<IDataReader, Produto> Converter = reader =>
        new Produto
            {
            Id = Convert.ToInt32(reader["Id"]),
            Nome = Convert.ToString(reader["Nome"]),
            PrecoVenda = Convert.ToDouble(reader["PrecoVenda"]),
            PrecoCusto = Convert.ToDouble(reader["PrecoCusto"]),
            Disponibilidade = Convert.ToBoolean(reader["Disponibilidade"]),
            DataFabricacao = Convert.ToDateTime(reader["DataFabricacao"]),
            DataValidade = Convert.ToDateTime(reader["DataValidade"]),
            };
    }
}

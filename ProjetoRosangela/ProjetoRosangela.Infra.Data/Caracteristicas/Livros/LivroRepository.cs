using ProjetoRosangela.Domain.Caracteristicas.Excecoes;
using ProjetoRosangela.Domain.Caracteristicas.Livros;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRosangela.Infra.Data.Caracteristicas.Livros
{
    public class LivroRepository : ILivroRepository
    {
        public Livro Atualizar(Livro livro)
        {
            if (livro.Id < 1)
                throw new IdentificadorIndefinidoException();
            string sql = "UPDATE TBLivro SET Autor = @Autor, Titulo = @Titulo, Tema = @Tema," +
                "Volume = @Volume, DataPublicacao = @DataPublicacao, Disponibilidade= @Disponibilidade" +
                " WHERE Id = @Id";
            Db.Update(sql, Take(livro));
            return livro;

        }

        public void Delete(Livro livro)
        {
            if (livro.Id < 1)
                throw new IdentificadorIndefinidoException();
            string sql = "DELETE FROM TBLivro WHERE Id = @Id";
            Db.Delete(sql, new object[] { "@Id", livro.Id });
        }

        public Livro Obter(long id)
        {
            if (id < 1)
                throw new IdentificadorIndefinidoException();
            string sql = "SELECT * FROM TBLivro WHERE Id = @Id";
            return Db.Get(sql, Make, new object[] { "@Id", id });
        }

        public IEnumerable<Livro> ObterTodos()
        {
            string sql = "SELECT * FROM TBLivro";
            return Db.GetAll(sql, Make);
        }

        public Livro Salvar(Livro livro)
        {
            livro.Validar();
            string sql = "INSERT INTO TBLivro(Titulo,Autor,Tema,Volume,DataPublicacao,Disponibilidade) VALUES (@Titulo,@Autor,@Tema,@Volume,@DataPublicacao,@Disponibilidade)";
            livro.Id = Db.Insert(sql, Take(livro, false));
            return livro;
        }

        /// <summary>
        /// Cria um objeto Customer baseado no DataReader.
        /// </summary>
        private static Func<IDataReader, Livro> Make = reader =>
          new Livro
          {
              Id = Convert.ToInt64(reader["Id"]),
              Autor = reader["Autor"].ToString(),
              Titulo = reader["Titulo"].ToString(),
              Tema = reader["Tema"].ToString(),
              Volume = Convert.ToInt32(reader["Volume"]),
              DataPublicacao = Convert.ToDateTime(reader["DataPublicacao"]),
              Disponibilidade = Convert.ToBoolean(reader["Disponibilidade"]),
          };


        /// <summary>
        /// Cria a lista de parametros do objeto Post para passar para o comando Sql
        /// </summary>
        /// <param name="post">Post.</param>
        /// <returns>lista de parametros</returns>
        private object[] Take(Livro livro, bool hasId = true)
        {
            object[] parametros = null;

            if (hasId)
            {
                parametros = new object[]
                {

                "@Id", livro.Id,
                "@Autor", livro.Autor,
                "@Titulo", livro.Titulo,
                "@Tema", livro.Tema,
                "@Volume", livro.Volume,
                "@DataPublicacao", livro.DataPublicacao,
                "@Disponibilidade", livro.Disponibilidade,
                };
            }
            else
            {
                parametros = new object[]
                {
                "@Autor", livro.Autor,
                "@Titulo", livro.Titulo,
                "@Tema", livro.Tema,
                "@Volume", livro.Volume,
                "@DataPublicacao", livro.DataPublicacao,
                "@Disponibilidade", livro.Disponibilidade,
                };
            }

            return parametros;
        }
    }
}

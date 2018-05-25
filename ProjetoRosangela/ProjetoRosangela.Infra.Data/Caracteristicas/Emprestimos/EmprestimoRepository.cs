using ProjetoRosangela.Domain.Caracteristicas.Emprestimos;
using ProjetoRosangela.Domain.Caracteristicas.Excecoes;
using ProjetoRosangela.Domain.Caracteristicas.Livros;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRosangela.Infra.Data.Caracteristicas.Emprestimos
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        public Emprestimo Atualizar(Emprestimo emprestimo)
        {
            if (emprestimo.Id < 1)
                throw new IdentificadorIndefinidoException();
            string sql = "UPDATE TBEmprestimos SET Cliente = @Cliente, LivroId= @LivroId, DataDevolucao = @DataDevolucao" +
                "  WHERE Id = @Id ";
            Db.Update(sql,Take(emprestimo));
            return emprestimo;
        }

        public void Delete(Emprestimo emprestimo)
        {
            if (emprestimo.Id < 1)
                throw new IdentificadorIndefinidoException();
            string sql = "DELETE FROM TBEmprestimos WHERE Id = @Id";
            Db.Delete(sql,new object[] { "@Id", emprestimo.Id});
        }

        public Emprestimo Obter(long id)
        {
            if (id < 1)
                throw new IdentificadorIndefinidoException();
            string sql = "SELECT E.Id, E.Cliente,E.DataDevolucao,E.LivroId," +
                "L.Autor,L.Titulo,L.Tema,L.DataPublicacao,L.Volume,L.Disponibilidade " +
                "FROM TBEmprestimos AS E INNER JOIN TBLivro AS L ON L.Id= E.LivroId WHERE E.Id = @Id";
            return Db.Get(sql,Make, new object[] { "@Id",id});

        }

        public IEnumerable<Emprestimo> ObterTodos()
        {
            string sql = "SELECT E.Id, E.Cliente,E.DataDevolucao,E.LivroId," +
                "L.Autor,L.Titulo,L.Tema,L.DataPublicacao,L.Volume,L.Disponibilidade " +
                "FROM TBEmprestimos AS E INNER JOIN TBLivro AS L ON L.Id= E.LivroId";
            List<Emprestimo> emprestimos = Db.GetAll(sql, Make);
            return emprestimos;
        }

        public Emprestimo Salvar(Emprestimo emprestimo)
        {
            emprestimo.Validar();
            string sql = "INSERT INTO TBEmprestimos(Cliente,LivroId,DataDevolucao) VALUES (@Cliente,@LivroId,@DataDevolucao)";
            emprestimo.Id =  Db.Insert(sql, Take(emprestimo, false));
            return emprestimo;
        }


        /// <summary>
        /// Cria um objeto Customer baseado no DataReader.
        /// </summary>
        private static Func<IDataReader, Emprestimo> Make = reader =>
           new Emprestimo
           {
               Id = Convert.ToInt64(reader["Id"]),
               DataDevolucao = Convert.ToDateTime(reader["DataDevolucao"]),
               Cliente = reader["Cliente"].ToString(),
               Livro = new Livro
               {
                   Id = Convert.ToInt64(reader["LivroId"]),
                   Autor = reader["Autor"].ToString(),
                   Tema = reader["Tema"].ToString(),
                   Titulo = reader["Titulo"].ToString(),
                   Volume = Convert.ToInt32(reader["Volume"]),
                   DataPublicacao = Convert.ToDateTime(reader["DataPublicacao"]),
                   Disponibilidade = Convert.ToBoolean(reader["Disponibilidade"])
              }
          };


        /// <summary>
        /// Cria a lista de parametros do objeto Post para passar para o comando Sql
        /// </summary>
        /// <param name="post">Post.</param>
        /// <returns>lista de parametros</returns>
        private object[] Take(Emprestimo emprestimo, bool hasId = true)
        {
            object[] parametros = null;

            if (hasId)
            {
                parametros = new object[]
                {

                "@Id", emprestimo.Id,
                "@Cliente", emprestimo.Cliente,
                "@DataDevolucao", emprestimo.DataDevolucao,
                "@LivroId", emprestimo.Livro.Id
                };
            }
            else
            {
                parametros = new object[]
                {
                "@Cliente", emprestimo.Cliente,
                "@DataDevolucao", emprestimo.DataDevolucao,
                "@LivroId", emprestimo.Livro.Id
                };
            }

            return parametros;
        }
    }
}

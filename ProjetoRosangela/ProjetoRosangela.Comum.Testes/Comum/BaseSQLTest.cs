using ProjetoRosangela.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRosangela.Comum.Testes.Comum
{
    public class BaseSQLTest
    {
        private const string RECREATE_TABLES = "TRUNCATE TABLE [dbo].[TBEmprestimos]; DELETE FROM TBLivro DBCC CHECKIDENT('DBRosangela.Dbo.TBLivro',RESEED,0)";
        private const string INSERT_LIVRO = "INSERT INTO TBLivro(Titulo,Autor,Tema,Volume,DataPublicacao,Disponibilidade) VALUES ('O Cortiço', 'Aluisio Azevedo', 'Drama',2, '2018-07-06', 1)";
        private const string INSERT_EMPRESTIMO = "INSERT INTO TBEmprestimos(Cliente,LivroId,DataDevolucao) VALUES ('Pedro', 1,'2018-07-06')";

        public static void SeedDatabase()
        {
            Db.Update(RECREATE_TABLES);
            Db.Update(INSERT_LIVRO);
            Db.Update(INSERT_EMPRESTIMO);
        }
    }
}

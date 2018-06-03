using ProjetoPatricia.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Common.Tests.Common
{
    public class BaseSQLTest
    {
        private const string RECREATE_TABLES = @"TRUNCATE TABLE [dbo].[TBAllocation];
                                                DELETE FROM TBRoom DBCC CHECKIDENT('DBPatricia.Dbo.TBRoom',RESEED,0)
                                                DELETE FROM TBEmployee DBCC CHECKIDENT('DBPatricia.Dbo.TBEmployee',RESEED,0)";
        private const string INSERT_EMPLOYEE = "INSERT INTO TBEmployee(NameEmployee,Branch,Position) VALUES ('Pedro', 'NDDPrint', 'Programador')";
        private const string INSERT_ROOM = "INSERT INTO TBRoom(NameRoom,Accents) VALUES ('Sala de Treinamento',35)";
        private const string INSERT_ALLOCATION = "INSERT INTO TBAllocation(StartHour,EndHour,RoomId,EmployeeId) VALUES ('2018-05-23T14:25:00','2018-05-23T15:00:00',1,1)";

        public static void SeedDatabase()
        {
            Db.Update(RECREATE_TABLES);
            Db.Update(INSERT_EMPLOYEE);
            Db.Update(INSERT_ROOM);
            Db.Update(INSERT_ALLOCATION);
        }
    }

}

using ProjectPatricia.Domain.Features.Employees;
using ProjectPatricia.Domain.Features.Rooms;
using ProjetoPatricia.Infra.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Domain.Features.Allocations
{
    public class Allocation : IEntity
    {
        public long Id { get; set; }
        public DateTime StartHour { get; set;}
        public DateTime EndHour { get; set;}
        public Employee Employee { get; set; }
        public Room Room { get; set; }

        public void Validate()
        {
            if (StartHour > EndHour)
                throw new AllocationEndHourEarlyThanStartException();
            if (StartHour < DateTime.Now)
                throw new AllocationPastHourInvalid();
            if (Employee == null)
                throw new AllocationNullEmployeeException();
            if (Room == null)
                throw new AllocationNullRoomException();
            Room.Validate();
            Employee.Validate();
        }
    }
}

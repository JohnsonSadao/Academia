using ProjectPatricia.Domain.Features.Allocations;
using ProjectPatricia.Domain.Features.Employees;
using ProjectPatricia.Domain.Features.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Common.Tests.Features
{
    public partial class ObjectMother
    {
        public static Allocation GetAllocation(Employee employee, Room room)
        {
            return new Allocation()
            {
                Employee = employee,
                Room = room,
                StartHour = DateTime.Now.AddHours(1),
                EndHour = DateTime.Now.AddHours(4)
            };
        }

        public static Allocation GetInvalidPastStartHourAllocation(Employee employee, Room room)
        {
            return new Allocation()
            {
                Employee = employee,
                Room = room,
                StartHour = DateTime.Now.AddHours(-4),
                EndHour = DateTime.Now.AddHours(4)
            };
        }

        public static Allocation GetInvalidEndHourAllocation(Employee employee, Room room)
        {
            return new Allocation()
            {
                Employee = employee,
                Room = room,
                StartHour = DateTime.Now,
                EndHour = DateTime.Now.AddHours(-4)
            };
        }

    }
}

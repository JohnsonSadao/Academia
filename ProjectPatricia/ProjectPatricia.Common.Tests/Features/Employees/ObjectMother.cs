using ProjectPatricia.Domain.Features.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Common.Tests.Features
{
    public static class ObjectMother
    {
        public static Employee GetEmployee()
        {
            Employee employee = new Employee()
            {
                Name = "Patricia",
                Branch = "NDDMarketing",
                Position = "Secretaria"
            };
            return employee;
        }

        public static Employee GetInvalidNameEmployee()
        {
            Employee employee = new Employee()
            {
                Name = "",
                Branch = "NDDMarketing",
                Position = "Secretaria"
            };
            return employee;
        }

        public static Employee GetInvalidBranchEmployee()
        {
            Employee employee = new Employee()
            {
                Name = "Patricia",
                Branch = "",
                Position = "Secretaria"
            };
            return employee;
        }

        public static Employee GetInvalidPositionEmployee()
        {
            Employee employee = new Employee()
            {
                Name = "Patricia",
                Branch = "NddMarketing",
                Position = ""
            };
            return employee;
        }
    }
}

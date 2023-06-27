using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkGroupProsecutor.Shared.Models.Participants;

namespace WorkGroupProsecutor.Tests.Services
{
    internal class DepartmentGenerator
    {
        internal static Department GenerateDepartment(string departmentIndex)
        {
            return new Department()
            {
                Id = GetRandom.Id(),
                DepartmentIndex = departmentIndex,
                DepartmentName = GetRandom.String()
            };
        }
    }
}

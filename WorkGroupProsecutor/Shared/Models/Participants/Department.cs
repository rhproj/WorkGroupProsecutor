using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkGroupProsecutor.Shared.Models.Appeal;
using WorkGroupProsecutor.Shared.Models.Base;

namespace WorkGroupProsecutor.Shared.Models.Participants
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentIndex { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<RedirectedAppealModel> RedirectedAppealRegisters { get; set; }
        public ICollection<NoSolutionAppealModel> NoSolutionAppealRegisters { get; set; }
        public ICollection<SatisfiedAppealModel> SatisfiedAppealRegisters { get; set; }
    }
}

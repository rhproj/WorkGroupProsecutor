using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkGroupProsecutor.Shared.Models.Base;

namespace WorkGroupProsecutor.Shared.Models.Appeal
{
    public class NoSolutionAppealModel : AppealRegister
    {
        public string DepartmentResolution { get; set; }
        public string DecisionBasis { get; set; }
    }
}

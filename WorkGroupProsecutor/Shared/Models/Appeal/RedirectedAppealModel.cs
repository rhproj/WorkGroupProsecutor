using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkGroupProsecutor.Shared.Models.Base;
using WorkGroupProsecutor.Shared.Models.Participants;

namespace WorkGroupProsecutor.Shared.Models.Appeal
{
    public class RedirectedAppealModel : AppealRegister
    {
        public string? RecipientAgency { get; set; }
        public string? DecisionBasis { get; set; }
    }
}

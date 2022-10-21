using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkGroupProsecutor.Shared.Models.Base;
using WorkGroupProsecutor.Shared.Models.Recipients;

namespace WorkGroupProsecutor.Shared.Models
{
    public class RedirectedAppealModel : AppealRegister
    {
        public RecipientAgency RecipientAgency { get; set; }
        public string DecisionBasis { get; set; }
    }
}

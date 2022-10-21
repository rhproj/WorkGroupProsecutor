using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkGroupProsecutor.Shared.Models.Base;

namespace WorkGroupProsecutor.Shared.Models
{
    public class SatisfiedAppealModel : AppealRegister
    {
        public string ProsecutorAction { get; set; }
        public string InvestigationResults { get; set; }
        public string RightsRestoration { get; set; }
        public string ApplicantNotification { get; set; }
    }
}

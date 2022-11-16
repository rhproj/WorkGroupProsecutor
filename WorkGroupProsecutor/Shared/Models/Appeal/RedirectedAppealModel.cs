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
        //-------public RecipientAgency RecipientAgency { get; set; }
        public string RecipientAgency { get; set; }
        public string DecisionBasis { get; set; }

        //*************************************************
        //public int Id { get; set; }
        //public string RegistrationNumber { get; set; }
        //public string ApplicantFullName { get; set; }
        ////public Department AppealClassification { get; set; } = new();
        ////public string DepartmentAssessment { get; set; }
        //public int YearInfo { get; set; }
        //public string PeriodInfo { get; set; }
        //public string District { get; set; }
    }
}

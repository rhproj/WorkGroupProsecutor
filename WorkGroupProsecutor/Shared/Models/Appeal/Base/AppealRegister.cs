using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkGroupProsecutor.Shared.Models.Participants;

namespace WorkGroupProsecutor.Shared.Models.Base
{
    public abstract class AppealRegister
    {
        public int Id { get; set; }
        public virtual string RegistrationNumber { get; set; }
        public virtual string? NadzorHyperlink { get; set; }
        public virtual string ApplicantFullName { get; set; }

        public int? DepartmentId { get; set; }
        public virtual Department? Department { get; set; }

        public virtual string? DepartmentAssessment { get; set; }
        public virtual int YearInfo { get; set; }
        public virtual string PeriodInfo { get; set; }
        public virtual string District { get; set; }

        //PARTII:
        public virtual bool? HasNoAppeals { get; set; }
        public virtual bool? IsArchived { get; set; }
    }
}

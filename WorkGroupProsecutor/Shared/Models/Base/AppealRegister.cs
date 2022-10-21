using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkGroupProsecutor.Shared.Models.Recipients;

namespace WorkGroupProsecutor.Shared.Models.Base
{
    public abstract class AppealRegister
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string ApplicantFullName { get; set; }
        public Department AppealClassification { get; set; } //possible dropdown
        public string DepartmentAssessment { get; set; }
    }
}

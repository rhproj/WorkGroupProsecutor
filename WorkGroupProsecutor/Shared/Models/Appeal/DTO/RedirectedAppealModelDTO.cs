using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkGroupProsecutor.Shared.Models.Participants;

namespace WorkGroupProsecutor.Shared.Models.Appeal.DTO
{
    public class RedirectedAppealModelDTO
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string ApplicantFullName { get; set; }

        public int? DepartmentId { get; set; }

        public string DepartmentAssessment { get; set; }
        public int YearInfo { get; set; }
        public string PeriodInfo { get; set; }
        public string District { get; set; }

        public string? RecipientAgency { get; set; }
        public string? DecisionBasis { get; set; }
    }
}

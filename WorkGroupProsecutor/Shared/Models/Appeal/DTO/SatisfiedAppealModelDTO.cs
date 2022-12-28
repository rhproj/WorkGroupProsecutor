using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkGroupProsecutor.Shared.Models.Participants;

namespace WorkGroupProsecutor.Shared.Models.Appeal.DTO
{
    public class SatisfiedAppealModelDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = $"Обязательное поле")]
        public string RegistrationNumber { get; set; }
        public string? NadzorHyperlink { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public string ApplicantFullName { get; set; }
        [Required(ErrorMessage = "Выберите характер обращения")]
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

        //Unique
        public string? ProsecutorAction { get; set; }
        public string? InvestigationResults { get; set; }
        public string? RightsRestoration { get; set; }
        public string? ApplicantNotification { get; set; }
        //

        public string? DepartmentAssessment { get; set; }

        public int YearInfo { get; set; }
        public string PeriodInfo { get; set; }
        public string District { get; set; }
    }
}

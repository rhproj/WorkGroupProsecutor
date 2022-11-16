using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkGroupProsecutor.Shared.Models.Participants;

namespace WorkGroupProsecutor.Shared.Models.Base
{
    public abstract class AppealRegister
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string ApplicantFullName { get; set; }

        //public int DepartmentId { get; set; }
        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; } = new();

        //public string DepartmentIndex { get; set; } //dropdown
        //public Department AppealClassification 
        //{
        //    get
        //    {
        //        //if (string.IsNullOrEmpty(Index)) return null;
        //        // Retrieve the object with the corresponding Id
        //        return new Department(); // << From your Venue List 
        //    }  set { }                 
        //} //= new(); 


        public string? DepartmentAssessment { get; set; }
        public int? YearInfo { get; set; }
        public string? PeriodInfo { get; set; }
        public string? District { get; set; }
    }
}

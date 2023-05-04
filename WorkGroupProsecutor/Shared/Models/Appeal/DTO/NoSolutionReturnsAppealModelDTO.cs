using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkGroupProsecutor.Shared.Models.Participants;

namespace WorkGroupProsecutor.Shared.Models.Appeal.DTO
{
    public class NoSolutionReturnsAppealModelDTO : NoSolutionAppealModelDTO
    {
        [StringLength(5, MinimumLength = 5, ErrorMessage = "формат даты: день.месяц (01.01)")]
        public string PeriodInfo { get; set; }
    }
}

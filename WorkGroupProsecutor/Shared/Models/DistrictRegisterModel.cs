using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkGroupProsecutor.Shared.Models.Participants;

namespace WorkGroupProsecutor.Shared.Models
{
    public class DistrictRegisterModel
    {
        public int Id { get; set; }
        public District District { get; set; } //string

        //will be passed further:
        public string DateInfo { get; set; }
        public int YearInfo { get; set; }
        public int QuarterInfo { get; set; }
        public DateTime EntryDate { get; set; }
    }
}

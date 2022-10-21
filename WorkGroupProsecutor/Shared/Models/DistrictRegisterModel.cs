using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkGroupProsecutor.Shared.Models
{
    public class DistrictRegisterModel
    {
        public int Id { get; set; }
        public string District { get; set; }

        //will be passed further:
        public int YearInfo { get; set; }
        public int QuarterInfo { get; set; }
        public DateTime EntryDate { get; set; }
    }
}

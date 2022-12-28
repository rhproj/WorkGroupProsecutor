using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkGroupProsecutor.Shared.Models.RecordDetails
{
    public static class ReferencePeriod
    {
        public static readonly Dictionary<string, string> Quarters = new()
        {
            { "1", "I - квартал" },
            { "2", "II - квартал"},
            { "3", "III - квартал"},
            { "4", "IV - квартал"}
        };
    
    }
}

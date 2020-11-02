using System;
using System.Collections.Generic;
using System.Text;

namespace Covid.Business.Model
{
    public class StatesData
    {
        public string StateAbbreviation { get; set; }

        public string StateName { get; set; }

        public List<DaysData> AllDaysData { get; set; }

        public DateTime?[] Dates { get; set; }

        public double? MostRecentTotalCases { get; set; }

        public double? ProjectedTotalCases { get; set; }

        public double? MostRecentNewCases { get; set; }

        public double? MostRecentTotalDeaths { get; set; }

        public double? ProjectedTotalDeaths { get; set; }

        public double? MostRecentNewDeaths { get; set; }

  
    }
}

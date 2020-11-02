using System;
using System.Collections.Generic;
using System.Text;

namespace Covid.Business
{
    public class DaysData
    {
        public DateTime? TheDate { get; set; }

        public double? TotalCases { get; set; }

        public double? NewCases { get; set; }

        public double? NewCasesSlidingAverage { get; set; }

 

        public double? TotalDeaths { get; set; }

        public double? NewDeaths { get; set; }

        public double? NewDeathsSlidingAverage { get; set; }

 
    }
}

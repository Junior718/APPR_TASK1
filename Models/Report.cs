using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APPR_TASK1.Models
{
    public class Report
    {
        public int id { get; set; }
        public double totalMonetaryDonationsReceived { get; set; }
        public int totalNumberOfGoodsReceived { get; set; }


        public Report()
        {
        }
    }
}

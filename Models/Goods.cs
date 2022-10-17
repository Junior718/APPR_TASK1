using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APPR_TASK1.Models
{
    public class Goods
    {
        [Key]
        public int ID { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public Disaster Type { get; set; }
    }
}

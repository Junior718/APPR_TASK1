using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APPR_TASK1.Models
{
    public class Money
    {
        [Key]
        public int ID { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
   

    }
}

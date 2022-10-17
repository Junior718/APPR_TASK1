using APPR_TASK1.Models.Enum;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APPR_TASK1.Models
{
    public class Donation
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public int Items { get; set; }
        public string Description { get; set; }

        [ForeignKey("IdentityUserId")]
        public virtual IdentityUser ApplicationUser { get; set; }
    }
}

using APPR_TASK1.Controllers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APPR_TASK1.Models
{
    public class Disaster
    {
        [Key]
        public int ID { get; set; }
        public DateTime startdate { get; set; }
        public DateTime endtdate { get; set; }
        public Catergory Catergory { get; set; }
        public string Location { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey("IdentityUserId")]
        public virtual IdentityUser ApplicationUser { get; set; }

    }
}
        

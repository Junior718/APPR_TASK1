using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APPR_TASK1.Controllers
{
    public class Catergory
    {
        [Key]
        public int ID { get; set; }

        public string CatergoryName  { get; set; }
    }
}

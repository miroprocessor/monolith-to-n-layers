using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Customertreatments1.Models
{
  
    public class Treatment
    {
        [Column(TypeName = "nvarchar(450)")]
        public string ID { get; set; }
        public float Weight { get; set; }
        public float Height { get; set; }

        public string DailyFood { get; set; }

        public string Vitmens { get; set; }

        public string ProplemHistory { get; set; }


    }
}

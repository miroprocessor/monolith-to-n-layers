using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Customertreatments1.Models
{
    public class applicatonuserviewmodel
    {
        [Key]
        public string Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }

        public string Sex { get; set; }

        public string Nationality { get; set; }
        public string MobileNo { get; set; }
    }
}

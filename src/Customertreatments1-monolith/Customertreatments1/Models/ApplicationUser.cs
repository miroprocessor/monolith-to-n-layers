﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customertreatments1.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }

        public string Sex { get; set; }

        public string Nationality { get; set; }
        public string MobileNo { get; set; }

    }
}

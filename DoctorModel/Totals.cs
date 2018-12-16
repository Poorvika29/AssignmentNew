using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorModel
{
    public class Totals
    {
        [Key]
        public string SpecialityN { get; set; }
        public int Total { get; set; }
    }
}
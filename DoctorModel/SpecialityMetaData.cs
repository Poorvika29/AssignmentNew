using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorModel
{
    public class SpecialityMetaData
    {
     [Display(Name = "Category")]
        public string Speciality { get; set; }




    }


    [MetadataType(typeof(SpecialityMetaData))]
    public partial class tSpeciality
    {
    }
}
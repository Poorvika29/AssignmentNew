using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorModel
{

    //Part 26
    public class DoctorMetaData
    {
        [ScaffoldColumn(false)]
        //This only works when you use @Html.DisplayForModel() helper

        public int Id { get; set; }

        [Display(Name = "Doctor Name" )]
        //[DisplayAttribute(Name="Full Name")]  //Part 40
        //[DisplayName("Full Name")]
        public string Name { get; set; }
        [Required]

        [Display(Name = "Years of Experience")]
        public int WorkEx { get; set; }


       // [Required]
        [DisplayFormat(NullDisplayText = "Gender not specified")]
        public string Gender { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]

        [DataType(DataType.Currency)]                        // Part 41
        public int Fee { get; set; }
        [Required]

        [DataType(DataType.EmailAddress)]                        // Part 41

        [ReadOnly(true)]            // Part 43
        public string EmailId { get; set; }
        [Required]

        [DataType(DataType.Url)]                        // Part 41
        [UIHint("OpenInNewWindow")]                 //Part 42
        public string Website { get; set; }
        [Required]
        public Nullable<int> Speciality { get; set; }
        [Required]

        //only the date part  //Part 40
        //[DisplayFormat(DataFormatString = "{0:d}")]
        //[DisplayFormatAttribute(DataFormatString="{0:d}")]

        // 24 hour notation
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]

        // 12 hour notation with AM PM
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}")]

        [DataType(DataType.Date)]                   // Part 41
        public Nullable<System.DateTime> date { get; set; }

    }

    [MetadataType(typeof(DoctorMetaData))]
    public partial class Doctor
    {
    }
}
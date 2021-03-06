﻿using DoctorModel.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DoctorModel
{

    //Part 26
    public class DoctorMetaData
    {
        [ScaffoldColumn(false)]
        //This only works when you use @Html.DisplayForModel() helper

        public int Id { get; set; }

        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$")]
        [Display(Name = "Doctor Name" )]
        //[DisplayAttribute(Name="Full Name")]  //Part 40
        //[DisplayName("Full Name")]
        [StringLength(10, MinimumLength = 5)]   //Part 80
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

        [Range(200, 1500)]                                 //Part 81
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
        // [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        
        // [DataType(DataType.Date)]                   // Part 41

        //[Range(typeof(DateTime), "01/01/2000", "01/01/2020")]           //Part 81
        //[Range(typeof(DateTime), "01/01/2000", DateTime.Now.ToShortDateString())]               //Part 82
        [DateRange("01/01/2000")]           //Part 82
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]

        [CurrentDate(ErrorMessage = "Hire Date must be less than or equal to Today's Date")]        //Part 82
        public Nullable<System.DateTime> date { get; set; }

    }

    [MetadataType(typeof(DoctorMetaData))]
    public partial class Doctor
    {
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


// Git Commit Demo

namespace DoctorModel
{
    using System;
    using System.Collections.Generic;
    public partial class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int WorkEx { get; set; }
        public string Location { get; set; }
        public int Fee { get; set; }
        public string EmailId { get; set; }
        public string Website { get; set; }
        public Nullable<int> Speciality { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string Photo { get; set; }
        public string AlternateText { get; set; }
    
        public virtual tSpeciality tblSpeciality { get; set; }
    }
}

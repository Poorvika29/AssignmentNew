using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi.Common;

namespace WebApi.Models
{
    public class DoctorMetaData1
    {

        [Remote("IsUserNameAvailable", "Doctors", ErrorMessage = "UserName already in use.")]      //Part 89
        //[RemoteClientServer("IsUserNameAvailable", "Home", ErrorMessage= "UserName already in use")] //Part 91
        public string Name { get; set; }
    }
    [MetadataType(typeof(DoctorMetaData1))]
    public partial class Doctor
    {
    }
}
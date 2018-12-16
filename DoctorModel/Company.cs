using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorModel
{

        public class Company
        {
            private string _name;
            public Company(string name)
            {
                this._name = name;
            }

            public List<tSpeciality> Departments
            {
                get
                {
                    DoctorEntities db = new DoctorEntities();
                    return db.tSpecialities.ToList();
                }
            }

            public string CompanyName
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value;
                }
            }
        
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace License.Services.ViewModel
{
   public class LicensesVM
    {
        public int Id { get; set; }
        public int LicenseTypeID { get; set; }
        public string LicenseType { get; set; }     
        public string FullName { get; set; }
        public string LicensesDate { get; set; }
         
    }
    public class LicensesCreateVM
    {
   
        public int LicensesType { get; set; }
        public string FullName { get; set; }
        public string Surnames { get; set; }
        public DateTime LicensesDate { get; set; }

    }
    public class LicensesEditVM
    {
        public int Id { get; set; }
        public int LicensesType { get; set; }
        public string FullName { get; set; }
        public string Surnames { get; set; }
        public DateTime LicensesDate { get; set; }

    }



}

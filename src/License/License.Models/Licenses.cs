using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace License.Models
{
    [Table("Licenses")]
    public class Licenses : BaseModelWithID
    {
        [Required, StringLength(150)]
        public string FullName { get; set; }
        [Required, StringLength(150)]
        public string Surnames { get; set; }
        [Required]
        public int LicenseTypeID { get; set; }
        [Required]
        public DateTime LicensesDate { get; set; }
        public LicenseType   LicenseType { get; set; }

    }
}

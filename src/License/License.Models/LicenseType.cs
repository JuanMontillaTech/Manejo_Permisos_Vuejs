using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace License.Models
{
    [Table("LicenseType")]
    public  class LicenseType : BaseModelWithID
    {
        [Required, StringLength(150)]
        public string Name { get; set; }
        public List<Licenses>  License { get; set; }


    }
}

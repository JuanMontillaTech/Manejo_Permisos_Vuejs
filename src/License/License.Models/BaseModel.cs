using System;
using System.Collections.Generic;
using System.Text;

namespace License.Models
{
     public abstract class BaseModel
    {
        public DateTime LastModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}

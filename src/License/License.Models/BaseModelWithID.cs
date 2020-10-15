using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace License.Models
{
    public abstract class BaseModelWithID : BaseModel, IGuidAsKey
    {
        [Key]
        public int Id { get ; set ; }
    }
}

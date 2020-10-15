using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using License.Models;
using License.Models.Context;
using License.Services.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace License.Services.Implementations
{
    public  class LicenseTypeService : CrudService<LicenseType> , ILicenseTypeService
    {
        public LicenseTypeService(LicenseContext _licenseContext) : base(_licenseContext) { }
        public override async Task<List<LicenseType>> GetList()=>await _LicenseContext.LicenseType.ToListAsync();
      


    }
}

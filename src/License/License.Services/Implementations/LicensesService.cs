using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using License.Models;
using License.Models.Context;
using License.Services.Interfaces;

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace License.Services.Implementations
{
    public class LicensesService : CrudService<Licenses>, ILicenses
    {
        
        public LicensesService(LicenseContext _licenseContext) :base(_licenseContext) { }     

        public async Task<List<Licenses>> GetByList() => await _LicenseContext.Licenses.Include(x => x.LicenseType).ToListAsync();

        public async Task<Licenses> GetById(int Id) => await _LicenseContext.Licenses.FindAsync(Id);

        public async Task GetDelete(int Id)
        {
            var LicenceFound = await GetById(Id);
            _LicenseContext.Remove(LicenceFound);
            await _LicenseContext.SaveChangesAsync();
        }
    }
}

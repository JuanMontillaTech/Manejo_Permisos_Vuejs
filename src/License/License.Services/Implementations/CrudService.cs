using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using License.Services.Interfaces;
using License.Models;

namespace License.Services.Implementations
{
    public class CrudService<T> : ICrudService<T> where T : class
    {
        protected readonly Models.Context.LicenseContext _LicenseContext;
        public CrudService(Models.Context.LicenseContext licenseContext)
        {
            _LicenseContext = licenseContext;
        }
        public virtual async Task Add(T t) => await _LicenseContext.AddAsync(t);

        public virtual async Task<T> GetById(params object[] ids) => await _LicenseContext.Set<T>().FindAsync(ids);

        public virtual async Task<List<T>> GetList() => await _LicenseContext.Set<T>().ToListAsync();

        public virtual int SaveChanges() => _LicenseContext.SaveChanges();

        public virtual async Task<int> SaveChangesAsync() => await _LicenseContext.SaveChangesAsync();

        public virtual void Update(T t) => _LicenseContext.Set<T>().Update(t);
    }
}

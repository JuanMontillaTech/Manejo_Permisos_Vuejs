using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using License.Models;

using Microsoft.EntityFrameworkCore;

namespace License.Services.Interfaces
{
    public interface ICrudService<T>
    {
        Task<List<T>> GetList();
        Task<T> GetById(params object[] ids);
        Task Add(T t);
        void Update(T t);
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}

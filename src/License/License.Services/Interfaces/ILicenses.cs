using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using License.Models;

namespace License.Services.Interfaces
{
    public interface ILicenses : ICrudService<Licenses>
    {
        Task<List<Licenses>> GetByList();
        Task<Licenses> GetById(int Id);
        Task GetDelete(int Id);


      }
}

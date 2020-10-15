using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using License.Services.Interfaces;
using License.Services.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace License.WebApp.Controllers
{
    public class LicenseTypeController : Controller
    {
        private readonly ILicenseTypeService _licensesType;
        public LicenseTypeController(ILicenseTypeService licenseTypeService)
        {
            _licensesType = licenseTypeService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> GetAllLicenseType()
        {
            var licensesType = (await _licensesType.GetList()).Select(x => new LicenseTypeVM
            {
                Id = x.Id,
                Name = x.Name

            });
            return Json(licensesType);
        }
    }
}

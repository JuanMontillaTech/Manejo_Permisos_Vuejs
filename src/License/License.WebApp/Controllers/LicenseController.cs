using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using License.Models;
using License.Services.Interfaces;
using License.Services.ViewModel;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace License.WebApp.Controllers
{
    public class LicenseController : Controller
    {
        private readonly ILicenses _licenses;
        public LicenseController(ILicenses license)
        {
            _licenses = license;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
       public async Task<JsonResult> Create(string json)
        {

            LicensesCreateVM _licensesCreateVM = JsonConvert.DeserializeObject<LicensesCreateVM>(json);
            if (_licensesCreateVM != null)
            {                 
                var licence = new Licenses()
                {
                    FullName = _licensesCreateVM.FullName,
                    LicenseTypeID = _licensesCreateVM.LicensesType,
                    Surnames = _licensesCreateVM.Surnames,
                    LicensesDate = _licensesCreateVM.LicensesDate
                };
                await _licenses.Add(licence);
                await _licenses.SaveChangesAsync();
                
            }
            string result = "Licencia Creada.";
            return Json(result);

        }
        [HttpPost]
        public async Task<JsonResult> Edit(string json)
        {

            LicensesEditVM _licensesEditVM = JsonConvert.DeserializeObject<LicensesEditVM>(json);
            if (_licensesEditVM != null)
            {
                var LicenseForEdit = await _licenses.GetById(_licensesEditVM.Id);


                LicenseForEdit.FullName = _licensesEditVM.FullName;
                LicenseForEdit.LicenseTypeID = _licensesEditVM.LicensesType;
                LicenseForEdit.Surnames = _licensesEditVM.Surnames;
                LicenseForEdit.LicensesDate = _licensesEditVM.LicensesDate; 
                await _licenses.SaveChangesAsync();

            }
            string result = "Licencia Cambio Realizado.";
            return Json(result);

        }

        [HttpPost]
        public async Task<JsonResult> DeleteLicense(int Id)
        {
            
            await _licenses.GetDelete(Id);
            string result = "Registro Eliminado";
            return Json(result);
        }


        public async Task<JsonResult> GetLicense(int Id)
        {
            LicensesEditVM _licensesEditVM = new LicensesEditVM();
            var LicenseForEdit = await _licenses.GetById(Id);
            _licensesEditVM.FullName = LicenseForEdit.FullName;
            _licensesEditVM.LicensesType = LicenseForEdit.LicenseTypeID;
            _licensesEditVM.Surnames = LicenseForEdit.Surnames;
            _licensesEditVM.LicensesDate = LicenseForEdit.LicensesDate;
            _licensesEditVM.Id = Id;
            return Json(_licensesEditVM);
        }

        public async Task<JsonResult> GetAllLicenses()
        {
            var result = ( await _licenses.GetByList()).Select(x => new LicensesVM  { 
               FullName = x.FullName + " " + x.Surnames,
               LicensesDate = x.LicensesDate.ToShortDateString(),
               LicenseType = x.LicenseType.Name,
               LicenseTypeID = x.LicenseTypeID,
               Id = x.Id
            
            } );
            return Json(result);
        }
    }
}

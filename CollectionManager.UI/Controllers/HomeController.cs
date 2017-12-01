using CollectionManager.Repository.Interfaces;
using CollectionManager.Repository.ViewModels;
using CollectionManager.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollectionManager.UI.Controllers
{
    public class HomeController : Controller
    {
        IVehicleTypeRepository repo;

        

        public HomeController(IVehicleTypeRepository _repo)
        {
            this.repo = _repo;
        }

        public ActionResult Index()
        {
            ViewBag.PageTitle = "Home";
            return View();
        }


        public JsonResult addVehicleType(VehicleTypeModel model)
        {
            var exceptionMessage = string.Empty;
            try
            {
                model.createdBy = AppUtils.LoggedInUserId;
               

                if (repo.saveVehicleType(model))
                {
                    return Json(new { error = false, message = "Operation successful" });
                }
                else
                {
                    return Json(new { error = true, message = "An exception has occured" });
                }

            }
            catch (Exception ex)
            {
                exceptionMessage =$"An unknown exception has occured: {ex.Message}"; 
            }

            return Json(new { error = true, message = exceptionMessage });
        }

       
    }
}
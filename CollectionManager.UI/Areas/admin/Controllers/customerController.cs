using CollectionManager.Repository.Interfaces;
using CollectionManager.Repository.ViewModels;
using CollectionManager.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollectionManager.UI.Areas.admin.Controllers
{
    public class customerController : Controller
    {
        ISetupRepository setupRepo;
        ICustomerRepository repo;
        public customerController(ISetupRepository _setupRepo,
            ICustomerRepository _repo)
        {
            this.setupRepo = _setupRepo;
            this.repo = _repo;
        }


        // GET: admin/customer
        public ActionResult Index()
        {
            ViewBag.lga = new SelectList(setupRepo.GetLGAs().OrderBy(x => x.lgaName).ToList(), "lgaId", "lgaName");
            ViewBag.bg = new SelectList(setupRepo.GetBloodGroups().OrderBy(x => x.bloodGroupName).ToList(), "bloodGroupId", "bloodGroupName");
            return View();
        }

        public JsonResult saveCustomer(CustomerViewModel customer)
        {
            var exceptionMessage = "An unknown error occured :: ";
            try
            {
                customer.createdBy = AppUtils.LoggedInUserId;
                if (repo.AddCustomer(customer))
                {
                    return Json(new { error = false, message = "Customer has been created successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { error = true, message = "There was an error creating Customer" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                exceptionMessage = $"{exceptionMessage} {ex.Message } { innerException }";
            }

            return Json(new { error = true, message = exceptionMessage }, JsonRequestBehavior.AllowGet);

        }



        public JsonResult GetCustomers()
        {
            //string status = Request.Form.GetValues("status").FirstOrDefault();
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            //Find Order Column
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();

            var firstName = Request.Form.GetValues("columns[1][search][value]").FirstOrDefault();
            var middleName = Request.Form.GetValues("columns[2][search][value]").FirstOrDefault();
            var lastName = Request.Form.GetValues("columns[3][search][value]").FirstOrDefault();
            var email = Request.Form.GetValues("columns[4][search][value]").FirstOrDefault();
            var phone = Request.Form.GetValues("columns[5][search][value]").FirstOrDefault();
            var bgroup = Request.Form.GetValues("columns[6][search][value]").FirstOrDefault();
            var lga = Request.Form.GetValues("columns[7][search][value]").FirstOrDefault();


            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            var customers = repo.GetCustomers();

            if (!string.IsNullOrEmpty(lga))
            {
                customers = repo.GetCustomers().Where(x => x.lgaName.ToLower().Contains(lga.ToLower()));
            }

            if (!string.IsNullOrEmpty(bgroup))
            {
                customers = repo.GetCustomers().Where(x => x.bloodGroupName.ToLower().Contains(bgroup.ToLower()));
            }


            if (!string.IsNullOrEmpty(phone))
            {
                customers = repo.GetCustomers().Where(x => x.phone.ToLower().Contains(phone.ToLower()));
            }


            if (!string.IsNullOrEmpty(email))
            {
                customers = repo.GetCustomers().Where(x => x.email.ToLower().Contains(email.ToLower()));
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                customers = repo.GetCustomers().Where(x => x.lastName.ToLower().Contains(lastName.ToLower()));
            }

            if (!string.IsNullOrEmpty(firstName))
            {
                customers = repo.GetCustomers().Where(x => x.firstName.ToLower().Contains(firstName.ToLower()));
            }


            if (!string.IsNullOrEmpty(middleName))
            {
                customers = repo.GetCustomers().Where(x => x.middleName.ToLower().Contains(middleName.ToLower()));
            }
            recordsTotal = customers.Count();

            var data = customers.OrderBy(x => x.customerId).Skip(skip).Take(pageSize).ToList()
                .Select(x => new
                {
                    bloodGroupId = x.bloodGroupId,
                    bloodGroupName = x.bloodGroupName,
                    customerId = x.customerId,
                    createdBy = x.createdBy,
                    email = x.email,
                    firstName = x.firstName,
                    lastName = x.lastName,
                    lgaId = x.lgaId,
                    lgaName = x.lgaName,
                    middleName = x.middleName,
                    phone = x.phone
                });

            return Json(new
            {
                draw = draw,
                recordsFiltered = recordsTotal,
                recordsTotal = recordsTotal,
                data = data.ToList()
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
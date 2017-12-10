using CollectionManager.Repository.Interfaces;
using CollectionManager.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollectionManager.UI.Areas.admin.Controllers
{
    [RouteArea("admin")]
    public class usersController : Controller
    {
        IUserRepository repo;
        public usersController(IUserRepository _repo)
        {
            this.repo = _repo;
        }
        
        [Route("users")]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetUsers()
        {
            string status = Request.Form.GetValues("status").FirstOrDefault();
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            //Find Order Column
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();

            var userName = Request.Form.GetValues("columns[1][search][value]").FirstOrDefault();
            //var clientName = Request.Form.GetValues("columns[2][search][value]").FirstOrDefault();


            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            var users = repo.GetAllUsers();

            if (status == "All" || string.IsNullOrWhiteSpace(status))
            {
                users = repo.GetAllUsers();

            }else if (status == "Active")
            {
                users = repo.GetAllUsers().Where(x => x.IsActive == true);
            }
            else if (status == "InActive")
            {
                users = repo.GetAllUsers().Where(x => x.IsActive == false);
            }
            else if (status == "Locked")
            {
                users = repo.GetAllUsers().Where(x => x.IsLocked == true);
            }

            if (!string.IsNullOrEmpty(userName))
            {
                users = users.Where(x => x.Username.ToLower().Contains(userName.ToLower()));
            }
            recordsTotal = users.Count();

            var data = users.OrderBy(x => x.UserId).Skip(skip).Take(pageSize).ToList()
                .Select(x => new 
                {
                    UserId = x.UserId,
                    Username =x.Username,
                    IsActive = x.IsActive == true ? "Active" : "InActive",
                    IsLocked = x.IsLocked==true ? "Locked": "Not Locked",
                    LastLoginDate = x.LastLoginDate.Value.ToString("dd MMMM yyyy")                  
                });

            return Json(new
            {
                draw = draw,
                recordsFiltered = recordsTotal,
                recordsTotal = recordsTotal,
                data = data.ToList()
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult saveUser(UserVModel user)
        {
            var exceptionMessage = "An unknown error occured :: ";
            try
            {

                if(string.IsNullOrEmpty(user.username) || string.IsNullOrEmpty(user.password) ||
                    string.IsNullOrEmpty(user.securityQuestion) || string.IsNullOrEmpty(user.securityAnswer))
                {
                    return Json(new { error = true, message = "All fields are mandatory" }, JsonRequestBehavior.AllowGet);
                }

                if (repo.AddUser(user))
                {
                    return Json(new { error = false, message = "User has been created successfully" },JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { error = true, message = "There was an error creating user" },JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                exceptionMessage = $"{exceptionMessage} {ex.Message } { innerException }";
            }

            return Json(new { error = true, message = exceptionMessage }, JsonRequestBehavior.AllowGet);
        }

    }
}
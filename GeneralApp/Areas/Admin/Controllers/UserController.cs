using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeneralApp.DataAccess.Data;
using GeneralApp.DataAccess.Repository.IRepository;
using GeneralApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeneralApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var userList = _db.ApplicationUser.Include(u => u.Company).ToList();
            var userRole = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();

            foreach (var user in userList)
            {
                var roleId = userRole.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;
                if (user.Company == null)
                {
                    user.Company = new Company()
                    {
                        Name = ""
                    };
                }
            }
            return Json(new { data = userList });
        }

        [HttpPost]
        public IActionResult LockUnlock([FromBody] string Id)
        {
            var objFromDB = _db.ApplicationUser.FirstOrDefault(u => u.Id == Id);
            if (objFromDB == null)
            {
                return Json(new { success = false, message = "Error while locking/unlocking" });
            }
            if (objFromDB.LockoutEnd != null && objFromDB.LockoutEnd > DateTime.Now)
            {
                // user is currently locked, we will unlock then
                objFromDB.LockoutEnd = DateTime.Now;
            }
            else
            {
                objFromDB.LockoutEnd = DateTime.Now.AddYears(1000);
            }
            _db.SaveChanges();
            return Json(new { success = true, message = "Operation Successful." });
        }
        #endregion
    }
}
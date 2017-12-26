using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SammysAuto.Data;

namespace SammysAuto.Controllers
{
    public class UsersController : Controller
    {

        private ApplicationDbContext _db;

        public UsersController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(string option=null, string search=null)
        {
            var users = _db.Users.ToList();
            if (option == "email" && search != null)
            {
                users = _db.Users.Where(u => u.Email.ToLower().Contains(search.ToLower())).ToList();
            }
            else
            {
                if (option == "name" && search != null)
                {
                    users = _db.Users.Where(u => u.FirstName.ToLower().Contains(search.ToLower())
                            || u.LastName.ToLower().Contains(search.ToLower())).ToList();
                }
                else
                {
                    if (option == "phone" && search != null)
                    {
                        users = _db.Users.Where(u => u.PhoneNumber.ToLower().Contains(search.ToLower())).ToList();
                    }
                }
            }
            return View(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }
    }
}
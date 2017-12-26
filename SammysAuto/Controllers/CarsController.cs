using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SammysAuto.Data;
using System.Security.Claims;
using SammysAuto.ViewModel;

namespace SammysAuto.Controllers
{
    public class CarsController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CarsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index(string userId = null)
        {
            if (userId == null)
            {
                //Only called when a customer logs in
                userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            var model = new CarAndCustomerViewModel
            {
                Cars = _db.Cars.Where(c=>c.UserId == userId),
                UserObj = _db.Users.FirstOrDefault(u=>u.Id==userId)
            };

            return View(model);
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
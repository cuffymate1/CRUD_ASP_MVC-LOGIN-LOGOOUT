using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;


namespace BulkyWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)  // constructor function DbContext
        {
            _db = db;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Users user)
        {
            if (ModelState.IsValid) 
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                TempData["success"] = "Create User Successfully";
                return RedirectToAction("Login");
            }
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Username,string Password)
        {
            if (ModelState.IsValid)
            {

                var UserfromDb = _db.Users.FirstOrDefault(u => u.Username == Username && u.Password == Password);
                if (UserfromDb != null)
                {
                    HttpContext.Session.SetString("Username", UserfromDb.Username);
                    TempData["success"] = "Login Successfully";
                    return RedirectToAction("Welcome");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User NotFound");
                }
            }
            return View();
        }
        public IActionResult Welcome()
        {
            string username = HttpContext.Session.GetString("Username");
            if (username == null)
            {
                return RedirectToAction("Login");
            }

            ViewBag.Username = username; // ส่งชื่อผู้ใช้ไปยัง View
            List<Users> objUsersList = _db.Users.ToList(); // สร้าง List เพื่อเก็บข้อมูลจาก DataBase
            return View(objUsersList);
        }

        [HttpPost]
        public IActionResult Logout()
        {
            // Add your logout logic here
            // Sign out user
            TempData["success"] = "Logout Successfully";
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}

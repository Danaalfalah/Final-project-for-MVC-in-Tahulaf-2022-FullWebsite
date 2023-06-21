using FinalProject1ForMVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject1ForMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AuthController(ModelContext context, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }




        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Customerid,Fname,Lname,Phone,Address")] Customer1 customer, string Username, string Password)
        {
            if (ModelState.IsValid)
            {
                    _context.Add(customer);
                    await _context.SaveChangesAsync(); 
                    Userlogin1 userLogin = new Userlogin1();
                    userLogin.Username = Username;
                    userLogin.Password = Password;
                    userLogin.Roleid = 2;//customer role id
                    userLogin.Customerid = customer.Customerid;
                    _context.Add(userLogin);
                    await _context.SaveChangesAsync();
                ViewBag.suceess = "register your information success";
                return RedirectToAction("login","Auth");
            }
            ViewBag.Message = "succesufly register";
            return View(customer);
        }




        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult login([Bind("Username,Password")] Userlogin1 userlogin)
        {
            var auth = _context.Userlogin1s.Where(x => x.Username == userlogin.Username && x.Password == userlogin.Password).SingleOrDefault();
            if (auth != null)
            {
                switch (auth.Roleid)
                {
                    case 1:
                        HttpContext.Session.SetInt32("AdminId", (int)auth.Customerid);
                        return RedirectToAction("Index", "Admin");

                    case 2:
                        HttpContext.Session.SetInt32("CustomerId", (int)auth.Customerid);
                        return RedirectToAction("Index", "User");

                }

            }

            return View();
        }











    }
}

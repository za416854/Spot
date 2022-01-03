using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Spot.Data;
using Spot.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Spot.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(TravelContext context)
        {
            _context = context;
        }

        private readonly TravelContext _context;


        public IActionResult Index()
        {
            ViewBag.IsLogin = HttpContext.Session.GetString("LoginName") != null;
            ViewBag.UserName = HttpContext.Session.GetString("LoginName") ?? "訪客";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string UserName, string Password)
        {
            Account account = await _context.Accounts.SingleOrDefaultAsync(m => m.UserName == UserName && m.Password == Password);

            if (account != null)
            {
                //using Microsoft.AspNetCore.Http;
                HttpContext.Session.SetString("LoginName", account.UserName);

                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("error", "帳號或密碼不正確");
            return View(account);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }
        public IActionResult Test1()
        {
            ViewBag.IsLogin = HttpContext.Session.GetString("LoginName") != null;
            ViewBag.UserName = HttpContext.Session.GetString("LoginName") ?? "訪客";
            return View();
        }
    }
}

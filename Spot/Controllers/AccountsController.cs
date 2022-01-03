using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spot.Data;
using Spot.Models;

namespace Spot.Controllers
{
    public class AccountsController : Controller
    {
        private readonly TravelContext _context;

        public AccountsController(TravelContext context)
        {
            _context = context;
        }

        // GET: Accounts
        public async Task<IActionResult> Index()
        {
            ViewBag.UserName = HttpContext.Session.GetString("LoginName") ?? "訪客";
            ViewBag.IsLogin = HttpContext.Session.GetString("LoginName") != null;
            if (ViewBag.UserName != "123" || ViewBag.UserName == "訪客")
            {
                return RedirectToAction("Login", "Home");
            }

            return View(await _context.Accounts.ToListAsync());
        }
        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.IsLogin = HttpContext.Session.GetString("LoginName") != null;
            ViewBag.UserName = HttpContext.Session.GetString("LoginName") ?? "訪客";
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            ViewBag.IsLogin = HttpContext.Session.GetString("LoginName") != null;
            ViewBag.UserName = HttpContext.Session.GetString("LoginName") ?? "訪客";
            if (ViewBag.UserName != "123" || ViewBag.UserName == "訪客")
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Password")] Account account)
        {
            ViewBag.IsLogin = HttpContext.Session.GetString("LoginName") != null;
            ViewBag.UserName = HttpContext.Session.GetString("LoginName") ?? "訪客";
            if (ModelState.IsValid)
            {
                _context.Add(account);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.IsLogin = HttpContext.Session.GetString("LoginName") != null;
            ViewBag.UserName = HttpContext.Session.GetString("LoginName") ?? "訪客";
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Password")] Account account)
        {
            ViewBag.IsLogin = HttpContext.Session.GetString("LoginName") != null;
            ViewBag.UserName = HttpContext.Session.GetString("LoginName") ?? "訪客";
            if (id != account.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.IsLogin = HttpContext.Session.GetString("LoginName") != null;
            ViewBag.UserName = HttpContext.Session.GetString("LoginName") ?? "訪客";
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Accounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewBag.IsLogin = HttpContext.Session.GetString("LoginName") != null;
            ViewBag.UserName = HttpContext.Session.GetString("LoginName") ?? "訪客";
            var account = await _context.Accounts.FindAsync(id);
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(int id)
        {
            ViewBag.IsLogin = HttpContext.Session.GetString("LoginName") != null;
            ViewBag.UserName = HttpContext.Session.GetString("LoginName") ?? "訪客";
            return _context.Accounts.Any(e => e.Id == id);
        }
    }
}

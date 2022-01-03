using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GemBox.Spreadsheet;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Spot.Data;
using Spot.Models;

namespace Spot.Controllers
{
    public class PlacesController : Controller
    {
        private readonly TravelContext _context; IWebHostEnvironment _env;

        public PlacesController(TravelContext context, IWebHostEnvironment env)
        {
            
            _context = context; _env = env;
        }
        public IActionResult Budget()
        {
            ViewBag.IsLogin = HttpContext.Session.GetString("LoginName") != null;
            ViewBag.UserName = HttpContext.Session.GetString("LoginName") ?? "訪客";
            return View();
        }
        // GET: Places
        public async Task<IActionResult> Index()
        {
            ViewBag.IsLogin = HttpContext.Session.GetString("LoginName") != null;
            //判斷前面是否為null，是的話回傳訪客
            ViewBag.UserName = HttpContext.Session.GetString("LoginName") ?? "訪客";
            if (ViewBag.UserName == "訪客")
            {
                return RedirectToAction("Login", "Home");
            }
            return View(await _context.Places.ToListAsync());
        }
       //public async Task<IActionResult> Test()
       // {
       //     return View(await _context.Places.ToListAsync());
       // }

        public IActionResult getMap(string myMap)
        {
            List<Place> places = _context.Places.Where(p => p.Nation == myMap).ToList();
            return Json(places);
        }

        public IActionResult Test()
        {
            ViewBag.IsLogin = HttpContext.Session.GetString("LoginName") != null;
            ViewBag.UserName = HttpContext.Session.GetString("LoginName") ?? "訪客";
            return View();
        }

        public IActionResult LondonIntro()
        {
            ViewBag.IsLogin = HttpContext.Session.GetString("LoginName") != null;
            ViewBag.UserName = HttpContext.Session.GetString("LoginName") ?? "訪客";
            Place place = _context.Places.SingleOrDefault(p => p.City == "London");
            return View(place);
        }
        public IActionResult NewyorkIntro()
        {
            ViewBag.IsLogin = HttpContext.Session.GetString("LoginName") != null;
            ViewBag.UserName = HttpContext.Session.GetString("LoginName") ?? "訪客";
            Place place = _context.Places.SingleOrDefault(p => p.City == "New York");
            return View(place);
        }
        public IActionResult AmsterdamIntro()
        {
            ViewBag.IsLogin = HttpContext.Session.GetString("LoginName") != null;
            ViewBag.UserName = HttpContext.Session.GetString("LoginName") ?? "訪客";
            Place place = _context.Places.SingleOrDefault(p => p.City == "Amsterdam");
            return View(place);
        }
        public IActionResult MadridIntro()
        {
            ViewBag.IsLogin = HttpContext.Session.GetString("LoginName") != null;
            ViewBag.UserName = HttpContext.Session.GetString("LoginName") ?? "訪客";
            Place place = _context.Places.SingleOrDefault(p => p.City == "Madrid");
            return View(place);
        }
        public async Task<IActionResult> More()
        {
            ViewBag.IsLogin = HttpContext.Session.GetString("LoginName") != null;
            ViewBag.UserName = HttpContext.Session.GetString("LoginName") ?? "訪客";
            return View(await _context.Places.ToListAsync());
        }
        public IActionResult GetExcel()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "select * from Place",
                @"Data Source=.\sqlexpress;Initial Catalog=Travel;Integrated Security=true"
                );
            DataTable dt = new DataTable("MyTable");
            da.Fill(dt);

            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            ExcelFile xlsx = new ExcelFile();
            ExcelWorksheet mySheet = xlsx.Worksheets.Add("sheet1");
            mySheet.InsertDataTable(dt,
               new InsertDataTableOptions()
               {
                   StartColumn = 2,
                   StartRow = 2,
                   ColumnHeaders = true
               });

            // Save PDF file.
            MemoryStream stream = new MemoryStream();
            xlsx.Save(stream, SaveOptions.XlsxDefault);

            //Download file.
            return File(stream, "application/excel", "OutputFromView.xlsx");
        }

        // GET: Places/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewBag.IsLogin = HttpContext.Session.GetString("LoginName") != null;
            ViewBag.UserName = HttpContext.Session.GetString("LoginName") ?? "訪客";
            if (id == null)
            {
                return NotFound();
            }

            var place = await _context.Places
                .FirstOrDefaultAsync(m => m.Id == id);
            if (place == null)
            {
                return NotFound();
            }

            return View(place);
        }

        // GET: Places/Create
        public IActionResult Create()
        {
            ViewBag.IsLogin = HttpContext.Session.GetString("LoginName") != null;
            ViewBag.UserName = HttpContext.Session.GetString("LoginName") ?? "訪客";
            if (ViewBag.UserName == "訪客")
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }
        // POST: Places/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Place place, IFormFile file)
        {
            ViewBag.IsLogin = HttpContext.Session.GetString("LoginName") != null;
            ViewBag.UserName = HttpContext.Session.GetString("LoginName") ?? "訪客";
            if (ModelState.IsValid)
            {
                place.Photo = file.FileName;
                var filePath = $"{_env.ContentRootPath}\\wwwroot\\images\\IndexImages\\{file.FileName}";
                ViewBag.test = _env.ContentRootPath;
                using (var stream = System.IO.File.Create(filePath))
                {
                    file.CopyTo(stream);
                }
                _context.Add(place);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(place);
        }

        // GET: Places/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.IsLogin = HttpContext.Session.GetString("LoginName") != null;
            ViewBag.UserName = HttpContext.Session.GetString("LoginName") ?? "訪客";
            if (id == null)
            {
                return NotFound();
            }

            var place = await _context.Places.FindAsync(id);
            if (place == null)
            {
                return NotFound();
            }
            return View(place);
        }

        // POST: Places/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nation,City,Feature,Photo,Language,Currency,Budget,Introduction")] Place place)
        {
            ViewBag.IsLogin = HttpContext.Session.GetString("LoginName") != null;
            ViewBag.UserName = HttpContext.Session.GetString("LoginName") ?? "訪客";
            if (id != place.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(place);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlaceExists(place.Id))
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
            return View(place);
        }

        // GET: Places/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.IsLogin = HttpContext.Session.GetString("LoginName") != null;
            ViewBag.UserName = HttpContext.Session.GetString("LoginName") ?? "訪客";
            if (id == null)
            {
                return NotFound();
            }

            var place = await _context.Places
                .FirstOrDefaultAsync(m => m.Id == id);
            if (place == null)
            {
                return NotFound();
            }

            return View(place);
        }

        // POST: Places/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewBag.IsLogin = HttpContext.Session.GetString("LoginName") != null;
            ViewBag.UserName = HttpContext.Session.GetString("LoginName") ?? "訪客";
            var place = await _context.Places.FindAsync(id);
            _context.Places.Remove(place);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlaceExists(int id)
        {
            ViewBag.IsLogin = HttpContext.Session.GetString("LoginName") != null;
            ViewBag.UserName = HttpContext.Session.GetString("LoginName") ?? "訪客";
            return _context.Places.Any(e => e.Id == id);
        }
    }
}

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherCollector.Context;
using WeatherCollector.Entities;
using WeatherCollector.Helpers;
using WeatherCollector.Models;

namespace WeatherCollector.Controllers
{
    public class HomeController : Controller
    {
        private WeatherCollectorDb db;

        public HomeController(WeatherCollectorDb db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            foreach(var file in files)
            {
                using (var stream = file.OpenReadStream())
                {
                    await db.Weathers.AddRangeAsync(XlsParser.Parse(stream));

                    try
                    {
                        await db.SaveChangesAsync();
                    }
                    catch (DbUpdateException)
                    {
                        db.ChangeTracker.AcceptAllChanges();
                    }
                }
            }
            

            return RedirectToAction("Upload");
        }

        [HttpGet]
        public async Task<IActionResult> Watch(string sortOrder, int? pageNumber)
        {
            ViewData["DateSortParm"] = sortOrder == "mounth" ? "mounth" : "year";

            var weathers = from w in db.Weathers
                           select w;

            switch (sortOrder)
            {
                case "year":
                    weathers = weathers.OrderByDescending(y => y.Date.Value.Year);
                    break;
                case "mounth":
                    weathers = weathers.OrderByDescending(w => w.Date.Value.Month);
                    break;
            }

            int pageSize = 15;
            return View(await PaginatedList<Weather>.CreateAsync(weathers.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly monoDBcontext _sunil;

        public HomeController(monoDBcontext sunil)
        {
            _sunil = sunil;
        }

        public async Task<IActionResult> Index()
        {
            var stdData = await _sunil.Monotcrest.ToListAsync();
            return View(stdData);
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(mono std)
        {
            if (ModelState.IsValid)
            {
                await _sunil.Monotcrest.AddAsync(std);
                await _sunil.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(std);
        }
        public async Task<ActionResult> Details (int? id)
        {
            if (id == null || _sunil.Monotcrest==null)
            {
                return NotFound();
            }
            var std =_sunil.Monotcrest.FirstOrDefault(x =>x.id ==id);
            if (std == null)
            {
                return NotFound();
            }
            return View(std);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _sunil.Monotcrest == null)
            {
                return NotFound();
            }
            var std = await _sunil.Monotcrest.FindAsync(id);
            if (std == null)
            {
                return NotFound();
            }
            return View(std);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int? id, mono std)
        {
            if (id != std.id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _sunil.Monotcrest.Update(std);
                await _sunil.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(std);
        }
        public async Task <IActionResult> delete(int? id)
        {
            if (id ==null || _sunil.Monotcrest ==null)
                    {
                return NotFound();
            }
            var std = await _sunil.Monotcrest.FirstOrDefaultAsync(x =>x.id ==id);
            if (std == null)
            {
                return NotFound();
            }
            return View(std);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var std = await _sunil.Monotcrest.FindAsync(id);
            if (std == null)
            {
                _sunil.Monotcrest.Remove(std);
            }
            await _sunil.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
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
    }
}

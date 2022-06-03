using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using proniaTask.DAL;
using proniaTask.Extensions;
using proniaTask.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace proniaTask.Areas.Manage.Controllers
{
        [Area("Manage")]
    public class SliderController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _context;
        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }
        public IActionResult Index()
        {
            List<Slider> sliders = _context.Sliders.ToList();
            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Slider slider)
        {
            if(!ModelState.IsValid) return View();
            if(slider == null)return NotFound();
            if(slider.ImageFile != null)
            {
                if (!slider.ImageFile.IsImage())
                {
                    ModelState.AddModelError("Imagefile", "Sekil duzgun formatda deyil");
                    return View();
                }
                if (!slider.ImageFile.IsSizeOk(5))
                {
                    ModelState.AddModelError("Imagefile", "Sekil max 5mb ola biler");
                    return View();
                }
                slider.SliderImage = slider.ImageFile.SaveImg(_env.WebRootPath, "assets/images/slider");
            }
            else
            {
                ModelState.AddModelError("Imagefile", "Sekil elave edin");
                return View();
            }
            _context.Sliders.Add(slider);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            Slider slider = _context.Sliders.FirstOrDefault(s => s.Id == id);
            if(id == null) return BadRequest();
            return View(slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id,Slider slider)
        {
           

            Slider existSlider=_context.Sliders.FirstOrDefault(s => s.Id==id);

            if(existSlider == null) return BadRequest();
            if(slider.ImageFile != null)
            {
                if (!slider.ImageFile.IsImage())
                {
                    ModelState.AddModelError("ImageFile", "Sekil duzgun formatda deyil");
                    return View();
                }
                if (!slider.ImageFile.IsSizeOk(10))
                {
                    ModelState.AddModelError("ImageFile", "Sekil max 5mb ola biler");
                    return View();
                }
                Helpers.Helper.DeleteImg(_env.WebRootPath, "assets/images/slider",existSlider.SliderImage);

                existSlider.SliderImage = slider.ImageFile.SaveImg(_env.WebRootPath, "assets/images/slider");

            }
            if (!ModelState.IsValid) return View();

            existSlider.Name=slider.Name;
            existSlider.DiscountPercent=slider.DiscountPercent;
            existSlider.Description=slider.Description;
           
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        { 
            Slider slider = _context.Sliders.Find(id);
            if(slider == null) return NotFound();
            _context.Sliders.Remove(slider);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

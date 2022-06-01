using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using proniaTask.DAL;
using proniaTask.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace proniaTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeVm homeVm = new HomeVm
            {
                Sliders = await _context.Sliders.ToListAsync()
            };
            return View(homeVm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

     
    }
}

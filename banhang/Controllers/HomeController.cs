using banhang.Data;
using banhang.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace banhang.Controllers
{
    public class HomeController : Controller
    {
		private readonly banhangContext _context;

		public HomeController(banhangContext context)
		{
			_context = context;
		}

		public IActionResult Index()
        {
            return View(_context.sanpham.ToList());
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
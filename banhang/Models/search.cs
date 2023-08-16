using banhang.Data;
using Microsoft.AspNetCore.Mvc;

namespace banhang.Models
{
	public class search : ViewComponent
	{
		private readonly banhangContext _context;

		public search(banhangContext context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			return View(_context.Category.ToList());
		}
	}
}

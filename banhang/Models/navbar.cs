using banhang.Data;
using Microsoft.AspNetCore.Mvc;

namespace banhang.Models
{
	public class navbar:ViewComponent
	{
		private readonly banhangContext _context;

		public navbar(banhangContext context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			return View(_context.Category.ToList());
		}

	}
}

using banhang.Data;
using Microsoft.AspNetCore.Mvc;

namespace banhang.Models
{
	public class sidebar : ViewComponent
	{
		private readonly banhangContext _context;

		public sidebar(banhangContext context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			return View(_context.Category.ToList());
		}
	}
}

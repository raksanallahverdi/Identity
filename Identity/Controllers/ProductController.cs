using Identity.Data;
using Identity.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
	public class ProductController : Controller
	{

		private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
			_context = context;
            
        }
        public IActionResult Index()
		{
			var model = new ProductIndexVM
			{
				Products = _context.Products.ToList()
			};
			return View(model);
		}
	}
}

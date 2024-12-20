using Identity.Data;
using Identity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
namespace Identity.Controllers
{
    [Authorize]
    public class BasketController:Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _context;
        public BasketController(UserManager<User> userManager,
            AppDbContext context)
        {
            _context = context;
            _userManager=userManager;
            
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(int productId)
        {
            var user=_userManager.GetUserAsync(User).Result;
            if(user is null) return Unauthorized("Couldn't add product to basket");
            var product=_context.Products.Find(productId);
            if(product is null) return NotFound("Couldn't add product to basket");

            if (product.StockQuantity == 0)
            {
                return BadRequest("Product out of stock");
            }
            var basket = _context.Baskets.FirstOrDefault(b => b.UserId == user.Id);
            if (basket is null){
                basket=new Basket
                {
                    UserId = user.Id,
                    CreatedAt = DateTime.Now,

                };
                _context.Baskets.Add(basket);
            }
            var basketProduct = new BasketProduct
            {
                Basket = basket,
                Quantity=1,
                ProductId=product.Id,
                CreatedAt=DateTime.Now
            };
            _context.BasketProducts.Add(basketProduct);
            _context.SaveChanges();
            return Ok("Product Added to Basket Successfully");




        }
    }
}

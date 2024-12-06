using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Identity.Entities;
using Identity.ViewModels.Account;

namespace Identity.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager=userManager;
            _signInManager=signInManager;
            _roleManager=roleManager;

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(AccountRegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new User
            {
                Email = model.Email,
                UserName = model.Email,
                City = model.City,
                Country = model.Country,
                PhoneNumber = model.PhoneNumber
            };
            var result=_userManager.CreateAsync(user,model.Password).Result;
            if (!result.Succeeded) {
                foreach (var item in result.Errors) 
                ModelState.AddModelError(string.Empty,item.Description);
                return View(model);
                
            }
            return RedirectToAction(nameof(Login));
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(AccountLoginVM model)
        {
            if (!ModelState.IsValid) return View(model);
            var user=_userManager.FindByEmailAsync(model.Email).Result;
            if (user is null)
            {
                ModelState.AddModelError(string.Empty, "Email or Password is wrong");
                return View(model);

            }
            var result=_signInManager.PasswordSignInAsync(user, model.Password,false,false).Result;
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Email or Password is wrong");
                return View(model);
            }
            if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
            {
                return Redirect(model.ReturnUrl);
            }
           
            return RedirectToAction("index","home");           
        }
        //[HttpGet]
        //public IActionResult AddAdmin()
        //{
        //    var role = new IdentityRole
        //    {
        //        Name = "Admin"
        //    };
        //    var roleResult = _roleManager.CreateAsync(role).Result;
        //    if (!roleResult.Succeeded)
        //    {
        //        return NotFound("Error while creating Admin Role");
        //    }
        //    var user = new User
        //    {
        //        Email = "admin@app.com",
        //        City = "Baku",
        //        Country = "Azerbaijan",
        //        UserName = "admin@app.com"
        //    };
        //    var result = _userManager.CreateAsync(user, "Admin123!").Result;
        //    if (!result.Succeeded) { 
        //        return NotFound("Error while creating Admin");
        //    }
        //    var addRoleResult=_userManager.AddToRoleAsync(user,role.Name).Result;
        //    if (!addRoleResult.Succeeded) {
        //        return NotFound("Couldn't add Admin Role to User");
        //    }
        //    return Ok(user);
        //}

    }
}

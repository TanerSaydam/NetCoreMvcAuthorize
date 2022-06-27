using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace NetCoreMvcAuthorize.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login()
        {
            string[] roles = new string[3];
            roles[0] = "admin";
            roles[1] = "ui";
            roles[2] = "product.add";

            //Kontrol edilecek verileri alıp kontrol etmeniz lazım
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Taner Saydam"),
                new Claim(ClaimTypes.Role, roles[0]),
                new Claim(ClaimTypes.Role, roles[1]),
                new Claim(ClaimTypes.Role, roles[2]),
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
            return RedirectToAction("Index", "Home");
        }
    }
}

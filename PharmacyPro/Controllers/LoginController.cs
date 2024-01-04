using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PharmacyPro.Models;

namespace PharmacyPro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;

        public LoginController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Post([FromBody] UserLoginViewModel userLogin){
        {
                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(userLogin.UserName, userLogin.Password, false, true);
                    if (result.Succeeded)
                    {
                        return Ok(new { message = "Giriş Başarılı" });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Giriş başarısız. Lütfen mailinizi ve şifrenizi kontrol edin");
                        return BadRequest(new { errors = ModelState.Values.SelectMany(v => v.Errors).Select(e=>e.ErrorMessage).ToList()});
                    }
                }
                return BadRequest(new { errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList() });

            }
        }
        

        
    }
}

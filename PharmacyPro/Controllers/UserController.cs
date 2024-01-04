using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PharmacyPro.Models;

namespace PharmacyPro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new UserRegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserRegisterViewModel userRegister)
        {
            if(ModelState.IsValid)
            {
                User user = new User()  
                {
                    IdentityNumber = userRegister.IdentityNumber,
                    Name = userRegister.Name,
                    Surname = userRegister.Surname,
                    UserName = userRegister.UserName,
                    Email = userRegister.Email,
                    PhoneNumber = userRegister.PhoneNumber,
                    Address = userRegister.Address

                };
                var result = await _userManager.CreateAsync(user, userRegister.Password);
                if(result.Succeeded)
                {
                    return Ok(new { message = "Kayıt başarılı" });
                    //return RedirectToAction("Index", "Home");
                }
               
                else
                {
                    foreach (var item in result.Errors)
                    {
                        Console.WriteLine($"Error: {item.Description}");
                        return BadRequest(new { errors = result.Errors.Select(e => e.Description).ToList() });
                        //ModelState.AddModelError("", item.Description)  ;
                    }
                }
                // ModelState.IsValid false ise, hata durumunu JSON formatında gönder
                return BadRequest(new { errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList() });

            }
            return BadRequest(new { errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList() });

        }

    }
}

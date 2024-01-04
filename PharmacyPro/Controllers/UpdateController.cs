using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PharmacyPro.Models;

namespace PharmacyPro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UpdateController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public UpdateController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var model = new
            {
                Id = user.Id,
                UserName = user.UserName,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UserAndPasswordUpdateViewModel userUpdate)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
               return NotFound();
            }
            user.UserName = userUpdate.UserName;
            user.Name = userUpdate.Name;
            user.Surname = userUpdate.Surname;
            user.Email = userUpdate.Email;
            user.PhoneNumber = userUpdate.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);

            if(result.Succeeded)
            {
                return Ok(new { message = "Kullanıcı bilgileri güncellendi" });
            }
            else
            {
                return BadRequest(new { errors = result.Errors.Select(e => e.Description).ToList() });
            }
        }
        
    }
}

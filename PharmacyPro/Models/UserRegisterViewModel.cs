using System.ComponentModel.DataAnnotations;

namespace PharmacyPro.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public int IdentityNumber { get; set; }

        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        [Compare("Password", ErrorMessage = "Şifreler uyumlu değil")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Address { get; set; }


    }
}

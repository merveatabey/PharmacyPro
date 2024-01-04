using System.ComponentModel.DataAnnotations;

namespace PharmacyPro.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage= "Bu alanı boş geçemezsiniz")]
        public string UserName{  get; set; }

        [Required(ErrorMessage ="Bu alanı boş geçemezsiniz")]
        public string Password {  get; set; }
    }
}

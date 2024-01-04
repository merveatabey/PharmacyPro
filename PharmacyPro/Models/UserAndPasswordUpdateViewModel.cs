﻿using Microsoft.AspNetCore.Mvc;

namespace PharmacyPro.Models
{
    public class UserAndPasswordUpdateViewModel : ViewComponent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }

    }
}

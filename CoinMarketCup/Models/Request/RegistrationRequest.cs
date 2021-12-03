using System;
using System.ComponentModel.DataAnnotations;


namespace CoinMarketCup.Models.Request
{
    public class RegistrationRequest
    {
        [Required]
        [Display(Name = "Username")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "RoleName")]
        public string RoleName { get; set; }

        [Required]
        [Display(Name = "RoleName")]
        public DateTime DateOfBirth { get; set; }

    }
}

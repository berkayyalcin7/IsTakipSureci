using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IsTakipSureci.WEB.Models
{
    public class AppUserViewModel
    {
        [Required(ErrorMessage ="Kullanıcı Adı Boş Geçilemez")]
        [Display(Name="Kullanıcı Adı")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Parola Alanı Boş Geçilemez")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor")]
        [Display(Name = "Şifreyi Tekrar Giriniz")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email Alanı Boş Geçilemez")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage ="Geçersiz Email Adresi")]
        public string Email { get; set; }

        [Display(Name="Adınız")]
        public string Name { get; set; }
        [Display(Name = "Soyadınız")]
        public string Surname { get; set; }
    }
}

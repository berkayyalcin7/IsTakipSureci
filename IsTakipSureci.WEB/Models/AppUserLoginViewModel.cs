using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IsTakipSureci.WEB.Models
{
    public class AppUserLoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        [Required(ErrorMessage = " Alanı Boş Geçilemez")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name="Beni Hatırla ")]
        public bool RememberMe { get; set; }
    }
}

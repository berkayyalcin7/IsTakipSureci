using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IsTakipSureci.WEB.Areas.Admin.Models
{
    public class AppUserListViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage ="Ad Alanı Boş Geçilemez"),Display(Name="Adınız")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad Alanı Boş Geçilemez"), Display(Name = "Soyadınız")]
        public string Surname { get; set; }

        [Display(Name="Email : ")]
        public string Email { get; set; }
        [Display(Name = "Profil Fotoğrafı : ")]
        public string Picture { get; set; }
    }
}

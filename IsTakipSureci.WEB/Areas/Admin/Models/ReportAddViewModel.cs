using IsTakipSureci.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IsTakipSureci.WEB.Areas.Admin.Models
{
    public class ReportAddViewModel
    {   
        [Display(Name = "Rapor Tanımı : ")]
        [Required(ErrorMessage ="Başlık Boş Geçilemez")]
        public string ReportTitle { get; set; }

        [Display(Name = "Rapor İçeriği : ")]

        [Required(ErrorMessage = "Detay Alanı Boş Geçilemez")]

        public string ReportDescription { get; set; }

        public int WorkId { get; set; }
        public Work Work { get; set; }
    }
}

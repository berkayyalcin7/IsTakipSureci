using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IsTakipSureci.WEB.Areas.Admin.Models
{
    public class LevelAddViewModel
    {
        [Display(Name ="Tanım")]
        [Required(ErrorMessage ="Tanım Alanı Zorunludur !")]
        public string Tanim { get; set; }
    }
}

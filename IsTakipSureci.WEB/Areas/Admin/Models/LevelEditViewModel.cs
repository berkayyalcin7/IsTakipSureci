using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IsTakipSureci.WEB.Areas.Admin.Models
{
    public class LevelEditViewModel
    {
        public int Id { get; set; }
    
        [Display(Name ="Tanım ")]
        [Required(ErrorMessage ="Tanım alanı zorunludur !")]
        public string Tanim { get; set; }
    }
}

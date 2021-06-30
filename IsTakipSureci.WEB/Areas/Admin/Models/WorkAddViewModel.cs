using IsTakipSureci.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IsTakipSureci.WEB.Areas.Admin.Models
{
    public class WorkAddViewModel
    {
        [Required(ErrorMessage ="İş Tanımı Gereklidir !")]
        public string WorkName { get; set; }

        public string Description { get; set; }

        //Görevin Aciliyeti olacak
        [Range(0,int.MaxValue,ErrorMessage ="Lütfen bir aciliyet Durumu Seçiniz")]
        public int LevelId { get; set; }
    }
}

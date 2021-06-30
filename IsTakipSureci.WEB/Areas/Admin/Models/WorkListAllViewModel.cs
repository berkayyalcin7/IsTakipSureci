using IsTakipSureci.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsTakipSureci.WEB.Areas.Admin.Models
{

    public class WorkListAllViewModel
    {
        //LevelId AppUserID ihtiyacımız yok

        public int Id { get; set; }

        public string WorkName { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public AppUser AppUser { get; set; }

   
        public Level Level { get; set; }

        public List<Report> Reports { get; set; }


    }
}

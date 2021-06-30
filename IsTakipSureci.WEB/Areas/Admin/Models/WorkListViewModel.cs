using IsTakipSureci.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsTakipSureci.WEB.Areas.Admin.Models
{
    public class WorkListViewModel
    {
        public int Id { get; set; }


        public string WorkName { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }

        //Görevin Aciliyeti olacak
        public int LevelId { get; set; }
        public Level Level { get; set; }

    }
}

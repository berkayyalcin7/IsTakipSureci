using IsTakipSureci.Entities.Interfaces;
using System;
using System.Collections.Generic;

namespace IsTakipSureci.Entities.Concrete
{
    public class Work:ITable
    {
        public int Id { get; set; }

        public string WorkName { get; set; }

        public bool Status { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;


        // Nullable Olmaz ise :  Görevi oluştururken bir kullanıcı atamak zorundayız
        public int? AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        //Görevin Aciliyeti olacak
        public int LevelId { get; set; }
        public Level Level { get; set; }

        public List<Report> Reports { get; set; }

    }
}

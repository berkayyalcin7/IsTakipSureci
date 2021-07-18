using IsTakipSureci.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace IsTakipSureci.Entities.Concrete
{
    //int' yazmaz isek primary key string ile çalışacak
    public class AppUser : IdentityUser<int>,ITable
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Picture { get; set; } = "icon-default.png";

        public List<Work> Works { get; set; }
        //Bildirimler listelenecek
        public List<Notify> Notifys { get; set; }
    }
}

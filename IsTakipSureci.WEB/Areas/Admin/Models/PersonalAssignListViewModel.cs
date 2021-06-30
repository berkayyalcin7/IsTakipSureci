using IsTakipSureci.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsTakipSureci.WEB.Areas.Admin.Models
{
    public class PersonalAssignListViewModel
    {
        public AppUserListViewModel AppUser { get; set; }

        public WorkListViewModel Work { get; set; }
    }
}

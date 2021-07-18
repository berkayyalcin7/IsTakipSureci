using IsTakipSureci.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.Entities.Concrete
{
    public class Notify:ITable
    {
        public int Id { get; set; }

        public int  AppUserId { get; set; }

        public AppUser AppUser { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }
    }
}

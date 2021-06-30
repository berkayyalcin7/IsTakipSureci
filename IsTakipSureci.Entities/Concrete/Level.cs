using IsTakipSureci.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.Entities.Concrete
{
    public class Level : ITable
    {
        public int Id { get; set; }

        public string Tanim { get; set; }

        public List<Work> Works { get; set; }
    }
}

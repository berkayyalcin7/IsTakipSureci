using IsTakipSureci.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.DTO.DTOs.WorkDtos
{
    public class WorkListDto
    {
        public int Id { get; set; }


        public string WorkName { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedDate { get; set; }

        //Görevin Aciliyeti olacak
        public int LevelId { get; set; }
        //public Level Level { get; set; }
    }
}

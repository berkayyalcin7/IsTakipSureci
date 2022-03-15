using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.DTO.DTOs.WorkDtos
{
    public class WorkUpdateDto
    {
        public int Id { get; set; }

      
        public string WorkName { get; set; }

        public string Description { get; set; }

        public int LevelId { get; set; }
    }
}

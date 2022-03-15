using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.DTO.DTOs.ReportDtos
{
    public class ReportUpdateDto
    {
        public int Id { get; set; }
        
        public string ReportTitle { get; set; }

        public string ReportDescription { get; set; }

        public int WorkId { get; set; }
        //public Work Work { get; set; }
    }
}

using IsTakipSureci.DTO.DTOs.AppUserDtos;
using IsTakipSureci.DTO.DTOs.WorkDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.DTO.DTOs.PersonalDtos
{
    public class PersonalAssignListDto
    {
        public AppUserListDto AppUser { get; set; }

        public WorkListDto Work { get; set; }

    }
}

using AutoMapper;
using IsTakipSureci.DTO.DTOs.AppUserDtos;
using IsTakipSureci.DTO.DTOs.LevelDtos;
using IsTakipSureci.DTO.DTOs.NotifyDtos;
using IsTakipSureci.DTO.DTOs.ReportDtos;
using IsTakipSureci.DTO.DTOs.WorkDtos;
using IsTakipSureci.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsTakipSureci.WEB.Mapping.AutoMapperProfile
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<LevelAddDto, Level>().ReverseMap();
            CreateMap<LevelUpdateDto, Level>().ReverseMap();
            CreateMap<LevelListDto, Level>().ReverseMap();

            CreateMap<AppUserAddDto, AppUser>().ReverseMap();
            CreateMap<AppUserListDto, AppUser>().ReverseMap();
            CreateMap<AppUserLoginDto, AppUser>().ReverseMap();

            CreateMap<ReportAddDto, Report>().ReverseMap();
            CreateMap<ReportUpdateDto, Report>().ReverseMap();

            CreateMap<NotifyListDto, Notify>().ReverseMap();

            CreateMap<WorkAddDto, Work>().ReverseMap();
            CreateMap<WorkUpdateDto, Work>().ReverseMap();
            CreateMap<WorkListDto, Work>().ReverseMap();
            
        }
    }
}

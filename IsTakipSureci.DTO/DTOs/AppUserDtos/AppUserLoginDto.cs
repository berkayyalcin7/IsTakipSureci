using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.DTO.DTOs.AppUserDtos
{
    public class AppUserLoginDto
    {
        public string UserName { get; set; }
        
        public string Password { get; set; }
      
        public bool RememberMe { get; set; }
    }
}

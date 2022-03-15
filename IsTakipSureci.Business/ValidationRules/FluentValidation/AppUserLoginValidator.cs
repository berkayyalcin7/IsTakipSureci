using FluentValidation;
using IsTakipSureci.DTO.DTOs.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.Business.ValidationRules.FluentValidation
{
    public class AppUserLoginValidator:AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginValidator()
        {
            RuleFor(x => x.UserName).NotNull().WithMessage("Kullanıcı adı boş geçilemez .");
            RuleFor(x => x.Password).NotNull().WithMessage("Şifre alanı boş geçilemez .");

        }
    }
}

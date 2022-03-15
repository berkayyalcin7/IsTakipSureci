using FluentValidation;
using IsTakipSureci.DTO.DTOs.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.Business.ValidationRules.FluentValidation
{
    public class AppUserAddValidator:AbstractValidator<AppUserAddDto>
    {
        public AppUserAddValidator()
        {
            RuleFor(x => x.Username).NotNull().WithMessage("Kullanıcı Adı boş geçilemez .");
            RuleFor(x => x.Password).NotNull().WithMessage("Parola alanı boş geçilemez .");
            RuleFor(x => x.ConfirmPassword).NotNull().WithMessage("Parola onay alanı boş geçilemez .");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Parolalar eşleşmiyor .");
            RuleFor(x => x.Email).NotNull().WithMessage("Email alanı boş geçilemez").EmailAddress().WithMessage("Geçersiz email adresi .");
            RuleFor(x => x.Name).NotNull().WithMessage("Ad alanı boş geçilemez .");
            RuleFor(x => x.Surname).NotNull().WithMessage("Soyad alanı boş geçilemez .");
        }
    }
}

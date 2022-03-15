using FluentValidation;
using IsTakipSureci.DTO.DTOs.WorkDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.Business.ValidationRules.FluentValidation
{
    public class WorkUpdateValidator:AbstractValidator<WorkUpdateDto>
    {
        public WorkUpdateValidator()
        {
            RuleFor(x => x.WorkName).NotNull().WithMessage("İş Emri alanı gereklidir .");
            RuleFor(x => x.LevelId).ExclusiveBetween(1, int.MaxValue).WithMessage("Lütfen bir aciliyet durumu seçiniz");

        }
    }
}

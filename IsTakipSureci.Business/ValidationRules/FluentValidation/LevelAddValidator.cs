using FluentValidation;
using IsTakipSureci.DTO.DTOs.LevelDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.Business.ValidationRules.FluentValidation
{
    public class LevelAddValidator: AbstractValidator<LevelAddDto>
    {
        public LevelAddValidator()
        {
            RuleFor(x => x.Tanim).NotNull().WithMessage("Tanım alanı boş geçilemez.");
        }
    }
}

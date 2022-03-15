using FluentValidation;
using IsTakipSureci.DTO.DTOs.ReportDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace IsTakipSureci.Business.ValidationRules.FluentValidation
{
    public class ReportUpdateValidator : AbstractValidator<ReportUpdateDto>
    {
        public ReportUpdateValidator()
        {
            RuleFor(x => x.ReportTitle).NotNull().WithMessage("Başlık alanı boş geçilemez .");
            RuleFor(x => x.ReportDescription).NotNull().WithMessage("Açıklama alanı boş geçilemez .");

        }
    }
}

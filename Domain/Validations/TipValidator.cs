using CommonShared.DTO.Tips;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Validations
{
    public  class TipValidator : AbstractValidator<TipModel>
    {
        public TipValidator()
        {
            RuleFor(x => x.Title).NotNull().MinimumLength(1);
            RuleFor(x => x.Description).NotNull().MinimumLength(1);

        }
    }
}

using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.Description).MinimumLength(10).When(c => c.Id == 1);
            RuleFor(c => c.Description).Must(StartWithB).WithMessage("Ürün açıklaması B ile başlamalı");
        }

        private bool StartWithB(string arg)
        {
            return arg.StartsWith("B");
        }
    }
}

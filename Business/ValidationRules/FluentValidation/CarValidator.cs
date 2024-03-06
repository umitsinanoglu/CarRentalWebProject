using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.ModelName).MinimumLength(2).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(100000).When(p => p.BrandId == 1).WithMessage("1 nolu Marka için Ürün fiyatı 100 Bin TL'den büyük olmalı");
            RuleFor(c => c.ModelName).Must(StartWithA).When(p => p.BrandId == 2).WithMessage("2 nolu Marka için Ürünler A harfi ile başlamalı");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
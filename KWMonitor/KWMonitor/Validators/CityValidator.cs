using FluentValidation;
using KoronaWirusMonitor3.Models;
using KWMonitor.Models;

namespace KWMonitor.Validators
{
    public class CityValidator : AbstractValidator<CreateCity>
    {
        public CityValidator()
        {
            RuleFor(city => city.Name)
                .NotEmpty()
                .WithMessage(Resource.CountryNameNotEmpty)
                .MinimumLength(3)
                .WithMessage("Nazwa kraju musi być dłuższ niż 3 znak")
                .MaximumLength(20);
        }
    }
}

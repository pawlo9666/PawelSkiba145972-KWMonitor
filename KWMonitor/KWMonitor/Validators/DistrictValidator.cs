using FluentValidation;
using KoronaWirusMonitor3.Models;
using KWMonitor.Models;

namespace KWMonitor.Validators
{
    public class DistrictValidator : AbstractValidator<CreateDistrict>
    {
        public DistrictValidator()
        {
            RuleFor(district => district.Name)
                .NotEmpty()
                .WithMessage(Resource.CountryNameNotEmpty)
                .MinimumLength(3)
                .WithMessage("Nazwa kraju musi być dłuższ niż 3 znak")
                .MaximumLength(20);
        }
    }
}

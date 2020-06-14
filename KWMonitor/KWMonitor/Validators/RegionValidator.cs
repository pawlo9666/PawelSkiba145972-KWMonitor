using FluentValidation;
using KoronaWirusMonitor3.Models;
using KWMonitor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWMonitor.Validators
{
    public class RegionValidator : AbstractValidator<CreateRegion>
    {
        public RegionValidator()
        {
            RuleFor(region => region.Name)
                .NotEmpty()
                .MinimumLength(3)
                .WithMessage("Nazwa kraju musi być dłuższ niż 3 znak")
                .MaximumLength(20);
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCalculator.Model
{
    
    public class BowlingScoreRequest
    {
        [Required]
        public IList<int> PinsDowned { get; set; }
    }

    public class BowlingScoreRequestValidator : AbstractValidator<BowlingScoreRequest>
    {
        public BowlingScoreRequestValidator()
        {
            RuleFor(x => x.PinsDowned).NotNull();
            RuleFor(x => x.PinsDowned).ForEach(x => x.InclusiveBetween(0, 10)).WithMessage("The total pins downed in each throw cannot be more than 10");
            RuleFor(x => x.PinsDowned.Sum()).InclusiveBetween(0, 120).WithMessage("The total pins downed in all throws cannot be more than 120");
        }
    }
}

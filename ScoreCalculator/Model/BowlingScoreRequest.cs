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
            RuleFor(x => x.PinsDowned).ForEach(x => x.InclusiveBetween(0, 10));
            RuleFor(x=>x.PinsDowned.Count).InclusiveBetween(1,12);            
        }
    }
}

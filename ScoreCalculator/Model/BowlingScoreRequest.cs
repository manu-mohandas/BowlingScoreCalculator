using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCalculator.Model
{
    public class BowlingScoreRequest
    {
        public IList<int> PinsDowned { get; set; }
    }
}

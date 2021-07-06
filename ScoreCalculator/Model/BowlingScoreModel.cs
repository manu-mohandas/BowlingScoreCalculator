using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCalculator.Model
{
    public class BowlingScoreModel
    {
        public IList<string> FrameProgressScores { get; set; }
        public bool GameCompleted { get; set; }
    }
}

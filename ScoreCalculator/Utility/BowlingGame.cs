using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCalculator.Utility
{
    public class BowlingGame
    {
        private IList<string> progressiveScores;
        private int frameIndex = 0;
        private int score = 0;
        public BowlingGame()
        {
                       
        }
        public bool GameCompleted { get; private set; } = true;
        public IList<string> Scores(IList<int> pins)
        {
            progressiveScores = new List<string>();
            
            // loop through the list of pins downed
            for (int i = 0; i + 1 < pins.Count; i+=2)
            {
                if (frameIndex == 10)
                    break;

                // Neither strike nor spare
                if (pins[i] + pins[i + 1] < 10)
                {                    
                    score += pins[i] + pins[i + 1];                    
                    progressiveScores.Add(score.ToString());
                    frameIndex++;
                    continue;
                }                

                // score cannot be determined and the game is not over
                if (i + 2 >= pins.Count)
                {
                    GameCompleted = false;
                    while (i < pins.Count)
                    {
                        progressiveScores.Add("*");
                        i++;
                    }

                    break;
                }

                //Either strike or spare
                score += pins[i] + pins[i + 1] + pins[i + 2];
                progressiveScores.Add(score.ToString());
                frameIndex++;

                // In case of strike, advance only by one               
                 if (pins[i] == 10)
                    i--;
            }

            if (frameIndex < 10)
                GameCompleted = false;

            return progressiveScores;
        }
    }
}

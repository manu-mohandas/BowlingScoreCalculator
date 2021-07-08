using ScoreCalculator.Infrastructure.ErrorHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCalculator.Utility
{
    public class BowlingGame : IBowlingGame
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
            

            //Score can be calculated only if at least one frame is available.
            if(pins.Count < 2)
            {
                progressiveScores.Add("*");
                GameCompleted = false;

                return progressiveScores;
            }

            // loop through the list of pins downed
            for (int throws = 0; throws + 1 < pins.Count; throws+=2)
            {
                
                if (frameIndex == 10)
                    break;

                if (pins[throws] !=10 && pins[throws] + pins[throws + 1] > 10)
                    throw new ApiException("Invalid input, pins downed in a frame cannot be more that 10", System.Net.HttpStatusCode.BadRequest);

                // Neither strike nor spare
                if (pins[throws] + pins[throws + 1] < 10)
                {                    
                    score += pins[throws] + pins[throws + 1];                    
                    progressiveScores.Add(score.ToString());
                    frameIndex++;                    
                    continue;
                }                

                // score cannot be determined and the game is not over
                if (throws + 2 >= pins.Count)
                {
                    GameCompleted = false;
                    while (throws < pins.Count && frameIndex < 10)
                    {
                        progressiveScores.Add("*");
                        throws++;
                        frameIndex++;
                    }

                    break;
                }

                //Either strike or spare
                score += pins[throws] + pins[throws + 1] + pins[throws + 2];
                progressiveScores.Add(score.ToString());
                frameIndex++;
                              

                // In case of strike, advance only by one               
                if (pins[throws] == 10)
                    throws--;

                //verifying, if we have 2 set of throws available to compute the score.
                int nextThrows = throws + 2;
                if(nextThrows + 1 == pins.Count && frameIndex < 10)
                {                    
                    progressiveScores.Add("*");
                }              
               
            }

            if (frameIndex < 10)
                GameCompleted = false;

            return progressiveScores;
        }
    }

    public interface IBowlingGame
    {
        IList<string> Scores(IList<int> pins);

        bool GameCompleted { get; }
    }
}

using ScoreCalculator.Model;
using ScoreCalculator.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCalculator.Services
{
    public class BowlingScoreServices : IBowlingScoreServices
    {
        private readonly IBowlingGame _bowlingGame;
        public BowlingScoreServices(IBowlingGame bowlingGame)
        {
            _bowlingGame = bowlingGame;
        }

        public BowlingScoreModel CalculateScore(IList<int> pins)
        {
            var viewModel = new BowlingScoreModel { FrameProgressScores = _bowlingGame.Scores(pins), GameCompleted = _bowlingGame.GameCompleted };

            return viewModel;
        }
    }

    public interface IBowlingScoreServices
    {
        BowlingScoreModel CalculateScore(IList<int> pins);
    }
}

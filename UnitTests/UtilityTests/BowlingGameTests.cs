using NUnit.Framework;
using ScoreCalculator.Infrastructure.ErrorHandlers;
using ScoreCalculator.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.UtilityTests
{
    [TestFixture]
    public class BowlingGameTests
    {
        private IBowlingGame _game;

        [SetUp]
        public void SetUp()
        {
            _game = new BowlingGame();
        }

        [Test]
        public void perfect_game_score()
        {
            int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string[] scores = { "30", "60", "90", "120", "150", "180", "210", "240", "270", "300" };

            IList<string> actualScores = _game.Scores(rolls);
            Assert.AreEqual(scores, actualScores);
            var gameOver = _game.GameCompleted;
            Assert.AreEqual(true, gameOver);
        }

        [Test]
        public void first_random_game_score()
        {
            int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            string[] scores = { "2", "4", "6", "8", "10", "12" };

            IList<string> actualScores = _game.Scores(rolls);
            var gameOver = _game.GameCompleted;
            
            Assert.AreEqual(scores, actualScores);
            Assert.AreEqual(false, gameOver);
        }

        [Test]
        public void second_random_game_score()
        {
            int[] rolls = { 1, 1, 1, 1, 9, 1, 2, 8, 9, 1, 10, 10 };
            string[] scores = { "2", "4", "16", "35", "55", "*", "*" };

            IList<string> actualScores = _game.Scores(rolls);
            var gameOver = _game.GameCompleted;

            Assert.AreEqual(scores, actualScores);
            Assert.AreEqual(false, gameOver);
        }

        [Test]
        public void gutter_ball_game_score()
        {
            int[] rolls = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };            
            string[] scores = { "0", "0", "0", "0", "0","0","0","0","0","0" };

            IList<string> actualScores = _game.Scores(rolls);
            var gameOver = _game.GameCompleted;

            Assert.AreEqual(scores, actualScores);
            Assert.AreEqual(true, gameOver);
        }

        [Test]
        public void first_random_spare_ball_game_score()
        {
            int[] rolls = { 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9, 1, 9 };
            string[] scores = {  "19", "38", "57","76", "95","114","133","152","171","190"};

            IList<string> actualScores = _game.Scores(rolls);
            var gameOver = _game.GameCompleted;

            Assert.AreEqual(scores, actualScores);
            Assert.AreEqual(true, gameOver);
        }

        [Test]
        public void first_random_strike_ball_game_score()
        {
            int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string[] scores = { "30", "60", "90", "120", "150", "180", "210", "240", "270", "*" };

            IList<string> actualScores = _game.Scores(rolls);
            var gameOver = _game.GameCompleted;

            Assert.AreEqual(scores, actualScores);
            Assert.AreEqual(false, gameOver);
        }

        [Test]
        public void second_random_spare_ball_game_score()
        {
            int[] rolls = {  10,10,10,9,1,5,4,9,1,9 };
            string[] scores = { "30","59", "79", "94","103", "122","*" };

            IList<string> actualScores = _game.Scores(rolls);
            var gameOver = _game.GameCompleted;

            Assert.AreEqual(scores, actualScores);
            Assert.AreEqual(false, gameOver);
        }

        [Test]
        public void strike_spare_combination_ball_game_score()
        {
            int[] rolls = { 10, 9, 1, 10 };
            string[] scores = {"20","40","*" };

            IList<string> actualScores = _game.Scores(rolls);
            var gameOver = _game.GameCompleted;

            Assert.AreEqual(scores, actualScores);
            Assert.AreEqual(false, gameOver);
        }
               

        [Test]
        public void invalid_combination_ball_game_score()
        {
            int[] rolls = { 8, 9 };            

            Assert.Throws<ApiException>(() => _game.Scores(rolls));
            
        }
    }
}

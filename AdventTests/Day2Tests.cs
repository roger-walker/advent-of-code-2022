using AdventOfCode2022;

namespace AdventTests
{
    public class Day2Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FindScores_EmptyString_ReturnsValidScore()
        {
            List<string> list = null;

            Day2 day = new Day2(list);
            var actual = day.FindScores("");
            Assert.That(actual, Is.EqualTo((0, 0)));
        }

        [Test]
        [TestCase("A X", Day2.Rock, Day2.Rock)]
        [TestCase("A Y", Day2.Rock, Day2.Paper)]
        [TestCase("A Z", Day2.Rock, Day2.Scissors)]
        [TestCase("B X", Day2.Paper, Day2.Rock)]
        [TestCase("B Y", Day2.Paper, Day2.Paper)]
        [TestCase("B Z", Day2.Paper, Day2.Scissors)]
        [TestCase("C X", Day2.Scissors, Day2.Rock)]
        [TestCase("C Y", Day2.Scissors, Day2.Paper)]
        [TestCase("C Z", Day2.Scissors, Day2.Scissors)]
        public void FindScores_ValidString_ReturnsValidScore(string score, int left, int right)
        {
            List<string> list = null;

            Day2 day = new Day2(list);
            var expected = (left, right);
            var actual = day.FindScores(score);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("A Y", Day2.Rock, Day2.Decision.Tie)]
        [TestCase("B X", Day2.Paper, Day2.Decision.Loss)]
        [TestCase("C Z", Day2.Scissors, Day2.Decision.Win)]
        public void FindScoresPart2_ReturnsValid(string score, int left, int strategy)
        {
            Day2 day = new Day2(null, true);
            var expected = (left, strategy);
            var actual = day.FindScores(score);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(Day2.Rock, Day2.Decision.Tie, Day2.Rock)]
        [TestCase(Day2.Paper, Day2.Decision.Loss, Day2.Rock)]
        [TestCase(Day2.Scissors, Day2.Decision.Win, Day2.Rock)]
        public void GivenOppAndResult_FindPlay_ReturnsCorrectPlay(int opp, Day2.Decision desc, int expected)
        {
            Day2 day = new Day2(null, true);
            var actual = day.FindPlay(opp, desc);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("A Y", 4)]
        [TestCase("B X", 1)]
        [TestCase("C Z", 7)]
        public void GivenRound_DecisionMapScore_ReturnsResult(string round, int expected)
        {
            Day2 day = new Day2(null, true);
            var actual = day.DecisionMapScore(round);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(Day2.Rock, Day2.Paper, 8)]
        [TestCase(Day2.Paper, Day2.Rock, 1)]
        [TestCase(Day2.Scissors, Day2.Scissors, 6)]
        public void RoundScore_ReturnsValue(int left, int right, int expected)
        {
            List<string> list = null;
            Day2 day = new Day2(list);

            var actual = day.RoundScore((left, right));
            Assert.That(actual, Is.EqualTo(expected));

        }


        [Test]
        [TestCase(Day2.Rock, Day2.Rock, Day2.Decision.Tie)]
        [TestCase(Day2.Rock, Day2.Paper, Day2.Decision.Win)]
        [TestCase(Day2.Rock, Day2.Scissors, Day2.Decision.Loss)]
        [TestCase(Day2.Paper, Day2.Rock, Day2.Decision.Loss)]
        [TestCase(Day2.Paper, Day2.Paper, Day2.Decision.Tie)]
        [TestCase(Day2.Paper, Day2.Scissors, Day2.Decision.Win)]
        [TestCase(Day2.Scissors, Day2.Rock, Day2.Decision.Win)]
        [TestCase(Day2.Scissors, Day2.Paper, Day2.Decision.Loss)]
        [TestCase(Day2.Scissors, Day2.Scissors, Day2.Decision.Tie)]
        public void CheckRound_ReturnsExpected(int left, int right, Day2.Decision expected)
        {
            List<string> list = null;
            Day2 day = new Day2(list);

            var actual = day.CheckRound(left, right);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TallyScore_ReturnsScore()
        {
            List<string> list = new List<string>()
            {
                "A Y","B X","C Z"
            };
            Day2 day2 = new Day2(list);

            var actual = day2.TallyScore();
            Assert.That(actual, Is.EqualTo(15));
        }

        [Test]
        public void UseDecisionMap_TallyScore_ReturnScore()
        {
            List<string> list = new List<string>()
            {
                "A Y","B X","C Z"
            };
            Day2 day2 = new Day2(list, useDecisionMap: true);

            var actual = day2.TallyScore();
            Assert.That(actual, Is.EqualTo(12));
        }


    }
}
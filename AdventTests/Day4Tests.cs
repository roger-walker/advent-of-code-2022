using AdventOfCode2022;

namespace AdventTests
{
    internal class Day4Tests
    {
        [Test]
        [TestCase("1-1,1-1", "1-1", "1-1")]
        public void GivenPairSplitIntoIndividuals(string pair, string asmt1, string asmt2)
        {

            Day4 day = new Day4();



            var actual = day.SplitPair(pair);
            List<string> expected = new List<string>() { asmt1, asmt2 };

            Assert.That(actual, Is.EqualTo(expected));
        }


        [Test]
        [TestCase("1-1", 1, 1)]
        [TestCase("1-2", 1, 2)]
        [TestCase("2-8", 2, 8)]
        [TestCase("200-800", 200, 800)]
        public void GivenRange_FindStartAndEnd(string range, int expectedStart, int expectedEnd)
        {
            Day4 day = new Day4();

            (int actualStart, int actualEnd) = day.FindRangeBoundaries(range);

            Assert.That(actualStart, Is.EqualTo(expectedStart));
            Assert.That(actualEnd, Is.EqualTo(expectedEnd));

        }

        [Test]
        [TestCase(1, 2, 3, 4, false)]
        [TestCase(1, 4, 3, 5, false)]
        [TestCase(1, 4, 2, 3, true)]
        [TestCase(1, 4, 1, 2, true)]
        [TestCase(1, 4, 3, 4, true)]
        [TestCase(1, 4, 1, 4, true)]
        [TestCase(1, 4, 1, 4, true)]
        [TestCase(1, 2, 1, 4, true)]

        [TestCase(2, 4, 6, 8, false)]
        [TestCase(2, 3, 4, 5, false)]
        [TestCase(5, 7, 7, 9, false)]
        [TestCase(2, 8, 3, 7, true)]
        [TestCase(6, 6, 4, 6, true)]
        [TestCase(2, 6, 4, 8, false)]

        public void Given2Areas_DetermineIfOneIsFullyContained(int s1, int e1, int s2, int e2, bool expected)
        {
            Day4 day = new Day4();

            var actual = day.IsFullyContained(s1, e1, s2, e2);

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void GivenAssignment_TotalFullyContainedRange()
        {
            List<string> assigns = new List<string>()
            {
                "2-4,6-8",
                "2-3,4-5",
                "5-7,7-9",
                "2-8,3-7",
                "6-6,4-6",
                "2-6,4-8"
            };

            Day4 day = new Day4();
            var actual = day.TotalFullyContained(assigns);

            Assert.That(actual, Is.EqualTo(2));
        }

        [TestCase(2, 4, 6, 8, false)]
        [TestCase(2, 3, 4, 5, false)]
        [TestCase(5, 7, 7, 9, true)]
        [TestCase(2, 8, 3, 7, true)]
        [TestCase(6, 6, 4, 6, true)]
        [TestCase(2, 6, 4, 8, true)]
        public void Given2Areas_DetermineIfSomeOverlap(int s1, int e1, int s2, int e2, bool expected)
        {
            Day4 day = new Day4();

            var actual = day.IsSomeOverlap(s1, e1, s2, e2);

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void GivenAssignment_TotalSomeOverlap()
        {
            List<string> assigns = new List<string>()
            {
                "2-4,6-8",
                "2-3,4-5",
                "5-7,7-9",
                "2-8,3-7",
                "6-6,4-6",
                "2-6,4-8"
            };

            Day4 day = new Day4();
            var actual = day.TotalSomeOverlap(assigns);

            Assert.That(actual, Is.EqualTo(4));
        }
    }
}

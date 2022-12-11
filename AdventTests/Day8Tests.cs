using AdventOfCode2022;

namespace AdventTests
{
    internal class Day8Tests
    {

        [Test]
        public void GivenInput_CreateTreeMap()
        {
            List<string> list = new List<string>()
            {
                "1"
            };

            Day8 day = new Day8(list);

            Assert.That(day.TreeMap[0][0], Is.EqualTo(1));
        }


        [Test]
        [TestCase(new string[] { "1" }, 0, 0, 1)]
        [TestCase(new string[] { "12", "34" }, 1, 1, 4)]
        [TestCase(new string[] { "123", "456", "789" }, 1, 1, 5)]
        [TestCase(new string[] { "123", "456", "789" }, 2, 0, 7)]
        [TestCase(new string[] { "123", "456", "789" }, 2, 1, 8)]
        [TestCase(new string[] { "123", "456", "789" }, 1, 2, 6)]
        [TestCase(new string[] { "30373",
                                 "25512",
                                 "65332",
                                 "33549",
                                 "35390" }, 3, 3, 4)]

        public void GivenMoreInput_CreateTreeMap(string[] input, int row, int col, int expected)
        {
            List<string> list = input.ToList();

            Day8 day = new Day8(list);

            Assert.That(day.TreeMap[row][col], Is.EqualTo(expected));
        }

        [Test]
        [TestCase(new string[] { "1" }, 1, 1)]
        [TestCase(new string[] { "12", "34" }, 2, 2)]
        [TestCase(new string[] { "123", "456", "789" }, 3, 3)]
        [TestCase(new string[] { "123", "456", "789", "000" }, 4, 3)]
        [TestCase(new string[] { "30373",
                                 "25512",
                                 "65332",
                                 "33549",
                                 "35390" }, 5, 5)]
        public void GivenInput_DetermineDimensions(string[] input, int expRows, int expCols)
        {
            List<string> list = input.ToList();

            Day8 day = new Day8(list);
            Assert.Multiple(() =>
            {
                Assert.That(day.MapHeight, Is.EqualTo(expRows));
                Assert.That(day.MapWidth, Is.EqualTo(expCols));
            });
        }

        [Test]
        [TestCase(new string[] { "1" }, 0, 0, true)]
        [TestCase(new string[] { "123", "456", "789" }, 0, 0, true)]
        [TestCase(new string[] { "123", "456", "789" }, 1, 1, false)]
        [TestCase(new string[] { "123", "456", "789" }, 1, 2, true)]
        [TestCase(new string[] { "123", "456", "789" }, 2, 1, true)]
        [TestCase(new string[] { "123", "456", "789", "000" }, 2, 2, true)]
        [TestCase(new string[] { "30373",
                                 "25512",
                                 "65332",
                                 "33549",
                                 "35390" }, 3, 4, true)]
        [TestCase(new string[] { "30373",
                                 "25512",
                                 "65332",
                                 "33549",
                                 "35390" }, 1, 3, false)]
        public void GivenInput_Coords_DetermineIfEgdeTree(string[] input, int row, int col, bool expected)
        {
            List<string> list = input.ToList();

            Day8 day = new Day8(list);
            Assert.That(day.IsEdgeTree(row, col), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(new string[] { "1" }, 0, 0, true)]
        [TestCase(new string[] { "9199", "9499", "9799", "9999" }, 2, 1, true)]
        [TestCase(new string[] { "9199", "9999", "9799", "9999" }, 2, 1, false)]
        [TestCase(new string[] { "9999", "9499", "9799", "9999" }, 2, 1, false)]
        public void GivenInput_Coords_DetermineIfVisibleFromTop(string[] input, int row, int col, bool expected)
        {
            List<string> list = input.ToList();

            Day8 day = new Day8(list);
            Assert.That(day.IsTreeVisibleTop(row, col), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(new string[] { "1" }, 0, 0, true)]
        [TestCase(new string[] { "9999", "9799", "9499", "9199" }, 1, 1, true)]
        [TestCase(new string[] { "9199", "9799", "9799", "9199" }, 1, 1, false)]
        [TestCase(new string[] { "9199", "9799", "9499", "9999" }, 1, 1, false)]
        public void GivenInput_Coords_DetermineIfVisibleFromBottom(string[] input, int row, int col, bool expected)
        {
            List<string> list = input.ToList();

            Day8 day = new Day8(list);
            Assert.That(day.IsTreeVisibleBottom(row, col), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(new string[] { "1" }, 0, 0, true)]
        [TestCase(new string[] { "9999", "1479", "9999", "9999" }, 1, 2, true)]
        [TestCase(new string[] { "9999", "1779", "9999", "9999" }, 1, 2, false)]
        [TestCase(new string[] { "9999", "9479", "9999", "9999" }, 1, 2, false)]
        public void GivenInput_Coords_DetermineIfVisibleFromLeft(string[] input, int row, int col, bool expected)
        {
            List<string> list = input.ToList();

            Day8 day = new Day8(list);
            Assert.That(day.IsTreeVisibleLeft(row, col), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(new string[] { "1" }, 0, 0, true)]
        [TestCase(new string[] { "9999", "9741", "9999", "9999" }, 1, 1, true)]
        [TestCase(new string[] { "9999", "9771", "9999", "9999" }, 1, 1, false)]
        [TestCase(new string[] { "9999", "9749", "9999", "9999" }, 1, 1, false)]
        public void GivenInput_Coords_DetermineIfVisibleFromRight(string[] input, int row, int col, bool expected)
        {
            List<string> list = input.ToList();

            Day8 day = new Day8(list);
            Assert.That(day.IsTreeVisibleRight(row, col), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(new string[] { "1" }, 1)]
        [TestCase(new string[] { "9999", "9741", "9999", "9999" }, 14)]
        [TestCase(new string[] { "9999", "9771", "9999", "9999" }, 13)]
        [TestCase(new string[] { "9999", "9749", "9999", "9999" }, 12)]
        [TestCase(new string[] { "30373",
                                 "25512",
                                 "65332",
                                 "33549",
                                 "35390" }, 21)]
        public void GivenInput_DetermineCountOfVisibleTrees(string[] input, int expected)
        {
            List<string> list = input.ToList();

            Day8 day = new Day8(list);
            Assert.That(day.GetVisibleTreeCount(), Is.EqualTo(expected));
        }


        [Test]
        [TestCase(new string[] { "123", "456", "789", }, 0, 0, 0)]
        [TestCase(new string[] { "123", "456", "789", }, 1, 0, 1)]
        [TestCase(new string[] { "123", "456", "789", }, 2, 0, 2)]
        [TestCase(new string[] { "123", "756", "789", }, 2, 0, 1)]
        [TestCase(new string[] { "923", "456", "789", }, 2, 0, 2)]
        [TestCase(new string[] { "4", "4", "7", "8", "8" }, 3, 0, 3)]
        public void GivenList_Coords_FindScenicTopScore(string[] input, int row, int col, int expected)
        {
            List<string> list = input.ToList();

            Day8 day = new Day8(list);
            Assert.That(day.GetScenicScoreTop(row, col), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(new string[] { "9", "9", "7", "8", "8" }, 0, 0, 1)]
        [TestCase(new string[] { "9", "9", "7", "8", "8" }, 1, 0, 3)]
        [TestCase(new string[] { "9", "9", "7", "9", "8" }, 1, 0, 2)]
        [TestCase(new string[] { "9", "9", "7", "9", "8" }, 4, 0, 0)]
        public void GivenList_Coords_FindScenicBottomScore(string[] input, int row, int col, int expected)
        {
            List<string> list = input.ToList();

            Day8 day = new Day8(list);
            Assert.That(day.GetScenicScoreBottom(row, col), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(new string[] { "91234" }, 0, 0, 4)]
        [TestCase(new string[] { "97672" }, 0, 1, 2)]
        [TestCase(new string[] { "97732" }, 0, 1, 1)]
        [TestCase(new string[] { "97674" }, 0, 4, 0)]
        [TestCase(new string[] { "25521" }, 0, 2, 2)]
        public void GivenList_Coords_FindScenicRightScore(string[] input, int row, int col, int expected)
        {
            List<string> list = input.ToList();

            Day8 day = new Day8(list);
            Assert.That(day.GetScenicScoreRight(row, col), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(new string[] { "91234" }, 0, 4, 4)]
        [TestCase(new string[] { "97672" }, 0, 3, 2)]
        [TestCase(new string[] { "89732" }, 0, 2, 1)]
        [TestCase(new string[] { "97674" }, 0, 0, 0)]
        public void GivenList_Coords_FindScenicLeftScore(string[] input, int row, int col, int expected)
        {
            List<string> list = input.ToList();

            Day8 day = new Day8(list);
            Assert.That(day.GetScenicScoreLeft(row, col), Is.EqualTo(expected));
        }

        [Test]
        [TestCase(new string[] { "123", "456", "789" }, 1)]
        [TestCase(new string[] { "30373",
                                 "25512",
                                 "65332",
                                 "33549",
                                 "35390" }, 8)]
        public void GivenInput_FindMacScenicScore(string[] input, int expected)
        {

            List<string> list = input.ToList();

            Day8 day = new Day8(list);
            int actual = day.FindMaxScenicScore();

            Assert.That(actual, Is.EqualTo(expected));
        }


    }
}

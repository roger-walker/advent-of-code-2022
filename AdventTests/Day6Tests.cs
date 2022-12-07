using AdventOfCode2022;

namespace AdventTests
{
    internal class Day6Tests
    {
        [Test]
        [TestCase("", false)]
        [TestCase("abc", false)]
        [TestCase("abac", false)]
        [TestCase("abcd", true)]
        [TestCase("zxwq", true)]
        public void GivenFourCharacters_IsStart(string message, bool expected)
        {
            Day6 day = new Day6();

            bool actual = day.IsStart(message);

            Assert.That(actual, Is.EqualTo(expected));
        }

        

        [Test]
        [TestCase("abc", -1)]
        [TestCase("abcd", 4)]
        [TestCase("abca", -1)]
        [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
        [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
        [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 6)]
        [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
        [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
        public void GivenMessage_ReturnStartofPacket(string message, int expected)
        {
            Day6 day = new Day6();

            int actual = day.FindStartIndex(message);

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
        [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
        [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 23)]
        [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
        [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
        public void GivenMessage_ReturnStartofMessage(string message, int expected)
        {
            Day6 day = new Day6(isMessageCheck: true);

            int actual = day.FindStartIndex(message);

            Assert.That(actual, Is.EqualTo(expected));
        }

    }
}

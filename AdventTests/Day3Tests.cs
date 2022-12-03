using AdventOfCode2022;
using NUnit.Framework;

namespace AdventTests
{
    internal class Day3Tests
    {
        [SetUp]
        public void Setup() { }


        [Test]
        [TestCase("", "", "")]
        [TestCase("ab", "a", "b")]
        [TestCase("abcdef", "abc", "def")]
        public void GivenString_SplitIntoComparments(string rucksack, string comp1, string comp2)
        {
            Day3 day3 = new Day3();
            List<string> actual = day3.SplitIntoCompartments(rucksack);
            Assume.That(actual.Count, Is.EqualTo(2));

            var expected = new List<string>() { comp1, comp2 };

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("a", "a", "a")]
        [TestCase("ab", "ac", "a")]
        [TestCase("abcXdef", "hijklmnX", "X")]
        public void Given2Compartments_FindMatchingItem(string comp1, string comp2, string expected)
        {
            Day3 day = new Day3();
            string actual = day.FindMatchingItem(comp1, comp2);

            Assert.That(actual, Is.EqualTo(expected));

         }

        [Test]
        [TestCase("a", 1)]
        [TestCase("p", 16)]
        [TestCase("P", 42)]
        [TestCase("v", 22)]
        [TestCase("t", 20)]
        [TestCase("s", 19)]
        public void GivenMatchingItem_FindPriority(string item, int expected)
        {
            Day3 day3 = new Day3();
            int actual = day3.FindItemPriority(item);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("aa", 1)]
        [TestCase("bb", 2)]
        [TestCase("vJrwpWtwJgWrhcsFMMfFFhFp", 16)]
        [TestCase("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 38)]
        [TestCase("PmmdzqPrVvPwwTWBwg", 42)]
        [TestCase("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", 22)]
        [TestCase("ttgJtRGJQctTZtZT", 20)]
        [TestCase("CrZsJsPPZsGzwwsLwLmpwMDw", 19)]

        public void GivenRucksack_FindRucksackPriority(string rucksack, int expected)
        {
            Day3 day = new Day3();

            int actual = day.FindRucksackPriority(rucksack);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenListOfRucksacks_FindTotalPriority()
        {
            List<string> rucks = new List<string>()
            {
                "vJrwpWtwJgWrhcsFMMfFFhFp",
                "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
                "PmmdzqPrVvPwwTWBwg",
                "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
                "ttgJtRGJQctTZtZT",
                "CrZsJsPPZsGzwwsLwLmpwMDw"
            };

            Day3 day = new Day3(rucks);
            int total = day.FindTotalPriority();

            Assert.That(total, Is.EqualTo(157));
        }
    }
}

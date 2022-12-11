using AdventOfCode2022;

namespace AdventTests
{
    internal class Day11Tests
    {



        [Test]
        [TestCase(new string [] { "Monkey 0:"}, 1)]
        [TestCase(new string [] { "Monkey 0:", "Monkey : 1"}, 2)]
        [TestCase(new string [] { "Monkey 0:", "  Starting items: 79, 98", "Monkey : 1"}, 2)]
        public void EnsureThatRightNumberMonkeys(string [] input, int expected)
        {
            Day11 day = new Day11();
            day.ParseInput(input.ToList());
            Assert.That(day.Monkeys.Count, Is.EqualTo(expected));
        }
        [Test]
        [TestCase(new string[] { "Monkey 0:" }, new int[] { })]
        [TestCase(new string[] { "Monkey 0:", "  Starting items: 79, 98" }, new int[] { 79, 98 })]
        public void GivenMonkey_EnsureStartingItems(string[] input, int[] startingItems)
        {
            Day11 day = new Day11();
            day.ParseInput(input.ToList());
            var items = day.Monkeys[0].Items;
            Assert.That(items, Is.EqualTo(startingItems.ToList()));
        }

        [Test]
        [TestCase(new string[] {
                    "Monkey 0:",
                    "  Starting items: 79, 98", 
                    "Monkey 1:", 
                    "  Starting items: 54, 65, 75, 74" },
                    new int[] { 79, 98 }, new int[] { 54, 65, 75, 74 })]
        public void GivenMonkeys_EnsureStartingItems(string[] input, int[] items0, int [] items1)
        {
            Day11 day = new Day11();
            day.ParseInput(input.ToList());
            var act0 = day.Monkeys[0].Items;
            var act1 = day.Monkeys[1].Items;
            Assert.That(act0, Is.EqualTo(items0.ToList()));
            Assert.That(act1, Is.EqualTo(items1.ToList()));
        }

        [Test]
        [TestCase(new string[] {
                    "Monkey 0:",
                    "  Starting items: 79, 98",
                    "Operation: new = old * 19",
                    "Monkey 1:",
                    "  Starting items: 54, 65, 75, 74",
                    "Operation: new = old + 6"
                }, new int[] { 1501, 60 })]
        public void GivenMonkeys_EnsureOperations(string[] input, int[] expecteds)
        {
            Day11 day = new Day11();
            day.ParseInput(input.ToList());
            var act0 = day.Monkeys[0].Operation(day.Monkeys[0].Items[0]);
            var act1 = day.Monkeys[1].Operation(day.Monkeys[1].Items[0]);
            
            
            Assert.That(act0, Is.EqualTo(expecteds[0]));
            Assert.That(act1, Is.EqualTo(expecteds[1]));
            
        }

        [Test]
        [TestCase("  Starting items: 1", new int[] { 1 })]
        [TestCase("  Starting items: 2", new int[] { 2 })]
        [TestCase("  Starting items: 78, 98", new int[] { 78, 98 })]
        [TestCase("  Starting items: 78, 98, 20", new int[] { 78, 98, 20 })]
        public void GivenStartingItems_ReturnList(string items, int[] expected)
        {
            var day = new Day11();
            var actual = day.ParseStartingItems(items);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCase("Operation: new = old * 19", 2, 38)]
        [TestCase("Operation: new = old + 6", 2, 8)]
        [TestCase("Operation: new = old * old", 8, 64)]
        [TestCase("Operation: new = old + old", 8, 16)]
        public void GivenOperation_FindResult(string oper, int old, int expected)
        {
            var day = new Day11();
            var del = day.FindOperation(oper);
            var actual = del(old);

            Assert.That(actual, Is.EqualTo(expected));
        }

    }
}

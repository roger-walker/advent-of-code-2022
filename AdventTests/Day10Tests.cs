using AdventOfCode2022;






namespace AdventTests
{
    internal class Day10Tests
    {
        [Test]
        [TestCase(new string[] { "noop" }, new int[] { 1, 1 })]
        [TestCase(new string[] { "noop", "noop" }, new int[] { 1, 1, 1 })]
        [TestCase(new string[] { "addx 3" }, new int[] { 1, 1, 4 })]
        [TestCase(new string[] { "noop","addx 3","addx -5" }, new int[] { 1, 1, 1, 4, 4, -1 })]
        public void GivenInstructions_GetRegisterValue(string[] instr, int[] expected)
        {


            Day10 day = new Day10();
            var actual = day.RunInstructions(instr.ToList());


            Assert.That(actual, Is.EqualTo(expected));

        }


        [Test]
        [TestCase(new string[] {
                "addx 15",
                "addx -11",
                "addx 6",
                "addx -3",
                "addx 5",
                "addx -1",
                "addx -8",
                "addx 13",
                "addx 4",
                "noop",
                "addx -1",
                "addx 5",
                "addx -1",
                "addx 5",
                "addx -1",
                "addx 5",
                "addx -1",
                "addx 5",
                "addx -1",
                "addx -35",
                "addx 1",
                "addx 24",
                "addx -19",
                "addx 1",
                "addx 16",
                "addx -11",
                "noop",
                "noop",
                "addx 21",
                "addx -15",
                "noop",
                "noop",
                "addx -3",
                "addx 9",
                "addx 1",
                "addx -3",
                "addx 8",
                "addx 1",
                "addx 5",
                "noop",
                "noop",
                "noop",
                "noop",
                "noop",
                "addx -36",
                "noop",
                "addx 1",
                "addx 7",
                "noop",
                "noop",
                "noop",
                "addx 2",
                "addx 6",
                "noop",
                "noop",
                "noop",
                "noop",
                "noop",
                "addx 1",
                "noop",
                "noop",
                "addx 7",
                "addx 1",
                "noop",
                "addx -13",
                "addx 13",
                "addx 7",
                "noop",
                "addx 1",
                "addx -33",
                "noop",
                "noop",
                "noop",
                "addx 2",
                "noop",
                "noop",
                "noop",
                "addx 8",
                "noop",
                "addx -1",
                "addx 2",
                "addx 1",
                "noop",
                "addx 17",
                "addx -9",
                "addx 1",
                "addx 1",
                "addx -3",
                "addx 11",
                "noop",
                "noop",
                "addx 1",
                "noop",
                "addx 1",
                "noop",
                "noop",
                "addx -13",
                "addx -19",
                "addx 1",
                "addx 3",
                "addx 26",
                "addx -30",
                "addx 12",
                "addx -1",
                "addx 3",
                "addx 1",
                "noop",
                "noop",
                "noop",
                "addx -9",
                "addx 18",
                "addx 1",
                "addx 2",
                "noop",
                "noop",
                "addx 9",
                "noop",
                "noop",
                "noop",
                "addx -1",
                "addx 2",
                "addx -37",
                "addx 1",
                "addx 3",
                "noop",
                "addx 15",
                "addx -21",
                "addx 22",
                "addx -6",
                "addx 1",
                "noop",
                "addx 2",
                "addx 1",
                "noop",
                "addx -10",
                "noop",
                "noop",
                "addx 20",
                "addx 1",
                "addx 2",
                "addx 2",
                "addx -6",
                "addx -11",
                "noop",
                "noop",
                "noop",
                }, new int[] { 420, 1140, 1800, 2940, 2880, 3960 })]
        public void GivenInstr_GetRegVals_GetSignalStrength(string [] instr, int[] expected)
        {
            Day10 day = new Day10();
            var cycles = day.RunInstructions(instr.ToList());
            var actual = day.GetSignalStrength(cycles);

            var image = day.DrawImage(cycles);


            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(day.FindSumSignalStrengths(instr.ToList()), Is.EqualTo(13140));
            Assert.That(image, Is.EqualTo(SampleImage));
        }

        public string SampleImage = 
@"
##..##..##..##..##..##..##..##..##..##..
###...###...###...###...###...###...###.
####....####....####....####....####....
#####.....#####.....#####.....#####.....
######......######......######......####
#######.......#######.......#######.....";


        [Test]
        [TestCase("noop", Operation.Noop, 0)]
        [TestCase("addx 3", Operation.AddX, 3)]
        [TestCase("addx -5", Operation.AddX, -5)]
        public void GivenInst_DetermineOpandValue(string op, Operation expOp, int expValue)
        {
            Day10 day = new Day10();
            var (actOp, actVal) = day.GetOp(op);

            Assert.Multiple(() =>
            {
                Assert.That(actOp, Is.EqualTo(expOp));
                Assert.That(actVal, Is.EqualTo(expValue));
            });
        }
    }
}

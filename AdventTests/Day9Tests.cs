using AdventOfCode2022;
using System.Collections;

namespace AdventTests
{


    internal class Day9Tests
    {
        internal class MoveHeadTests : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { "R 1", new List<Location>() { new Location(1, 0) } };
                yield return new object[] { "R 3", new List<Location>() { new Location(1, 0), new Location(2, 0), new Location(3, 0) } };
                yield return new object[] { "D 2", new List<Location>() { new Location(0, -1), new Location(0, -2) } };
            }
        }

        [Test]
        [TestCaseSource(typeof(MoveHeadTests))]
        public void MoveHead(string instr, List<Location> expected)
        {
            Day9 day = new Day9();

            List<Location> actual = day.MoveHead(instr);
            Assert.That(actual, Is.EquivalentTo(expected));

        }

        [Test]
        [TestCase(0, 0, 0, 0, true)]
        [TestCase(0, 0, -1, 1, true)]
        [TestCase(0, 0, 0, 1, true)]
        [TestCase(0, 0, 1, 1, true)]
        [TestCase(0, 0, -1, 0, true)]
        [TestCase(0, 0, 0, 0, true)]
        [TestCase(0, 0, 1, 0, true)]
        [TestCase(0, 0, -1, -1, true)]
        [TestCase(0, 0, 0, -1, true)]
        [TestCase(0, 0, 1, -1, true)]
        [TestCase(0, 0, -2, 2, false)]
        [TestCase(0, 0, -1, 2, false)]
        [TestCase(0, 0, 2, 1, false)]
        [TestCase(0, 0, 0, -2, false)]
        [TestCase(0, 0, -2, -1, false)]
        [TestCase(3, 3, 4, 3, true)]
        public void GivenCurrHeadAndTailLocations_IsAdjacent(int hX, int hY, int tX, int tY, bool expected)
        {
            Day9 day = new Day9();
            day.Head = new Location(hX, hY);
            day.Tail = new Location(tX, tY);

            Assert.That(day.IsAdjacent(day.Head, day.Tail), Is.EqualTo(expected));
        }


        [Test]
        [TestCase(0, 2, 0, 0, 0, 1)]
        [TestCase(0, -2, 0, 0, 0, -1)]
        [TestCase(2, 0, 0, 0, 1, 0)]
        [TestCase(-2, 0, 0, 0, -1, 0)]
        [TestCase(2, 2, 0, 0, 1, 1)]
        [TestCase(2, -2, 0, 0, 1, -1)]
        [TestCase(-2, -2, 0, 0, -1, -1)]
        [TestCase(-2, 2, 0, 0, -1, 1)]
        [TestCase(4, 2, 3, 0, 4, 1)]
        public void GivenCurrHeadAndTailLocation_MoveTail(int hX, int hY, int tX, int tY, int expX, int expY)
        {
            Day9 day = new Day9();
            day.Head = new Location(hX, hY);
            day.Tail = new Location(tX, tY);

            Assume.That(day.IsAdjacent(day.Head, day.Tail), Is.False);

            Location actual = day.MoveTail(day.Head, day.Tail);

            Assert.Multiple(() =>
            {
                Assert.That(actual.X, Is.EqualTo(expX));
                Assert.That(actual.Y, Is.EqualTo(expY));
                Assert.That(day.IsAdjacent(day.Head, day.Tail), Is.True);
            });
        }

        [Test]
        [TestCase("R 1", Direction.Right, 1)]
        [TestCase("L 8", Direction.Left, 8)]
        [TestCase("U -10", Direction.Up, -10)]
        [TestCase("D 3", Direction.Down, 3)]
        [TestCase("F 3", Direction.Unknown, 3)]
        public void GivenInstruction_GetDirectionDistance(string instr, Direction expDir, int expDist)
        {
            Day9 day = new Day9();
            (Direction actDir, int actDist) = day.GetDirectionDistance(instr);

            Assert.Multiple(() =>
            {
                Assert.That(actDir, Is.EqualTo(expDir));
                Assert.That(actDist, Is.EqualTo(expDist));
            });
        }

        internal class MoveTests : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] { new Location(0, 0), Direction.Right, new Location(1, 0) };
                yield return new object[] { new Location(1, 1), Direction.Up, new Location(1, 2) };
                yield return new object[] { new Location(3, 6), Direction.Left, new Location(2, 6) };
                yield return new object[] { new Location(9, 13), Direction.Down, new Location(9, 12) };
            }
        }

        [Test]
        [TestCaseSource(typeof(MoveTests))]
        public void GivenLocationAndDirection_ReturnNext(Location curr, Direction dir, Location expected)
        {
            Day9 day = new Day9();
            Location actual = day.Move(curr, dir);

            Assert.That(actual, Is.EqualTo(expected));
        }

        internal class MoveTailTests : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] {
                    new string[] { "R 3" },
                    new HashSet<Location>(){ new Location(0,0), new Location(1,0), new Location(2,0) },
                    3
                };

                yield return new object[] {
                    new string[] { "R 3", "L 3" },
                    new HashSet<Location>(){ new Location(0,0), new Location(1,0), new Location(2,0) },
                    3
                };

                yield return new object[] {
                    new string[] {  "R 4",
                                    "U 4",
                                    "L 3",
                                    "D 1",
                                    "R 4",
                                    "D 1",
                                    "L 5",
                                    "R 2"
                    },
                    new HashSet<Location>(){ new Location(0,0),
                                             new Location(1,0),
                                             new Location(2,0),
                                             new Location(3,0),
                                             new Location(4,1),
                                             new Location(4,2),
                                             new Location(4,3),
                                             new Location(3,4),
                                             new Location(2,4),
                                             new Location(3,3),
                                             new Location(3,2),
                                             new Location(2,2),
                                             new Location(1,2)
                    },
                    13
                };

            }
        }

        [Test]
        [TestCaseSource(typeof(MoveTailTests))]
        public void GivenInst_EnsureTailLocations(string[] instr, HashSet<Location> expected, int count)
        {
            Day9 day = new Day9();
            day.RunInstructions(instr.ToList());

            Assert.That(day.TailLocations, Is.EquivalentTo(expected));
            Assert.That(day.GetTailPositions(), Is.EqualTo(count));

        }


        internal class MoveLongTailTests : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                yield return new object[] {
                    new string[] {  "R 5",
                                    "U 8",
                                    "L 8",
                                    "D 3",
                                    "R 17",
                                    "D 10",
                                    "L 25",
                                    "U 20"
                    },
                    new HashSet<Location>(){ new Location(0,0),
                                             new Location(1,1),
                                             new Location(2,2),
                                             new Location(1,3),
                                             new Location(2,4),
                                             new Location(3,5),
                                             new Location(4,5),
                                             new Location(5,5),
                                             new Location(6,4),
                                             new Location(7,3),
                                             new Location(8,2),
                                             new Location(9,1),
                                             new Location(10,0),
                                             new Location(9,-1),
                                             new Location(8,-2),
                                             new Location(7,-3),
                                             new Location(6,-4),
                                             new Location(5,-5),
                                             new Location(4,-5),
                                             new Location(3,-5),
                                             new Location(2,-5),
                                             new Location(1,-5),
                                             new Location(0,-5),
                                             new Location(-1,-5),
                                             new Location(-2,-5),
                                             new Location(-3,-4),
                                             new Location(-4,-3),
                                             new Location(-5,-2),
                                             new Location(-6,-1),
                                             new Location(-7,0),
                                             new Location(-8,1),
                                             new Location(-9,2),
                                             new Location(-10,3),
                                             new Location(-11,4),
                                             new Location(-11,5),
                                             new Location(-11,6),
                    },
                    36
                };
            }
        }

        [Test]
        [TestCaseSource(typeof(MoveLongTailTests))]
        public void GivenInst_EnsureLongTailLocations(string[] instr, HashSet<Location> expected, int count)
        {
            Day9 day = new Day9(8);
            day.RunInstructions(instr.ToList());

            Assert.That(day.TailLocations, Is.EquivalentTo(expected));
            Assert.That(day.GetTailPositions(), Is.EqualTo(count));

        }

    }
}

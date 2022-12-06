using AdventOfCode2022;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventTests
{
    internal class Day5Tests
    {
        [Test]
        [TestCase("move 1 from 2 to 1", 1, 2, 1)]
        [TestCase("move 3 from 1 to 3", 3, 1, 3)]
        [TestCase("move 2 from 2 to 1", 2, 2, 1)]
        [TestCase("move 1 from 1 to 2", 1, 1, 2)]
        public void GivenRearrangement_FindQuantityToAndFrom(string rearr, int expectedQty, int expectedFrom, int expectedTo)
        {
            Day5 day = new Day5();

            (int actualQty, int actualFrom, int actualTo) = day.FindRearragementValues(rearr);

            Assert.Multiple(() =>
            {
                Assert.That(actualQty, Is.EqualTo(expectedQty));
                Assert.That(actualFrom, Is.EqualTo(expectedFrom));
                Assert.That(actualTo, Is.EqualTo(expectedTo));
            });
        }

        public class MoveStackCases : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {

                // move 1 from 2 to 1
                yield return new object[] {
                    new List<Stack<string>>(){
                        new Stack<string>(new string[] {"Z", "N"}),
                        new Stack<string>( new string[] {"M", "C", "D"}),
                        new Stack<string>(new string[] { "P" })
                    },
                    1,2,1,
                    new List<Stack<string>>(){
                        new Stack<string>(new string [] { "Z", "N", "D"}),
                        new Stack<string>(new string [] { "M", "C"}),
                        new Stack<string>(new string [] { "P" })
                    }
                };

                // move 3 from 1 to 3
                yield return new object[] {
                    new List<Stack<string>>(){
                        new Stack<string>(new string [] { "Z", "N", "D"}),
                        new Stack<string>(new string [] { "M", "C"}),
                        new Stack<string>(new string [] { "P" })
                    },
                    3,1,3,
                    new List<Stack<string>>(){
                        new Stack<string>(new string [] {}),
                        new Stack<string>(new string [] { "M", "C"}),
                        new Stack<string>(new string [] { "P", "D", "N", "Z" })
                    }
                };

                // move 2 from 2 to 1
                yield return new object[] {
                    new List<Stack<string>>(){
                        new Stack<string>(new string [] {}),
                        new Stack<string>(new string [] { "M", "C"}),
                        new Stack<string>(new string [] { "P", "D", "N", "Z" })
                    },
                    2,2,1,
                    new List<Stack<string>>(){
                        new Stack<string>(new string [] { "C", "M" }),
                        new Stack<string>(new string [] {}),
                        new Stack<string>(new string [] { "P", "D", "N", "Z" })
                    }
                };

                // move 1 from 1 to 2
                yield return new object[] {
                    new List<Stack<string>>(){
                        new Stack<string>(new string [] { "C", "M" }),
                        new Stack<string>(new string [] {}),
                        new Stack<string>(new string [] { "P", "D", "N", "Z" })
                    },
                    1,1,2,
                    new List<Stack<string>>(){
                        new Stack<string>(new string [] { "C"}),
                        new Stack<string>(new string [] { "M" }),
                        new Stack<string>(new string [] { "P", "D", "N", "Z" })
                    }
                };

            }

        }

        [Test]
        [TestCaseSource(typeof(MoveStackCases))]
        public void GivenRearrangeValuesAndStacks_PerformRearrange(List<Stack<string>> start, int qty ,int from ,int to, List<Stack<string>> expected)
        {
            Day5 day = new Day5();
            var actual = day.PerformRearrange(start, qty, from, to);
            
            Assert.That(actual, Is.EqualTo(expected));

        }
        private class MessageStackCases : IEnumerable
        {

            public IEnumerator GetEnumerator()
            {
                yield return new object[] {
                    new List<Stack<string>>(){
                        new Stack<string>(new string[] {"Z", "N"}),
                        new Stack<string>( new string[] {"M", "C", "D"}),
                        new Stack<string>(new string[] { "P" })
                    },
                    "NDP"
                };

                yield return new object[] {
                    new List<Stack<string>>(){
                        new Stack<string>(new string [] {}),
                        new Stack<string>(new string [] { "M", "C"}),
                        new Stack<string>(new string [] { "P", "D", "N", "Z" })
                    },
                    "CZ"
                };

            }

        }

        [Test]
        [TestCaseSource(typeof(MessageStackCases))]
        public void GivenStack_GenerateMessage(List<Stack<string>> stacks, string expected)
        {
            Day5 day = new Day5();

            var actual = day.GenerateMessage(stacks);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenStartAndMoveList_GenerateEndMessage()
        {
            var start = new List<Stack<string>>(){
                        new Stack<string>(new string[] {"Z", "N"}),
                        new Stack<string>( new string[] {"M", "C", "D"}),
                        new Stack<string>(new string[] { "P" })
                    };

            List<string> moves = new List<string>()
            {
                "move 1 from 2 to 1",
                "move 3 from 1 to 3",
                "move 2 from 2 to 1",
                "move 1 from 1 to 2"
            };

            Day5 day = new Day5();
            var message = day.PerformMoves(start, moves);

            Assert.That(message, Is.EqualTo("CMZ"));
        }


    }
}

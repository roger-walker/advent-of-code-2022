using AdventOfCode2022;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventTests
{
    internal class Day5Tests
    {
        [Test]
        [TestCase("move 1 from 1 to 2", 1, 1, 2)]
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
    }
}

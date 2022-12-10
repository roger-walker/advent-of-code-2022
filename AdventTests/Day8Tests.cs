using AdventOfCode2022;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}

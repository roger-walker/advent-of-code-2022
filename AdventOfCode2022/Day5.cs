using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public class Day5
    {
        public (int, int, int) FindRearragementValues(string rearr)
        {
            int qty = 0, from = 0, to = 0;

            string pattern = @"move (\d+) from (\d+) to (\d+)";
            Match m = Regex.Match(rearr, pattern);
            if (m.Success)
            {
                qty = Convert.ToInt32(m.Groups[1].Value);
                from = Convert.ToInt32(m.Groups[2].Value);
                to = Convert.ToInt32(m.Groups[3].Value);
            }

            return (qty, from, to);
        }
    }
}

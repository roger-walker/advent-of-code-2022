using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public class Day4
    {
        public List<string> SplitPair(string pair)
        {
            var split = pair.Split(',').ToList();

            return split;
        }


        public (int actualStart, int actualEnd) FindRangeBoundaries(string range)
        {
            var boundaries = range.Split('-');
            return (Convert.ToInt32(boundaries[0]), Convert.ToInt32(boundaries[1]));
        }

        public bool IsFullyContained(int s1, int e1, int s2, int e2)
        {
            return (s1 <= s2 && e2 <= e1) || (s2 <= s1 && e1 <= e2);
        }

        public int TotalFullyContained(List<string> assignments)
        {
            return assignments.Aggregate(0, (acc, c) =>
            {
                List<string> split = SplitPair(c);
                (int s1, int e1) = FindRangeBoundaries(split[0]);
                (int s2, int e2) = FindRangeBoundaries(split[1]);

                return IsFullyContained(s1, e1, s2, e2) ? acc + 1 : acc;
            });
        }

        public bool IsSomeOverlap(int s1, int e1, int s2, int e2)
        {
            return (s1 <= s2 && s2 <= e1) || (s2 <= s1 && s1 <= e2);
        }

        public int TotalSomeOverlap(List<string> assignments)
        {
            return assignments.Aggregate(0, (acc, c) =>
            {
                List<string> split = SplitPair(c);
                (int s1, int e1) = FindRangeBoundaries(split[0]);
                (int s2, int e2) = FindRangeBoundaries(split[1]);

                return IsSomeOverlap(s1, e1, s2, e2) ? acc + 1 : acc;
            });
        }
    }
}

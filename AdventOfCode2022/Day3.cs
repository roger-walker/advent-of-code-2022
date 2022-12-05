using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public class Day3
    {
        public List<string> Rucksacks { get; set; }

        public Day3()
        {
            Rucksacks = new List<string>();
        }

        public Day3(List<string> rucks)
        {
            Rucksacks = rucks;
        }

        public List<string> SplitIntoCompartments(string rucksack)
        {
            int half = rucksack.Length / 2;
            string comp1  = rucksack.Substring(0, half);
            string comp2  = rucksack.Substring(half);

            return new List<string>() { comp1, comp2 };
        }

        public string FindMatchingItem(string comp1, string comp2)
        {
            string match = "";

            foreach(var item in comp1)
            {
                if (comp2.Any(x => x == item))
                {
                    match = "" +  item;
                }
            }

            return match;
        }

        public int FindItemPriority(string item)
        {
            char ch = item[0];

            return Char.IsLower(ch) ? ch - 'a' + 1 : ch - 'A' + 27;
        }

        public int FindRucksackPriority(string rucksack)
        {
            var comps = SplitIntoCompartments(rucksack);
            var item = FindMatchingItem(comps);
            return FindItemPriority(item);
        }

        private string FindMatchingItem(List<string> comps)
        {
            return FindMatchingItem(comps[0], comps[1]);
        }

        public int FindTotalPriority()
        {
            return Rucksacks.Aggregate(0, (acc, c) => acc + FindRucksackPriority(c));
        }

        public string FindBadge(string bag1, string bag2, string bag3)
        {
            string match = "";
            foreach(var item in bag1)
            {
                if (bag2.Any(x => x == item) && bag3.Any(x => x == item))
                {
                    match = "" + item;
                }
            }
            return match;
        }

        public int FindTotalBadgePriority()
        {
            int total = 0;  
            for (int i = 0; i < Rucksacks.Count; i+=3)
            {
                string bag1 = Rucksacks[i];
                string bag2 = Rucksacks[i+1];
                string bag3 = Rucksacks[i+2];

                string badge = FindBadge(bag1, bag2, bag3);
                total += FindItemPriority(badge);
            }
            return total;
        }
    }
}

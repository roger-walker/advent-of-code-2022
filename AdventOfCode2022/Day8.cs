using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public class Day8
    {
        public Day8(List<string> list)
        {
            list.ForEach(x =>
            {
                List<int> row = new List<int>();
                
                var trees = x.Split();
                trees.ToList().ForEach(t => row.Add(Convert.ToInt32(t)));
                TreeMap.Add(row);
            });
        }

        public List<List<int>> TreeMap { get; } = new List<List<int>>();
    }
}

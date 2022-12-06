using System.Text.RegularExpressions;

namespace AdventOfCode2022
{
    public class Day5
    {
        /*
                            [L]     [H] [W]
                        [J] [Z] [J] [Q] [Q]
        [S]             [M] [C] [T] [F] [B]
        [P]     [H]     [B] [D] [G] [B] [P]
        [W]     [L] [D] [D] [J] [W] [T] [C]
        [N] [T] [R] [T] [T] [T] [M] [M] [G]
        [J] [S] [Q] [S] [Z] [W] [P] [G] [D]
        [Z] [G] [V] [V] [Q] [M] [L] [N] [R]
         1   2   3   4   5   6   7   8   9 

        */
        public List<Stack<string>> Start = new List<Stack<string>>()
        {
            new Stack<string>(new string [] { "Z","J","N","W","P","S" }),
            new Stack<string>(new string [] { "G","S","T"}),
            new Stack<string>(new string [] { "V","Q","R","L","H"}),
            new Stack<string>(new string [] { "V","S","T","D"}),
            new Stack<string>(new string [] { "Q","Z","T","D","B","M","J" }),
            new Stack<string>(new string [] { "M","W","T","J","D","C","Z","L" }),
            new Stack<string>(new string [] { "L","P","M","W","G","T","J" }),
            new Stack<string>(new string [] { "N","G","M","T","B","F","Q","H" }),
            new Stack<string>(new string [] { "R","D","G","C","P","B","Q","W" }),
        };

        public Day5(bool is9001 = false)
        {
            Is9001 = is9001;
        }

        public bool Is9001 { get; }

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

        public List<Stack<string>> PerformRearrange(List<Stack<string>> start, int qty, int from, int to)
        {
            return Is9001 ? AdvancedRearrange(start, qty, from, to) : StandardRearrange(start, qty, from, to);
        }

        private List<Stack<string>> AdvancedRearrange(List<Stack<string>> start, int qty, int from, int to)
        {
            List<Stack<string>> result = new List<Stack<string>>(start);
            List<string> temp = new List<string>();
            while (qty > 0)
            {
                temp.Add(result[from - 1].Pop());
                qty--;
            }

            temp.Reverse();
            foreach (var item in temp)
            {
                result[to - 1].Push(item);
            }

            return result;
        }

        private List<Stack<string>> StandardRearrange(List<Stack<string>> start, int qty, int from, int to)
        {
            List<Stack<string>> result = new List<Stack<string>>(start);

            while (qty > 0)
            {
                result[to - 1].Push(result[from - 1].Pop());
                qty--;
            }

            return result;
        }

        public string GenerateMessage(List<Stack<string>> stacks)
        {
            return stacks.Aggregate("", (acc, c) => c.Count > 0 ? acc + c.Pop() : acc);
        }

        public string PerformMoves(List<Stack<string>> stacks, List<string> moves)
        {
            foreach (var move in moves)
            {
                (int qty, int from, int to) = FindRearragementValues(move);
                stacks = PerformRearrange(stacks, qty, from, to);
            }
            return GenerateMessage(stacks);
        }
    }
}

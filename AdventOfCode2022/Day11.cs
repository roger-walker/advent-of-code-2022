namespace AdventOfCode2022
{
    public class Monkey
    {
        public List<int> Items { get; set; } = new List<int>();
        public Func<int, int> Operation { get; internal set; }
    }

    public class Day11
    {
        public List<Monkey> Monkeys { get; set; } = new List<Monkey>();

        public Day11()
        {

        }

        public void ParseInput(List<string> list)
        {
            Monkey current = new Monkey();
            
            foreach(string key in list)
            {
                if (key.StartsWith("Monkey"))
                {
                    current = new Monkey();
                    Monkeys.Add(current);
                }
                else if (key.Contains("Starting items:"))
                {
                    current.Items = ParseStartingItems(key);
                }
                else if (key.Contains("Operation:"))
                {
                    current.Operation = FindOperation(key);
                }
            }
        }

        public List<int> ParseStartingItems(string key)
        {
            var split = key.Split(':');
            string items = split[1].Trim();
            return items.Split(',').Select(x => Convert.ToInt32(x)).ToList();

        }

        public Func<int, int> FindOperation(string oper)
        {
            var split = oper.Split(':');
            string op = split[1].Trim();

            bool addition = op.Contains('+');

            var vals = op.Split('+', '*');
            //bool old0 = vals[0].Contains("old");
            bool old1 = vals[1].Contains("old");

            int val1 = !old1 ? Convert.ToInt32(vals[1]) : 0;
            
            if (addition && old1)
            {
                return (old) => { return old + old; };
            }
            else if (addition && !old1)
            {
                return (old) => { return old + val1; };
            }
            else if (!addition && old1)
            {
                return (old) => { return old * old; };
            }
            else
            {
                return (old) => { return old * val1; };
            }
        }
    }
}

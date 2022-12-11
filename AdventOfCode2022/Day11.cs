namespace AdventOfCode2022
{
    public class Monkey
    {
        public List<long> Items { get; set; } = new List<long>();
        public Func<long, long> Operation { get; internal set; }
        public long DivBy { get; internal set; }
        public int TrueResult { get; set; }
        public int FalseResult { get; set; }
        public int Inspection { get; internal set; } = 0;
    }

    public class Day11
    {
        public List<Monkey> Monkeys { get; set; } = new List<Monkey>();

        public bool Worry { get; set; }

        public Day11(bool worry = true)
        {
            Worry = worry;
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
                else if (key.Contains("Test: divisible by"))
                {
                    current.DivBy = FindDivTestValue(key);
                }
                else if (key.Contains(": throw to monkey"))
                {
                    (bool res, int val) = FindThrowTo(key);
                    if (res)
                    {
                        current.TrueResult = val;
                    }
                    else
                    {
                        current.FalseResult = val;
                    }
                }

            }
        }

        public List<long> ParseStartingItems(string key)
        {
            var split = key.Split(':');
            string items = split[1].Trim();
            return items.Split(',').Select(x => Convert.ToInt64(x)).ToList();

        }

        public Func<long, long> FindOperation(string oper)
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

        public int FindDivTestValue(string test)
        {
            var split = test.Split("divisible by ");
            return Convert.ToInt32(split[1]);
        }

        public (bool, int) FindThrowTo(string throwTo)
        {
            bool divResult = throwTo.Contains("If true:");

            var split = throwTo.Split("throw to monkey ");
            int monkeyTarget = Convert.ToInt32(split[1]);

            return (divResult, monkeyTarget);

        }

        public long RunMonkeys(int rounds)
        {
            long prodOfDiv = Monkeys.Select(m => m.DivBy)
                            .Aggregate(1L, (acc, cur) => { return acc * cur; });

            for(int i = 0; i < rounds; i++)
            {
                foreach(var monkey in Monkeys)
                {
                    while(monkey.Items.Count > 0)
                    {
                        monkey.Inspection++;

                        long curr = monkey.Items.First();
                        monkey.Items.RemoveAt(0);

                        curr = monkey.Operation(curr);

                        curr = Worry ? curr / 3 : curr % prodOfDiv;

                        int throwTo = curr % monkey.DivBy == 0 ? monkey.TrueResult : monkey.FalseResult;

                        Monkeys[throwTo].Items.Add(curr);
                    }
                }
            }

            List<long> inspects = new List<long>();
            foreach(var monkey in Monkeys)
            {
                inspects.Add(monkey.Inspection);
            }
            inspects.Sort();
            return inspects.TakeLast(2).Aggregate(1L, (acc, curr) => acc * curr);

        }
    }
}

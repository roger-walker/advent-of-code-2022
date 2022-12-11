namespace AdventOfCode2022
{
    public enum Operation
    {
        Unknown,
        Noop,
        AddX
    }


    public class Day10
    {
        Dictionary<Operation, int> execTime = new Dictionary<Operation, int>() {
                                        { Operation.Noop, 1 },
                                        { Operation.AddX, 2 }
                                };
        public List<int> RunInstructions(List<string> instructions)
        {
            int registerX = 1;

            List<int> cycles = new List<int>() { registerX };

            foreach (string instruction in instructions)
            {
                (Operation op, int val) = GetOp(instruction);
                if (op == Operation.Noop)
                {
                    cycles.Add(registerX);
                }
                else
                {
                    cycles.Add(registerX);
                    registerX += val;
                    cycles.Add(registerX);
                }
            }

            return cycles;
        }

        public (Operation, int) GetOp(string op)
        {
            Operation oper = Operation.Unknown;
            int val = 0;
            if (op.StartsWith("noop")) 
            {
                oper = Operation.Noop;
            }
            else
            {
                var split = op.Split(' ');
                if (split[0].StartsWith("addx"))
                {
                    oper = Operation.AddX;
                    val = Convert.ToInt32(split[1]);
                }
            }

            return (oper, val);
        }

        public List<int> GetSignalStrength(List<int> cycles)
        {

            List<int> signals = new List<int>();

            int curr = 20;
            int incr = 40;
            for (int i = curr; i <= cycles.Count; i+= incr)
            {
                signals.Add(i * cycles[i - 1]);
            }

            return signals;

        }

        public int FindSumSignalStrengths(List<string> instr)
        {
            var cycles = RunInstructions(instr);
            var signals = GetSignalStrength(cycles);
            int sum = signals.Sum();
            return sum;
        }

        public string DrawImage(List<int> cycles)
        {
            string image = "";
            for(int i = 0; i < cycles.Count - 1; i++)
            {
                if (i % 40 == 0) image += Environment.NewLine;

                int pix = i % 40;

                if (pix -1 <= cycles[i] && cycles[i] <= pix +1)
                {
                    image += "#";
                }
                else
                {
                    image += ".";
                }


            }
            return image;
        }
    }
}

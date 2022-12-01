using System.IO;

namespace AdventOfCode2022
{
    internal class Day1
    {
        List<Elf> elves = new List<Elf>();

        public string FileName { get; set; }

        public Day1(string fileName)
        {
            FileName = fileName;
            Setup();
        }

        public void Setup()
        {
            using (StreamReader sr = File.OpenText(FileName))
            {
                string? line;

                Elf curr = new Elf();
                while ((line = sr.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        curr.CalorieCount += Convert.ToInt32(line);
                    }
                    else
                    {
                        elves.Add(curr);
                        curr = new Elf();
                    }
                }
                elves.Add(curr);
            }
        }

        public int Max()
        {
            return elves.Max(e => e.CalorieCount);
        }

        public int TopThree()
        {
            elves.Sort();
            elves.Reverse();
            return elves.Take(3).Aggregate(0, (acc, e) => acc + e.CalorieCount);
        }

        internal class Elf : IComparable<Elf>
        {
            public int CalorieCount { get; set; }

            public int CompareTo(Elf? other)
            {
                if (other == null)
                {
                    return 1;
                }
                else
                {
                    return this.CalorieCount.CompareTo(other.CalorieCount);
                }
            }
        }

    }

}

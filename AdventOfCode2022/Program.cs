// See https://aka.ms/new-console-template for more information


using AdventOfCode2022;


string input = "../../../Inputs/day1-1.txt";

Day1 day1 = new Day1(input);

int maxElf = day1.Max();
Console.WriteLine($"Max Cal: {maxElf}");

int top3 = day1.TopThree();
Console.WriteLine($"Top Three: {top3}");

var results = GetFileInput("../../../Inputs/day2-1.txt");

Day2 day2 = new Day2(results);
Console.WriteLine($"Day 2 results: {day2.TallyScore()}");

Day2 day2part2 = new Day2(results, useDecisionMap: true);
Console.WriteLine($"Day 2 part 2 results: {day2part2.TallyScore()}");

var day3Rucks = GetFileInput("../../../Inputs/day3-1.txt");
Day3 day3 = new Day3(day3Rucks);
Console.WriteLine($"Day 3 Total Priority: {day3.FindTotalPriority()}");
Console.WriteLine($"Day 3 Badge Priority: {day3.FindTotalBadgePriority()}");


var day4Assignments = GetFileInput("../../../Inputs/day4-1.txt");
Day4 day4 = new Day4();
Console.WriteLine($"Day 4 Total Fully Container: {day4.TotalFullyContained(day4Assignments)}");
Console.WriteLine($"Day 4 Total Some Overlap: {day4.TotalSomeOverlap(day4Assignments)}");



var day5Moves = GetFileInput("../../../Inputs/day5.txt");
Day5 day5 = new Day5();
Console.WriteLine($"Day 5 Message: {day5.PerformMoves(day5.Start, day5Moves)}");

Day5 day5b = new Day5(is9001: true);
Console.WriteLine($"Day 5 Message: {day5b.PerformMoves(day5b.Start, day5Moves)}");

var day6Message = GetFileInput("../../../Inputs/day6.txt");
Day6 day6 = new Day6();
Console.WriteLine($"Day 6 Start of Packet: {day6.FindStartIndex(day6Message.First())}");

Day6 day6b = new Day6(isMessageCheck: true);
Console.WriteLine($"Day 6 Start of Message: {day6b.FindStartIndex(day6Message.First())}");

var day7cmds = GetFileInput("../../../Inputs/day7.txt");
Day7 day7 = new Day7();
Console.WriteLine($"Day 7 Small Dir Sum: {day7.SmallSum(day7cmds)}");
Console.WriteLine($"Day 7 Small Dir to Delete: {day7.FindSmallestDirToDeleteSize(day7cmds, 70000000, 30000000)}");

var day8map = GetFileInput("../../../Inputs/day8.txt");
Day8 day8 = new Day8(day8map);

Console.WriteLine($"Day 8 visible trees: {day8.GetVisibleTreeCount()}");
Console.WriteLine($"Day 8 Most Scenic: {day8.FindMaxScenicScore()}");

var day9moves = GetFileInput("../../../Inputs/day9.txt");
Day9 day9 = new Day9();
day9.RunInstructions(day9moves);
Console.WriteLine($"Day 9: Tail Move Count: {day9.GetTailPositions()}");

Day9 day9b = new Day9(8);
day9b.RunInstructions(day9moves);
Console.WriteLine($"Day 9: Long Tail Move Count: {day9b.GetTailPositions()}");

var day10ops = GetFileInput("../../../Inputs/day10.txt");
Day10 day10 = new Day10();
Console.WriteLine($"Day 10: Signal Strengths Sum: {day10.FindSumSignalStrengths(day10ops)}");

var day10Image = day10.DrawImage(day10.RunInstructions(day10ops));
Console.Write("========================================");
Console.WriteLine(day10Image);
Console.WriteLine("========================================");



static List<string> GetFileInput(string fileName)
{
    List<string> list = new List<string>();
    string line = null;

    using (StreamReader sr = new StreamReader(fileName))
    {
        while ((line = sr.ReadLine()) != null)
        {
            list.Add(line);
        }
    }
    return list;
}


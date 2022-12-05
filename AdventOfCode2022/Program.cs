﻿// See https://aka.ms/new-console-template for more information


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
Day3 day3 = new Day3 (day3Rucks);
Console.WriteLine($"Day 3 Total Priority: {day3.FindTotalPriority()}");
Console.WriteLine($"Day 3 Badge Priority: {day3.FindTotalBadgePriority()}");


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
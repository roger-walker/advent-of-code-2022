// See https://aka.ms/new-console-template for more information


using AdventOfCode2022;


string input = "../../../Inputs/day1-1.txt";

Day1 day1 = new Day1(input);

int maxElf = day1.Max();
Console.WriteLine($"Max Cal: {maxElf}");

int top3 = day1.TopThree();
Console.WriteLine($"Top Three: {top3}");
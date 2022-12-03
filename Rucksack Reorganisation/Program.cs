using System;
using System.IO;
using System.Collections.Generic;

namespace Rucksack_Reorganisation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("C:/Users/lukej/source/repos/AdventOfCode2022/Rucksack Reorganisation/Day3Input.txt");
            List<string[]> backpacks = new List<string[]>();
            for (int n = 0; n < input.Length; n++)
            {
                backpacks.Add(new string[2]);
                for (int i = 0; i < input[n].Length; i++)
                {
                    if (i < input[n].Length / 2) { backpacks[n][0] += input[n][i]; }
                    else { backpacks[n][1] += input[n][i]; }
                }
            }

            // Part 1
            int totalSum = 0;
            foreach (string[] backpack in backpacks)
            {
                List<char> similarCharacters = new List<char>();
                foreach(char n in backpack[0])
                {
                    foreach (char n2 in backpack[1])
                    {
                        if (n == n2)
                        {
                            if (!similarCharacters.Contains(n))
                            {
                                similarCharacters.Add(n);
                            }
                        }
                    }
                }

                foreach (char c in similarCharacters)
                {
                    if ((int)c < 91) { totalSum += (int)c - 38; }
                    else { totalSum += (int)c - 96; }
                }
            }
            Console.WriteLine("Part 1: " + totalSum);

            // Part 2
            int badgeSum = 0;
            for (int i = 0; i < backpacks.Count; i+=3)
            {
                char badge = 'a';
                foreach (char c1 in backpacks[i][0] + backpacks[i][1])
                {
                    if ((backpacks[i+1][0] + backpacks[i + 1][1]).Contains(c1) && (backpacks[i + 2][0] + backpacks[i + 2][1]).Contains(c1))
                    {
                        badge = c1;
                        break;
                    }
                }

                if ((int)badge < 91)
                {
                    badgeSum += (int)badge - 38;
                }
                else
                {
                    badgeSum += (int)badge - 96;
                }
            }

            Console.WriteLine("Part 2: " + badgeSum);
        }
    }
}

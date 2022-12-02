using System;
using System.IO;
using System.Collections.Generic;

namespace Calorie_Counting
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("C:/Users/lukej/source/repos/AdventOfCode2022/Calorie Counting/Day1Input.txt");
            List<int> elves = new List<int>();
            int currentElf = 0;

            elves.Add(new int());
            foreach (string item in input)
            {
                if (item != "")
                {
                    elves[currentElf] += Convert.ToInt32(item);
                }
                else
                {
                    currentElf++;
                    elves.Add(new int());
                }
            }

            // Part 1

            int biggestElf = 0;
            foreach (int elf in elves)
            {
                if (elf > biggestElf)
                {
                    biggestElf = elf;
                }
            }

            Console.WriteLine("Part 1: " + biggestElf);

            // Part 2

            int elf1 = 0;
            int elf2 = 0;
            int elf3 = 0;
            foreach (int elf in elves)
            {
                if (elf > elf1) { elf3 = elf2; elf2 = elf1; elf1 = elf; }
                else if (elf > elf2) { elf3 = elf2; elf2 = elf; }
                else if (elf > elf3) { elf3 = elf; }
            }

            Console.WriteLine("Part 2: " + (elf1 + elf2 + elf3));
        }
    }
}

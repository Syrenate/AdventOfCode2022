using System;
using System.IO;

namespace Camp_Cleanup
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] pairs = File.ReadAllLines("C:/Users/lukej/source/repos/AdventOfCode2022/Camp Cleanup/Day4Input.txt");

            // Part 1
            int containsSum = 0;
            foreach (string pair in pairs)
            {
                string[] section = pair.Split(",");
                int[,] sections = new int[2, 2];
                sections[0, 0] = Convert.ToInt32(section[0].Split("-")[0]);
                sections[0, 1] = Convert.ToInt32(section[0].Split("-")[1]);
                sections[1, 0] = Convert.ToInt32(section[1].Split("-")[0]);
                sections[1, 1] = Convert.ToInt32(section[1].Split("-")[1]);

                if (sections[0, 0] == sections[1, 0])
                {
                    containsSum++;
                }
                else if (sections[0, 1] == sections[1, 1])
                {
                    containsSum++;
                }
                else if (sections[0, 0] <= sections[1, 0] && sections[0, 1] >= sections[1, 1])
                {
                    containsSum++;
                }
                else if (sections[0, 0] >= sections[1, 0] && sections[0, 1] <= sections[1, 1])
                {
                    containsSum++;
                }
            }
            Console.WriteLine("Part 1: " + containsSum);

            // Part 2
            int overlapSum = 0;
            foreach (string pair in pairs)
            {
                string[] section = pair.Split(",");
                int[,] sections = new int[2, 2];
                sections[0, 0] = Convert.ToInt32(section[0].Split("-")[0]);
                sections[0, 1] = Convert.ToInt32(section[0].Split("-")[1]);
                sections[1, 0] = Convert.ToInt32(section[1].Split("-")[0]);
                sections[1, 1] = Convert.ToInt32(section[1].Split("-")[1]);

                if (sections[0,0] <= sections[1,1] && sections[0,1] >= sections[1, 0])
                {
                    overlapSum++;
                }
                else if (sections[0, 0] >= sections[1, 1] && sections[0, 1] <= sections[1, 0])
                {
                    overlapSum++;
                }
            }
            Console.WriteLine("Part 2: " + overlapSum);
        }
    }
}

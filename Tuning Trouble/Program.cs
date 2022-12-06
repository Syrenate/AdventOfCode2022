using System;
using System.Collections.Generic;
using System.IO;

namespace Tuning_Trouble
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("C:/Users/lukej/source/repos/AdventOfCode2022/Tuning Trouble/Day6Input.txt");

            bool marker = true;
            Queue<char> buffer = new Queue<char>();
            for (int i = 3; i < input.Length; i++)
            {
                buffer.Enqueue(input[i]);
                // Part 2 just changed 3s to 13s, very minor change
                if (i >= 3)
                {
                    marker = true;
                    for (int j1 = i-3; j1 < i+1; j1++)
                    {
                        for (int j2 = i-3; j2 < i+1; j2++)
                        {
                            if (j1 != j2 && input[j1] == input[j2])
                            {
                                marker = false; j1 = i+1; j2 = i+1;
                            }
                        }
                    }
                    if (marker == true)
                    {
                        Console.WriteLine("Part 1: " + (i + 1));
                        i = input.Length;
                    }
                }
                buffer.Dequeue();
            }
        }
    }
}

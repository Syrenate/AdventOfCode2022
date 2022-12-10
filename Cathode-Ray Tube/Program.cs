using System;
using System.Collections.Generic;
using System.IO;

namespace Cathode_Ray_Tube
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("C:\\Users\\lukej\\source\\repos\\AdventOfCode2022\\Cathode-Ray Tube\\Day10Input.txt");

            int totalCycles = 0;
            foreach (string line in input)
            {
                if (line.Contains("add"))
                {
                    totalCycles++;
                }
                totalCycles++;
            }

            int X = 1;

            List<char[]> screen = new List<char[]>();
            screen.Add(new char[40]);
            int currentLine = 0;

            bool addOp = false;
            bool addNOW = false;
            int instruction = 0;

            int sumSignal = 0;

            for (int cycle = 0; cycle < totalCycles; cycle++)
            {
                int screenPos = cycle % 40;
                if (screen[currentLine][39] == '.' || screen[currentLine][39] == '#')
                {
                    screen.Add(new char[40]);
                    currentLine++;
                }

                if (cycle != 0)
                {
                    if (input[instruction].Contains("add"))
                    {
                        if (addOp == true) // Start of second add cycle
                        {
                            addOp = false;
                            addNOW = true;
                        }
                        else // Start of first add cycle
                        {
                            addOp = true;
                        }
                    }
                    else
                    {
                        instruction++;
                    }

                    if ((cycle + 20) % 40 == 0 && cycle < 230)
                    {
                        sumSignal += cycle * X;
                    }

                    if (addNOW) // End of second add cycle
                    {
                        X += Convert.ToInt32(input[instruction].Split(" ")[1]);
                        addNOW = false;
                        instruction++;
                    }
                }

                if (screenPos >= X - 1 && screenPos <= X + 1)
                {
                    screen[currentLine][screenPos] = '#';
                }
                else
                {
                    screen[currentLine][screenPos] = '.';
                }
            }

            Console.WriteLine("Part 1: " + sumSignal);
            foreach (char[] line in screen)
            {
                Console.WriteLine("");
                foreach(char c in line)
                {
                    Console.Write(c);
                }
            }
        }
    }
}

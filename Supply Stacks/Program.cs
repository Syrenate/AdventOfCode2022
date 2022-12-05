using System;
using System.IO;
using System.Collections.Generic;

namespace Supply_Stacks
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("C:/Users/lukej/source/repos/AdventOfCode2022/Supply Stacks/Day5Input.txt");

            List<Stack<char>> stacks = new List<Stack<char>>();
            int stackLength = 0;
            int stackHeight = 0;
            bool cont = true;
            foreach (string line in input)
            {
                if (!line.Contains('[') && !line.Contains("move") && line != null)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        if ((int)line[i] - 48 > stackLength)
                        {
                            stackLength = (int)line[i] - 48;
                        }
                    }
                    cont = false;
                }
                if (cont == true) { stackHeight++; }
            }

            for (int i = 0; i < stackLength; i++)
            {
                stacks.Add(new Stack<char>());
            }

            string[] boxStacks = new string[stackHeight];
            for (int i = 0; i < stackHeight; i++)
            {
                boxStacks[i] = input[stackHeight - i - 1];
            }
            for (int i = 0; i < stackHeight; i++)
            {
                input[i] = boxStacks[i];
            }

            foreach (string line in input)
            {
                if (line.Contains('['))
                {
                    for (int i = 1; i < line.Length; i += 4)
                    {
                        if (line[i] != ' ')
                        {
                            stacks[(i-1)/4].Push(line[i]);
                        }
                    }
                }

                else if (line.Contains("move"))
                {
                    string[] lineParts = line.Split(" ");
                    int quant = Convert.ToInt32(lineParts[1]);
                    int start = Convert.ToInt32(lineParts[3]);
                    int end = Convert.ToInt32(lineParts[5]);

                    //// Part 1
                    //for (int i = 0; i < quant; i++)
                    //{
                    //    stacks[end - 1].Push(stacks[start - 1].Pop());
                    //}

                    // Part 2
                    Stack<char> buffer = new Stack<char>();
                    for (int i = 0; i < quant; i++)
                    {
                        buffer.Push(stacks[start - 1].Pop());
                    }
                    for (int i = 0; i < quant; i++)
                    {
                        stacks[end - 1].Push(buffer.Pop());
                    }
                }
            }

            string result = "";
            foreach (Stack<char> s in stacks)
            {
                result += s.Pop();
            }

            Console.WriteLine(result);
        }
    }
}

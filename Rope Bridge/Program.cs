using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Rope_Bridge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("C:\\Users\\lukej\\source\\repos\\AdventOfCode2022\\Rope Bridge\\Day9Input.txt");

            bool part1 = false;
            bool part2 = true;

            if (part1)
            {
                int[] headPos = new int[2] { 0, 0 };
                int[] tailPos = new int[2] { 0, 0 };

                List<int[]> visited = new List<int[]>();

                int count = 0;
                foreach (string s in input)
                {
                    string[] line = s.Split(" ");

                    for (int i = 0; i < Convert.ToInt32(line[1]); i++)
                    {
                        bool isStart = false;
                        if (count == 0)
                        {
                            isStart = true;
                        }

                        switch (line[0])
                        {
                            case "U":
                                headPos[1]++;
                                break;
                            case "D":
                                headPos[1]--;
                                break;
                            case "L":
                                headPos[0]--;
                                break;
                            case "R":
                                headPos[0]++;
                                break;
                        }

                        if (!isStart)
                        {
                            bool diagonal = false;
                            if (headPos[0] != tailPos[0] && headPos[1] != tailPos[1])
                            {
                                diagonal = true;
                            }

                            if (!diagonal)
                            {
                                if (headPos[1] - tailPos[1] > 1)
                                {
                                    tailPos[1]++;
                                }
                                else if (tailPos[1] - headPos[1] > 1)
                                {
                                    tailPos[1]--;
                                }

                                if (headPos[0] - tailPos[0] > 1)
                                {
                                    tailPos[0]++;
                                }
                                else if (tailPos[0] - headPos[0] > 1)
                                {
                                    tailPos[0]--;
                                }
                            }
                            else
                            {
                                if (Math.Abs(headPos[0] - tailPos[0]) > 1 || Math.Abs(headPos[1] - tailPos[1]) > 1)
                                {
                                    if (headPos[0] > tailPos[0])
                                    {
                                        tailPos[0]++;
                                    }
                                    else
                                    {
                                        tailPos[0]--;
                                    }

                                    if (headPos[1] > tailPos[1])
                                    {
                                        tailPos[1]++;
                                    }
                                    else
                                    {
                                        tailPos[1]--;
                                    }
                                }
                            }
                        }

                        if (!visited.Contains(new int[2] { tailPos[0], tailPos[1] }))
                        {
                            visited.Add(new int[2] { tailPos[0], tailPos[1] });
                        }

                        count++;
                    }
                }

                List<int[]> valid = new List<int[]>();
                foreach (var n1 in visited)
                {
                    bool contains = false;
                    foreach (var n2 in valid)
                    {
                        if (n1[0] == n2[0] && n1[1] == n2[1])
                        {
                            contains = true; break;
                        }
                    }

                    if (!contains)
                    {
                        valid.Add(n1);
                    }
                }

                Console.WriteLine(valid.Count());
            }

            else if (part2)
            {
                int[,] tailPos = new int[10, 2];

                List<int[]> visited = new List<int[]>();

                int count = 0;
                foreach (string s in input)
                {
                    string[] line = s.Split(" ");

                    for (int i = 0; i < Convert.ToInt32(line[1]); i++)
                    {
                        bool isStart = false;
                        if (count == 0)
                        {
                            isStart = true;
                        }

                        switch (line[0])
                        {
                            case "U":
                                tailPos[0, 1]++;
                                break;
                            case "D":
                                tailPos[0, 1]--;
                                break;
                            case "L":
                                tailPos[0, 0]--;
                                break;
                            case "R":
                                tailPos[0, 0]++;
                                break;
                        }

                        if (!isStart)
                        {
                            for (int n = 1; n < 10; n++)
                            {
                                bool diagonal = false;
                                if (tailPos[n - 1, 0] != tailPos[n, 0] && tailPos[n - 1, 1] != tailPos[n, 1])
                                {
                                    diagonal = true;
                                }

                                if (!diagonal)
                                {
                                    if (tailPos[n - 1, 1] - tailPos[n, 1] > 1)
                                    {
                                        tailPos[n, 1]++;
                                    }
                                    else if (tailPos[n, 1] - tailPos[n - 1, 1] > 1)
                                    {
                                        tailPos[n, 1]--;
                                    }

                                    if (tailPos[n - 1, 0] - tailPos[n, 0] > 1)
                                    {
                                        tailPos[n, 0]++;
                                    }
                                    else if (tailPos[n, 0] - tailPos[n - 1, 0] > 1)
                                    {
                                        tailPos[n, 0]--;
                                    }
                                }
                                else
                                {
                                    if (Math.Abs(tailPos[n - 1, 0] - tailPos[n, 0]) > 1 || Math.Abs(tailPos[n - 1, 1] - tailPos[n, 1]) > 1)
                                    {
                                        if (tailPos[n - 1, 0] > tailPos[n, 0])
                                        {
                                            tailPos[n, 0]++;
                                        }
                                        else
                                        {
                                            tailPos[n, 0]--;
                                        }

                                        if (tailPos[n-1, 1] > tailPos[n, 1])
                                        {
                                            tailPos[n, 1]++;
                                        }
                                        else
                                        {
                                            tailPos[n, 1]--;
                                        }
                                    }
                                }
                            }

                            if (!visited.Contains(new int[2] { tailPos[9,0], tailPos[9,1] }))
                            {
                                visited.Add(new int[2] { tailPos[9,0], tailPos[9,1] });
                            }
                        }

                        count++;
                    }
                }

                List<int[]> valid = new List<int[]>();
                foreach (var n1 in visited)
                {
                    bool contains = false;
                    foreach (var n2 in valid)
                    {
                        if (n1[0] == n2[0] && n1[1] == n2[1])
                        {
                            contains = true; break;
                        }
                    }

                    if (!contains)
                    {
                        valid.Add(n1);
                    }
                }

                Console.WriteLine(valid.Count());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;

namespace Treetop_Tree_House
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("C:\\Users\\lukej\\source\\repos\\AdventOfCode2022\\Treetop Tree House\\Day8Input.txt");
            int[,] trees = new int[input[0].Length, input.Length];
            int[,] validTrees = new int[input[0].Length, input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++) { trees[i, j] = input[i][j] - 48; validTrees[i, j] = 0; }
            }

            // Part 1
            for (int i = 0; i < input.Length; i++) // From left side
            {
                bool cont = true;
                int biggestTree = -1;
                int count = 0;
                while (cont)
                {
                    if (trees[i, count] > biggestTree)
                    {
                        biggestTree = trees[i, count];
                    }
                    else if (trees[i,count] <= biggestTree)
                    {
                        validTrees[i, count]++;
                    }
                    count++;
                    if (count == input[i].Length)
                    {
                        cont = false;
                    }
                }
            }

            for (int i = 0; i < input.Length; i++) // From right side
            {
                bool cont = true;
                int biggestTree = -1;
                int count = input[i].Length - 1;
                while (cont)
                {
                    if (trees[i, count] > biggestTree)
                    {
                        biggestTree = trees[i, count];
                    }
                    else if (trees[i, count] <= biggestTree)
                    {
                        validTrees[i, count]++;
                    }
                    count--;
                    if (count == -1)
                    {
                        cont = false;
                    }
                }
            }

            for (int i = 0; i < input.Length; i++) // From top
            {
                bool cont = true;
                int biggestTree = -1;
                int count = 0;
                while (cont)
                {
                    if (trees[count, i] > biggestTree)
                    {
                        biggestTree = trees[count, i];
                    }
                    else if (trees[count, i] <= biggestTree)
                    {
                        validTrees[count, i]++;
                    }

                    count++;
                    if (count == input.Length)
                    {
                        cont = false;
                    }
                }
            }
            for (int i = 0; i < input.Length; i++) // From bottom
            {
                bool cont = true;
                int biggestTree = -1;
                int count = input.Length - 1;
                while (cont)
                {
                    if (trees[count, i] > biggestTree)
                    {
                        biggestTree = trees[count, i];
                    }
                    else if (trees[count, i] <= biggestTree)
                    {
                        validTrees[count, i]++;
                    }
                    count--;
                    if (count == -1)
                    {
                        cont = false;
                    }
                }
            }

            int visible = 0;
            for (int i = 0; i < validTrees.GetLength(0); i++)
            {
                for (int j = 0; j < validTrees.GetLength(1); j++)
                {
                    if (validTrees[i,j] != 4)
                    {
                        visible++;
                    }
                }
            }

            Console.WriteLine("Part 1: " + visible);




            // Part 2
            int highestScore = 0;
            for (int i = 0; i < trees.GetLength(0); i++)
            {
                for (int j = 0; j < validTrees.GetLength(1); j++)
                {
                    int scenicScore = 1;

                    int travel = 1;
                    int startTree = trees[i, j];
                    bool cont = true;
                    while (cont)
                    {
                        try
                        {
                            if (trees[i,j+travel] < startTree)
                            {
                                travel++;
                            }
                            else
                            {
                                scenicScore *= travel;
                                cont = false;
                            }
                        }
                        catch
                        {
                            scenicScore *= travel - 1;
                            cont = false;
                        }
                    }

                    travel = 1;
                    startTree = trees[i, j];
                    cont = true;
                    while (cont)
                    {
                        try
                        {
                            if (trees[i, j - travel] < startTree)
                            {
                                travel++;
                            }
                            else
                            {
                                scenicScore *= travel;
                                cont = false;
                            }
                        }
                        catch
                        {
                            scenicScore *= travel - 1;
                            cont = false;
                        }
                    }

                    travel = 1;
                    startTree = trees[i, j];
                    cont = true;
                    while (cont)
                    {
                        try
                        {
                            if (trees[i + travel, j] < startTree)
                            {
                                travel++;
                            }
                            else
                            {
                                scenicScore *= travel;
                                cont = false;
                            }
                        }
                        catch
                        {
                            scenicScore *= travel - 1;
                            cont = false;
                        }
                    }

                    travel = 1;
                    startTree = trees[i, j];
                    cont = true;
                    while (cont)
                    {
                        try
                        {
                            if (trees[i - travel, j] < startTree)
                            {
                                travel++;
                            }
                            else
                            {
                                scenicScore *= travel;
                                cont = false;
                            }
                        }
                        catch
                        {
                            scenicScore *= travel - 1;
                            cont = false;
                        }
                    }

                    if (scenicScore > highestScore)
                    {
                        highestScore = scenicScore;
                    }
                }
            }

            Console.WriteLine("Part 2: " + highestScore);
        }
    }
}

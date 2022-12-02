using System;
using System.IO;

namespace Rock_Paper_Scissors
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] games = File.ReadAllLines("C:/Users/lukej/source/repos/AdventOfCode2022/Rock Paper Scissors/Day2Input.txt");

            int totalScore = 0;
            int actualTotalScore = 0;

            foreach (string game in games)
            {
                // Part 1

                int gameScore = 0;
                int actualGameScore = 0;
                switch (game[0])
                {
                    case 'A':
                        if (game[2] == 'X') { gameScore += 3; actualGameScore += 3; }
                        else if (game[2] == 'Y') { gameScore += 6; actualGameScore += 1; }
                        else if (game[2] == 'Z') { actualGameScore += 2; }
                        break;
                    case 'B':
                        if (game[2] == 'X') { actualGameScore += 1; }
                        else if (game[2] == 'Y') { gameScore += 3; actualGameScore += 2; }
                        else if (game[2] == 'Z') { gameScore += 6; actualGameScore += 3; }
                        break;
                    case 'C':
                        if (game[2] == 'X') { gameScore += 6; actualGameScore += 2; }
                        else if (game[2] == 'Y') { actualGameScore += 3; }
                        else if (game[2] == 'Z') { gameScore += 3; actualGameScore += 1; }
                        break;
                }

                if (game[2] == 'X') { gameScore += 1; }
                else if (game[2] == 'Y') { gameScore += 2; actualGameScore += 3; }
                else if (game[2] == 'Z') { gameScore += 3; actualGameScore += 6; }

                totalScore += gameScore;
                actualTotalScore += actualGameScore;
            }

            Console.WriteLine("Part 1: " + totalScore);
            Console.WriteLine("Part 2: " + actualTotalScore);
        }
    }
}

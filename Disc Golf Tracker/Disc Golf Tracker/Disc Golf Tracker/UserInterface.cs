using System;
using System.Collections.Generic;
using System.Text;

namespace Disc_Golf_Tracker
{
    public sealed class UserInterface
    {
        Course course = new Course();
        Scorecard scoreKeeper = new Scorecard();
        Player player = new Player();
        public void Run()
        {
            Console.WriteLine("Welcome to Disc Golf Score Keeper");
            Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
            Console.WriteLine();

            bool done = false;

            while (!done)
            {
                Console.WriteLine();
                Console.WriteLine("**************************");
                Console.WriteLine("******* Main Menu ********");
                Console.WriteLine("**************************");
                Console.WriteLine();
                Console.WriteLine("1) Start New Round");
                Console.WriteLine("2) Quit");
                Console.WriteLine();

                string input = Console.ReadLine();

                if (input == "1")
                {
                    NewRoundSubMenu();
                }
                else if (input == "2")
                {
                    done = true;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("ERROR: Invalid input, please try again!");
                }
            }
        }
        public void NewRoundSubMenu()
        {
            Console.WriteLine();
            Console.WriteLine("New Round");
            Console.WriteLine("*-*-*-*-*");

            Console.WriteLine();
            Console.WriteLine("What is your name?");

            string playerName = Console.ReadLine();
            player.PlayerName = playerName;

            Console.WriteLine();
            Console.WriteLine("What is the name of the course you are playing?");

            string courseName = Console.ReadLine();
            course.CourseName = courseName;

            Console.WriteLine();
            Console.WriteLine("How many holes are you playing?");

            int numOfHoles = int.Parse(Console.ReadLine());
            course.NumOfHoles = numOfHoles;

            Console.WriteLine();
            Console.WriteLine($"Welcome to {course.CourseName} {player.PlayerName}");
            Console.WriteLine("Good Luck!");

            RoundOptionsMenu();


        }
        public void RoundOptionsMenu()
        {
            bool done = false;

            while (!done)
            {
                Console.WriteLine();
                Console.WriteLine($"Current Score: {player.CurrentScore}");
                Console.WriteLine();
                Console.WriteLine($"1) Record Hole Score");
                Console.WriteLine();
                Console.WriteLine($"2) Show ScoreCard");
                Console.WriteLine();
                Console.WriteLine($"3) End Round");
                Console.WriteLine();

                string roundOptionsInput = Console.ReadLine();

                if (roundOptionsInput == "1")
                {
                    Console.WriteLine();
                    Console.WriteLine("What hole are you on?");

                    string holeNumber = $"Hole {Console.ReadLine()}:";

                    Console.WriteLine();
                    Console.WriteLine("What was your score for this hole?");
                    Console.WriteLine("- If you scored Par, type in 0");
                    Console.WriteLine("- If you scored under Par, type a minus sign followed by the number of strokes you threw below Par");
                    Console.WriteLine("- If you scored over Par, type in the number of strokes you threw over Par");
                    Console.WriteLine();

                    int holeScore = int.Parse(Console.ReadLine());

                    GiveHoleComment(holeScore);

                    Hole hole = new Hole(holeNumber, holeScore);
                    player.PlayerHoleScores.Add(hole);
                    player.ModifyCurrentScore(holeScore);
                }
                if (roundOptionsInput == "2")
                {
                    if(player.PlayerHoleScores.Count == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("You haven't played any holes yet silly goose!");
                        Console.WriteLine();
                    }
                    else
                    {
                        scoreKeeper.ShowScoreCard(player);
                    }

                }

            }
        }

        public void GiveHoleComment (int holeScore)
        {
            if (holeScore <= -2)
            {
                Console.WriteLine();
                Console.WriteLine("Flyyy like an eaaaggglle!");
            }
            else if (holeScore == -1)
            {
                Console.WriteLine();
                Console.WriteLine("A little birdie told me you're great at Disc Golf");
            }
            else if (holeScore == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Can't be mad about Par!");
            }
            else if (holeScore >= 1)
            {
                Console.WriteLine();
                Console.WriteLine("Better luck next time Bud");
            }
        }
    }

}

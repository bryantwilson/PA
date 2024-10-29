using System;
using System.Collections.Generic;
using System.Globalization;


namespace PA
{
    class Program
    {
        static void Main(string[] args)
        {
            //write seed data, whipes table, creates new table, adds default posts(hard coded)
            //write sort by descending method, sorts data in console when called from the database(same as PA1)


            //DatabaseUtilities utils = new DatabaseUtilities();
            //utils.SortTimeStamp(); //how to sort by time descending in MySQL

            Hideseek();
        }

        public static void Hideseek()
        {
            // variables needed for game
            string spot = "";
            string prevGuess = "";
            int guesses = 4;
            Random rnd = new Random();
            int num = rnd.Next(1, 8);
            //you should already have tokens, can be removed
            int tokens = 0;

            // sets a random hiding spot
            switch (num)
            {
                case 1:
                    spot = "plant";
                    break;

                case 2:
                    spot = "couch";
                    break;

                case 3:
                    spot = "fridge";
                    break;

                case 4:
                    spot = "balcony";
                    break;

                case 5:
                    spot = "closet";
                    break;

                case 6:
                    spot = "bathtub";
                    break;

                case 7:
                    spot = "sink";
                    break;
            }
            //continues the game until player runs out of guesses
            while (guesses >= 0)
            {
                // check to see if the user can continue playing, if not return to menu
                if (guesses == 0)
                {
                    Console.WriteLine("You are out of guesses! Better luck next time!");
                    return; //change to your menu function
                }
                // get the users guess
                Console.WriteLine("Guess where the cat is hiding.");
                string guess = Console.ReadLine().ToLower();

                //if the user guess right, award tokens, and return to menu
                if (guess == spot)
                {
                    Console.WriteLine("That's Correct!");
                    tokens += 3;
                    return; //change to your menu function
                }
                //returns a default room temp
                else if (guesses == 4)
                {
                    Console.WriteLine("The room feels nice.");
                    Console.WriteLine(spot);
                    prevGuess = guess;
                    guesses--;
                }
                //compare the characters in the word, and return hotter or colder
                else
                {
                    CompareChars(guess, prevGuess);
                    prevGuess = guess;
                    guesses--;
                }
            }
        }

        public static void CompareChars(string one, string two)
        {
            char[] arr1 = one.ToCharArray();
            char[] arr2 = two.ToCharArray();
            //gets the characters in the guess
            foreach (char i in arr1)
            {
                //get the characters in the previous guess
                foreach (char j in arr2)
                {
                    //compare the characters and return hotter or colder
                    if (i < j)
                    {
                        Console.WriteLine("Hotter");
                        return; //Leave this
                    }

                    if (i > j)
                    {
                        Console.WriteLine("Colder");
                        return; //Leave this
                    }
                }
            }
        }
    }
}
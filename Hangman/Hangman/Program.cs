using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            HangmanGame game = new HangmanGame();

            string word = game.GenerateWord();
            SetColor(ConsoleColor.Yellow);
            Console.WriteLine($"The word consists of {word.Length} letters.");
            Console.WriteLine("Try to guess the word");
            ResetColor();

            while(game.GameStatus == Enums.GameStatus.InProgress)
            {
                try
                {
                    Console.Write("Pick a letter: ");
                    char c = char.Parse(Console.ReadLine());

                    string curState = game.GuessLetter(c);
                    Console.WriteLine(curState);

                    Console.WriteLine($"Remaining tries = {game.RemainingTries}");
                    Console.WriteLine($"Tried letters: {game.TriedLetters}");
                }
                catch (Exception ex)
                {
                    SetColor(ConsoleColor.Red);
                    Console.WriteLine(ex.Message);
                    ResetColor();
                }
            }

            if (game.GameStatus == Enums.GameStatus.Lost)
            {
                SetColor(ConsoleColor.Red);
                Console.WriteLine("You're hanged...");
                ResetColor();
                SetBackgroundColor(ConsoleColor.Blue);
                Console.WriteLine($"The word was: {game.Word}");
                ResetColor();
            }
            else if(game.GameStatus == Enums.GameStatus.Won)
            {
                SetBackgroundColor(ConsoleColor.Green);
                Console.WriteLine("You won the game!");
                ResetColor();
            }
        }


        private static void SetColor(ConsoleColor color)
            => Console.ForegroundColor = color;

        private static void ResetColor()
            => Console.ResetColor();

        private static void SetBackgroundColor(ConsoleColor color)
            => Console.BackgroundColor = color;

    }

}

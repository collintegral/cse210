using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGen = new Random();
        char repeatGame = 'y';

        do
        {
            int randomNum = randomGen.Next(1,101);
            int userGuess = 0, guessCount = 0;
            Console.Write("Guess a number between 1 and 100: ");
            do
            {
                userGuess = int.Parse(Console.ReadLine());
                if (userGuess > randomNum)
                {
                    Console.Write("Guess lower: ");
                }
                else if (userGuess < randomNum)
                {
                    Console.Write("Guess higher: ");
                }
                guessCount++;
            }
            while (userGuess != randomNum);

            Console.WriteLine($"You guessed it in {guessCount} tries!");

            Console.Write("Would you like to play again? (y/n): ");
            repeatGame = char.Parse(Console.ReadLine());
        }
        while (repeatGame == 'y');
    }
}
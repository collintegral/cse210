using System;
using System.ComponentModel;

class Program
{
    static void displayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int baseNum)
    {
        return baseNum * baseNum;
    }

    static void DisplayResult(string userName, int sqNum)
    {
        Console.WriteLine($"{userName}, the square of your number is {sqNum}");
    }

    static void Main(string[] args)
    {
        displayWelcome();
        DisplayResult(PromptUserName(), SquareNumber(PromptUserNumber()));        
    }
}
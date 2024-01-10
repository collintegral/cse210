using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        int gradePercent = int.Parse(Console.ReadLine());

        char letter, letterSign = ' ';
        if (gradePercent >= 90)
        {
            letter = 'A';
        }
        else if (gradePercent >= 80)
        {
            letter = 'B';
        }
        else if (gradePercent >= 70)
        {
            letter = 'C';
        }
        else if (gradePercent >= 60)
        {
            letter = 'D';
        }
        else
        {
            letter = 'F';
        }

        if (gradePercent % 10 >= 7 && letter != 'F' && letter != 'A')
        {
            letterSign = '+';
        }
        else if (gradePercent % 10 < 3 && letter != 'F')
        {
            letterSign = '-';
        }

        Console.WriteLine($"{letter}{letterSign}");

        if (gradePercent >= 70)
        {
            Console.WriteLine("You passed! Congratulations!");
        }
        else
        {
            Console.WriteLine("You haven't passed... You can do it next time!");
        }
    }
}
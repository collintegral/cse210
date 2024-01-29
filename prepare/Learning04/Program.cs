using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment sam = new("Samuel Bennet", "Multiplication");
        Console.WriteLine(sam.GetSummary());

        MathAssignment rob = new("Roberto Rodriguez", "Fractions", "Section 7.3", "8-19");
        Console.WriteLine(rob.GetSummary());
        Console.WriteLine(rob.GetHomeworkList());

        WritingAssignment mary = new("Mary Waters", "European History", "The Causes of World War II");
        Console.WriteLine(mary.GetSummary());
        Console.WriteLine(mary.GetWritingInformation());
    }
}
using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fract1 = new Fraction();
        Console.WriteLine(fract1.getFractionString());
        Console.WriteLine(fract1.getDecimalValue());
        Fraction fract2 = new Fraction(5);
        Console.WriteLine(fract2.getFractionString());
        Console.WriteLine(fract2.getDecimalValue());
        Fraction fract3 = new Fraction(3,4);
        Console.WriteLine(fract3.getFractionString());
        Console.WriteLine(fract3.getDecimalValue());
        Fraction fract4 = new Fraction(1,3);
        Console.WriteLine(fract4.getFractionString());
        Console.WriteLine(fract4.getDecimalValue());
    }
}
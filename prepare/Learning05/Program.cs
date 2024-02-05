using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new();

        shapes.Add(new Square("Red", 5));
        shapes.Add(new Rectangle("Blue", 10, 4));
        shapes.Add(new Circle("Green", 6));

        shapes.ForEach(shape => {
            Console.WriteLine($"{shape.GetColor()} {shape.GetType()} Area: {shape.GetArea()}");
        });
    }
}
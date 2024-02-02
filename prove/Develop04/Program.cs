using System;
using System.Collections;
using System.Runtime.InteropServices.Marshalling;

class Program
{
    static void Main(string[] args)
    {
        BreathingActivity breathe = new("Breathing Meditation", "This breathing activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing. Breathe in time to the pulsing meter that will appear.");
        ReflectionActivity reflect = new("Memory Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        ListingActivity list = new("List Enumeration", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        
        bool userExit = false;

        while (!userExit)
        {
            Console.Clear();
            Console.WriteLine("Welcome to guided meditation. Please select an activity from the list below.");
            Console.WriteLine("1. Breathing Meditation\n2. Memory Reflection\n3. List Enumeration\n4. Exit");

            string userInput = "";
            do
            {
                ConsoleKeyInfo keyPress = Console.ReadKey();
                if (keyPress.Key == ConsoleKey.Escape || keyPress.Key.ToString() == "D4")
                {
                    userExit = true;
                    break;
                }
                Console.Write("\b \b");
                userInput = keyPress.Key.ToString();
            }
            while (userInput != "D1" && userInput != "D2" && userInput != "D3");

            Console.Clear();
            switch (userInput)
            {
               case "D1":
               breathe.Run();
               break;
               case "D2":
               reflect.Run();
               break;
               case "D3":
               list.Run();
               break;
            }
        }
    }
}
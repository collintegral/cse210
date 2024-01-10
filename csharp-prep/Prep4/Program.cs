using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numList = new List<int> ();
        int listAdd;
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        do
        {
            Console.Write("Enter number: ");
            listAdd = int.Parse(Console.ReadLine());
            if (listAdd != 0)
            {
                numList.Add(listAdd);
            }
        }
        while (listAdd != 0);

        int listSum = 0, listLargest = numList[0], listSmallestPos = numList[0];
        float listAve = 0;

        foreach (int entry in numList)
        {
            listSum += entry;

            if (entry > listLargest)
            {
                listLargest = entry;
            }
            else if (entry < listSmallestPos && entry > 0)
            {
                listSmallestPos = entry;
            }
        }
        listAve = (float)listSum / (float)numList.Count;
        numList.Sort();

        Console.WriteLine($"The sum is: {listSum}");
        Console.WriteLine($"The average is: {listAve}");
        Console.WriteLine($"The largest number is: {listLargest}");
        Console.WriteLine($"The smallest positive number is: {listSmallestPos}");
        Console.Write($"The sorted list is: {numList[0]}");
        for (int i = 1; i < numList.Count; i++)
        {
            Console.Write($", {numList[i]}");
        }
    }
}
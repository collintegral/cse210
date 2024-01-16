using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Taylor";
        job1._startYear = "2022";
        job1._endYear = "2025";

        Job job2 = new Job();
        job2._jobTitle = "Software Developer";
        job2._company = "Venture";
        job2._startYear = "2020";
        job2._endYear = "2022";

        Resume myResume = new Resume();
        myResume._name = "Collin Christensen";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}
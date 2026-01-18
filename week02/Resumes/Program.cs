using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Forklifter";
        job1._company = "Cugat";
        job1._startYear = 2025;
        job1._endYear = 2026;

        Resume myResume = new Resume();
        myResume._name = "Franco Chumba";

        myResume._jobs.Add(job1);

        myResume.Display();
    }
}
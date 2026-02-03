using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("C# Basics", "Code Academy", 600);
        video1.AddComment(new Comment("Franco Chumba", "Great explanation! 10/10, a like and a new subscriber"));
        video1.AddComment(new Comment("Pablo Nicolas", "Very helpful, you deserve a thumbs up"));
        video1.AddComment(new Comment("Joaquin Perez", "Loved it. Can I get your LinkedIn for professional purposes?"));

        Video video2 = new Video("OOP Concepts", "Dev School", 900);
        video2.AddComment(new Comment("Flavio Adrian", "This cleared things up a little."));
        video2.AddComment(new Comment("Juana Aguilera", "Nice examples, although I found it a little complicated to understand"));
        video2.AddComment(new Comment("Jose Quevedo", "Well done, but there is room for improvement."));

        Video video3 = new Video("Abstraction in C#", "Tech World", 750);
        video3.AddComment(new Comment("Claudio Ale", "Straight to the point."));
        video3.AddComment(new Comment("Tania Salome", "Thanks for this."));
        video3.AddComment(new Comment("Tamara Silva", "Good pacing."));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetCommenterName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}

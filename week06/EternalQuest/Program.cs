/*Exceeding Requirements:
- Added a simple "Level" system based on the user's score. The program displays the current level title
next to the score (e.g., Beginner, Adventurer, Champion, Legend).*/

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}

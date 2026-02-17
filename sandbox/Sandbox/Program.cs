using System;

abstract class Animal
{
    public abstract void MakeSound();
}

class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Dog barks");
    }
}

class Program
{
    static void Main()
    {
        Animal myDog = new Dog();

        myDog.MakeSound();
    }
}
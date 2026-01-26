using System;
using System.Collections.Generic;

public class Scripture
{
    public Reference Ref { get; private set; }
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        Ref = reference;
        _words = new List<Word>();
        string[] words = text.Split(' ');
        foreach (var w in words)
            _words.Add(new Word(w));
    }

    public void Display()
    {
        Console.WriteLine(Ref.ToString());
        foreach (var w in _words)
            Console.Write(w.Display() + " ");
        Console.WriteLine("\n");
    }

    public void HideRandomWords(int count = 3, Random rnd = null)
    {
        if (rnd == null) rnd = new Random();

        for (int i = 0; i < count; i++)
        {
            int index = rnd.Next(_words.Count);
            _words[index].Hide();
        }
    }

    public bool AllHidden()
    {
        foreach (var w in _words)
            if (!w.IsHidden()) return false;
        return true;
    }
}

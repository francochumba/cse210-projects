using System;
using System.Collections.Generic;

public class Scripture
{
    public string ReferenceText { get; private set; }
    private List<Word> _words;

    public Scripture(string reference, string text)
    {
        ReferenceText = reference;
        _words = new List<Word>();

        string[] words = text.Split(' ');
        foreach (string w in words)
        {
            _words.Add(new Word(w));
        }
    }

    public void Display()
    {
        Console.WriteLine(ReferenceText);
        foreach (Word w in _words)
        {
            Console.Write(w.Display() + " ");
        }
        Console.WriteLine("\n");
    }

    public void HideRandomWords(int count = 3)
    {
        Random rnd = new Random();
        for (int i = 0; i < count; i++)
        {
            int index = rnd.Next(_words.Count);
            _words[index].Hide();
        }
    }

    public bool AllHidden()
    {
        foreach (Word w in _words)
        {
            if (!w.IsHidden())
                return false;
        }
        return true;
    }
}
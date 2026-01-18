using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "What is one thing I learned today?",
        "What was one small win I had today?",
        "What challenged me the most today?",
        "How did I take care of myself today, physically or mentally?",
        "What moment today made me pause or reflect?",
        "Where did I act according to my values today?",
        "Where did I struggle to act according to my values?",
        "What thoughts occupied my mind the most today?",
        "What did today reveal about my current priorities?",
        "In what situation did I grow, even if it was uncomfortable?",
        "What patterns do I notice repeating in my days lately?",
        "What fears or hopes surfaced today?",
        "How did my actions today align with the person I want to become?",
        "What is God inviting me to work on or surrender after today?",
        "What deeper truth about myself did today uncover?",
        "What would I change about how I lived today if I could relive it?"

    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}

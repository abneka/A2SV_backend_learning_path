using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace A2SVLearningPath
{
    public class Task02
    {
        public static void CountCharacter()
        {
            Console.WriteLine("Please Enter a sentence to count characters: ");
            string sentence = Console.ReadLine();

            foreach (KeyValuePair<char, int> pair in Task02.Counter(sentence))
            {
                Console.WriteLine("Char: " +  pair.Key + "      Count: " + pair.Value);
            }
            // Console.WriteLine(Task02.Counter(sentence));
        }
        
        public static Dictionary<char, int> Counter(string s)
        {
            Dictionary<char, int> count = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (char.IsLetter((c)))
                {
                    if (count.ContainsKey(c))
                    {
                        count[c]++;
                    }
                    else
                    {
                        count[c] = 1;
                    }
                }
            }

            return count;
        }
    }
}
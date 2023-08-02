using System;

namespace A2SVLearningPath
{
    public class Task03
    {
        public static void CheckPalindrome()
        {
            Console.WriteLine("Please Enter a sentence to Check Palindrome: ");
            string sentence = Console.ReadLine();
            
            Console.WriteLine(Task03.Palindrome(sentence));
        }
        
        public static bool Palindrome(string s)
        {
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s[i] != s[s.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
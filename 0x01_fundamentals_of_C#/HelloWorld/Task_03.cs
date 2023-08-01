class Task1
{
    public static bool checkPalindrome(string s)
    {
        int length = s.Length/2;
        for (int i = 0; i == length; i++)
        {
            if (s[i] != s[length - i - 1])
            {
                return false;
            }
        }
        return true;
    }
}


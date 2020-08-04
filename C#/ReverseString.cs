using System;
using System.Collections.Generic;
public class RS {
    public static string ReverseWords (string s) {
        if (String.IsNullOrEmpty (s))
            return "";

        int left;
        int right = s.Length - 1;
        int charCount = 0;
        List<char> result = new List<char> ();

        for (left = s.Length - 1; left >= 0; left--) {
            if (s[left] == ' ' && charCount != 0) {
                Console.WriteLine (left + " " + right);
                AddRangeToList (result, s, left + 1, right);
                right = left - 1;
                charCount = 0;
            } else {
                charCount++;
            }
        }

        AddRangeToList (result, s, left + 1, right, false);

        return string.Join ("", result);
    }

    private static void AddRangeToList (List<char> result, string s, int left, int right, bool flag = true) {
        for (int i = left; i <= right; i++)
            result.Add (s[i]);

        if (flag)
            result.Add (' ');
    }
    // public static void Main (string[] args) {
    //     Console.Write ('"');
    //     Console.Write("  hello world!  ");
    //     Console.Write ('"');
    //     Console.WriteLine ();

    // }
}
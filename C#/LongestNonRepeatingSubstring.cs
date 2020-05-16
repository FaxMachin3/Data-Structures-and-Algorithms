using System;
using System.Collections;
using System.Collections.Generic;
public class LongestSubstring {
    public static int LengthOfLongestSubstring (string s) {
        if (s.Length == 0) return 0;

        int max = 0;
        HashSet<char> charSet = new HashSet<char> ();

        int left = 0;
        int right = 0;

        while (right < s.Length) {
            if (charSet.Contains (s[right]))
                charSet.Remove (s[left++]);
            else {
                charSet.Add (s[right++]);
                max = Math.Max (max, right - left);
            }
        }

        return max;
    }
    // public static void Main (string[] args) {
    //     Console.WriteLine (LengthOfLongestSubstring ("abcabcbb"));
    // }
}
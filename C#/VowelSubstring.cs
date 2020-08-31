using System;
public class VSubs {
    public static string findSubstring (string s, int k) {
        int n = s.Length;
        if (n < k) return "Not found!";
        int start = 0;
        int max = 0;

        for (int i = 0; i < k; i++) {
            if ("aeiou".IndexOf (s[i]) >= 0) max++;
        }

        int cc = max;
        for (int i = k; i < n; i++) {
            if ("aeiou".IndexOf (s[i - k]) >= 0) cc--;
            if ("aeiou".IndexOf (s[i]) >= 0) cc++;

            if (cc > max) {
                max = cc;
                start = i - k + 1;
            }
        }

        if (max == 0) return "Not found!";

        return s.Substring (start, k);
    }
    // public static void Main (string[] args) {
    //     Console.WriteLine (findSubstring ("azerdii", 3));
    // }
}
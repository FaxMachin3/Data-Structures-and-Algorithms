using System;
public class RString {
    public static string ReorganizeString (string S) {
        int[] hash = new int[26];
        for (int i = 0; i < S.Length; i++) {
            hash[S[i] - 'a']++;
        }
        int max = 0, letter = 0;
        for (int i = 0; i < hash.Length; i++) {
            if (hash[i] > max) {
                max = hash[i];
                letter = i;
            }
        }
        if (max > (S.Length + 1) / 2) {
            return "";
        }
        char[] res = new char[S.Length];
        int idx = 0;
        while (hash[letter] > 0) {
            res[idx] = (char) (letter + 'a');
            idx += 2;
            hash[letter]--;
        }
        for (int i = 0; i < hash.Length; i++) {
            while (hash[i] > 0) {
                if (idx >= res.Length) {
                    idx = 1;
                }
                res[idx] = (char) (i + 'a');
                idx += 2;
                hash[i]--;
            }
        }
        return new string (res);
    }
    // public static void Main (string[] args) {
    //     Console.WriteLine (ReorganizeString ("aab"));
    // }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
public class GAnagrams {
    public static void GroupAnagrams (string[] strs) {
        IList<IList<string>> result = new List<IList<string>> ();

        Dictionary<string, List<string>> temp = new Dictionary<string, List<string>> ();

        for (int i = 0; i < strs.Length; i++) {
            int[] dp = new int[26];
            for (int j = 0; j < 3; j++) {
                dp[Convert.ToInt32 (strs[i][j] - 'a')]++;
            }
            StringBuilder newStr = new StringBuilder ();
            int count = 0;
            for (int k = 0; k < 26; k++) {
                if (dp[k] == 1){
                    count++;
                }
                newStr.Append (dp[k]);

                if (count == 3) break;
            }
            string newString = newStr.ToString ();
            if (temp.ContainsKey (newString)) {
                temp[newString].Add (strs[i]);
            } else {
                temp[newString] = new List<string> ();
                temp[newString].Add (strs[i]);
            }
        }

        foreach (var key in temp.Keys) {
            result.Add (temp[key]);
        }
    }

    // public static void Main (string[] args) {
    //     GroupAnagrams (new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });
    // }
}
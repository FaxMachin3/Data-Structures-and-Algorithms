using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
public class LCP {
    public static string LongestCommonPrefix (string[] strs) {
        StringBuilder s = new StringBuilder ();
        bool flag = true;
        int c = 0;
        while (flag) {
            int i;
            for (i = 1; i < strs.Length; i++) {
                if (c >= strs[i].Length || strs[i][c] != strs[0][c]) {
                    flag = false;
                    break;
                }
            }
            if(flag) s.Append (strs[0][c]);
            c++;
        }
        return s.ToString ();
    }
    // public static void Main (string[] args) {
    //     Console.WriteLine (LongestCommonPrefix (new string[]{"flower", "flow", "flight"}));
    // }
}
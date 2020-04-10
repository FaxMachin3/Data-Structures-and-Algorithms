using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class LongestCS {

    static int LCS(int[,] dp, string s1, string s2, int i, int j){
        if(i >= s1.Length || j >= s2.Length)
            return 0;
        if(dp[i,j] != -1)
            return dp[i,j];
        else if(s1[i] == s2[j])
            dp[i, j] = 1 + LCS(dp, s1, s2, i + 1, j + 1);
        else
            dp[i, j] = Math.Max(LCS(dp, s1, s2, i + 1, j), LCS(dp, s1, s2, i, j + 1));
        return dp[i,j];
    }

    // Complete the commonChild function below.
    static int commonChild(string s1, string s2) {
        int[,] dp = new int[s1.Length, s2.Length];
        for(int i = 0; i < s1.Length; i++){
            for(int j = 0; j < s2.Length; j++){
                dp[i,j] = -1;
            }
        }
        int result = LCS(dp, s1, s2, 0, 0);
        for(int i = 0; i < s1.Length; i++){
            for(int j = 0; j < s2.Length; j++){
                Console.Write(dp[i,j]+" ");
            }
            Console.WriteLine();
        }
        return dp[0,0];
    }

    // static void Main(string[] args) {

    //     string s1 = "SHINCHAN";

    //     string s2 = "NOHARAAA";

    //     int result = commonChild(s1, s2);

    //     Console.WriteLine(result);
    // }
}

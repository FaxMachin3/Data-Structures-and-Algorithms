using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;

class EditDistance {

    static int minEdit (string a, int lenA, string b, int lenB, int[, ] dp) {
        int result;
        if (lenA < 0 || lenB < 0) {
            if (lenB > lenA) return 0;
            else if (lenA > lenB) {
                for (int i = 0; i <= lenA; i++) {
                    if (Char.IsUpper (a[i])) return 0;
                }
                return 1;
            } else return 1;
        } else if (dp[lenA, lenB] != -1) { return dp[lenA, lenB]; } else if (a[lenA] == b[lenB]) {
            result = minEdit (a, lenA - 1, b, lenB - 1, dp);
        } else {
            if (Char.IsUpper (a[lenA])) return 0;
            else {
                if (Char.ToUpper (a[lenA]) == b[lenB]) {
                    result = Math.Max (minEdit (a, lenA - 1, b, lenB - 1, dp), minEdit (a, lenA - 1, b, lenB, dp));
                } else {
                    result = minEdit (a, lenA - 1, b, lenB, dp);
                }
            }
        }

        dp[lenA, lenB] = result;

        return dp[lenA, lenB];
    }

    // Complete the abbreviation function below.
    static string abbreviation (string a, string b) {
        int lenA = a.Length;
        int lenB = b.Length;
        int[, ] dp = new int[lenA, lenB];

        for (int i = 0; i < dp.GetLength (0); i++) {
            for (int j = 0; j < dp.GetLength (1); j++) {
                dp[i,j] = -1;
            }
        }

        for (int i = 0; i < dp.GetLength (0); i++) {
            for (int j = 0; j < dp.GetLength (1); j++) {
                Console.Write (dp[i, j] + " ");
            }
            Console.WriteLine ();
        }

        int result;

        if (lenA < lenB) result = 1;

        result = minEdit (a, lenA - 1, b, lenB - 1, dp);

        return result == 1 ? "YES" : "NO";
    }

    // static void Main (string[] args) {
    //     Console.WriteLine (abbreviation ("daBcd", "ABC"));
    // }
}
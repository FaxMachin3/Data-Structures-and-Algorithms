using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
public class GP {
    public static IList<string> GenerateParenthesis (int n) {
        if (n <= 0) return new List<string> ();

        IList<string> result = new List<string> ();

        GenerateParenthesisUtil (result, n, 0, 0, 0, "");

        return result;
    }

    public static void GenerateParenthesisUtil (IList<string> result,
        int n, int parity, int openBracs,
        int closeBracs, String tempString) {

        if (openBracs + closeBracs == n * 2) {
            result.Add (tempString);
            return;
        }

        if (parity == 0) {
            tempString += '(';
            GenerateParenthesisUtil (result, n, parity + 1,
                openBracs + 1, closeBracs, tempString);
        } else {
            if (openBracs == n) {
                tempString += ')';
                GenerateParenthesisUtil (result, n, parity - 1,
                    openBracs, closeBracs + 1, tempString);

            } else {
                string tempStr = tempString;
                tempString += '(';
                GenerateParenthesisUtil (result, n, parity + 1,
                    openBracs + 1, closeBracs, tempString);

                tempStr += ')';
                GenerateParenthesisUtil (result, n, parity - 1,
                    openBracs, closeBracs + 1, tempStr);

            }
        }

    }
    // public static void Main (string[] args) {
    //     var result = GenerateParenthesis (3);
    //     foreach (var e in result) {
    //         Console.WriteLine (e);
    //     }
    // }
}
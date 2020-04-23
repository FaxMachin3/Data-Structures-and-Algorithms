using System;
using System.Collections;
using System.Collections.Generic;
public class VPS {
    public static bool CheckValidString (string s) {
        Stack<char> incBrac = new Stack<char> ();
        Stack<char> excBrac = new Stack<char> ();
        Stack<char> noBrac = new Stack<char> ();
        bool check1 = true;
        bool check2 = true;
        bool check3 = true;
        foreach (var chr in s) {
            if (!check1 && !check2 && !check3) return false;
            if (chr == '(') {
                if (check1) incBrac.Push ('(');
                if (check2) excBrac.Push ('(');
                if (check3) noBrac.Push ('(');
            } else if (chr == ')') {
                if (check1) {
                    if (incBrac.Count == 0) check1 = false;
                    else if (incBrac.Pop () != '(') check1 = false;
                }
                if (check2) {
                    if (excBrac.Count == 0) check2 = false;
                    else if (excBrac.Pop () != '(') check2 = false;
                }
                if (check3) {
                    if (noBrac.Count == 0) check3 = false;
                    else if (noBrac.Pop () != '(') check3 = false;
                }
            } else {
                if (check1) incBrac.Push ('(');
                if (check2) {
                    if (excBrac.Count == 0) check2 = false;
                    else if (excBrac.Pop () != '(') check2 = false;
                }
            }
        }
        if (incBrac.Count == 0 || excBrac.Count == 0 || noBrac.Count == 0) return true;
        return false;
    }
    // public static void Main (string[] args) {
    //     Console.WriteLine (CheckValidString ("(*))"));
    // }
}
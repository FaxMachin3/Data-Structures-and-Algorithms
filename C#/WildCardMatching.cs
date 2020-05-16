using System;
public class WM {
    public static bool IsMatch (string s, string p) {
        int textLength = s.Length;
        int patternLength = p.Length;

        bool[, ] lookUpTable = new bool[textLength + 1, patternLength + 1];
        lookUpTable[0, 0] = true;

        for (int col = 1; col <= patternLength; col++) {
            if (p[col - 1] == '*')
                lookUpTable[0, col] = lookUpTable[0, col - 1];
        }

        for (int row = 1; row <= textLength; row++) {
            for (int col = 1; col <= patternLength; col++) {
                if (s[row - 1] == p[col - 1] || p[col - 1] == '?')
                    lookUpTable[row, col] = lookUpTable[row - 1, col - 1];
                else if (p[col - 1] == '*')
                    lookUpTable[row, col] = lookUpTable[row - 1, col] || lookUpTable[row, col - 1];
            }
        }

        return lookUpTable[textLength, patternLength];
    }
    // public static void Main (string[] args) {
    //     Console.WriteLine (IsMatch ("adceb", "*acc"));
    // }
}
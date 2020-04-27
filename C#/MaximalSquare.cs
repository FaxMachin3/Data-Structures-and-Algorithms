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
public class MM {
    public static int MaximalSquare (char[][] matrix) {
        if (matrix.Length == 0 || matrix[0].Length == 0) return 0;
        int max = 0;
        for (int r = 0; r < matrix.Length; r++) {
            for (int c = 0; c < matrix[0].Length; c++) {
                if (r == 0 || c == 0) {
                    if (max == 0 && matrix[r][c] == '1') max = 1;
                } else {
                    if (matrix[r][c] != '0' && matrix[r - 1][c] != '0' && matrix[r - 1][c - 1] != '0' && matrix[r][c - 1] != '0') {
                        int top = matrix[r - 1][c] - '0';
                        int diagonal = matrix[r - 1][c - 1] - '0';
                        int left = matrix[r][c - 1] - '0';
                        int min = 1 + Math.Min (Math.Min (top, left), diagonal);
                        matrix[r][c] = Convert.ToChar (min.ToString ());
                    }
                    max = Math.Max (max, matrix[r][c] - '0');
                }
            }
        }
        for (int r = 0; r < matrix.Length; r++) {
            for (int c = 0; c < matrix[0].Length; c++) {
                Console.Write (matrix[r][c]);
            }
            Console.WriteLine ();
        }
        return max * max;
    }

    // public static void Main (string[] args) {
    //     Console.WriteLine (MaximalSquare (new char[][] {
    //         new char[] { '1', '1', '1', '1' },
    //             new char[] { '1', '1', '1', '1' },
    //             new char[] { '1', '1', '1', '1' }
    //     }));
    // }
}
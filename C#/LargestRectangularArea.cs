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

class Solution {
    // Complete the largestRectangle function below.
    static long largestRectangle (int[] height) {
        int len = height.Length;

        if (len == 0) return 0;
        if (len == 1) return height[0];

        int maxArea = 0;
        Stack<int> positionStack = new Stack<int> ();

        int i = 0;
        while (i < len) {
            if (positionStack.Count == 0 || height[i] >= height[positionStack.Peek ()])
                positionStack.Push (i++);
            else {
                int pos = positionStack.Pop ();
                int tempArea = height[pos] * (positionStack.Count == 0 ?
                    i :
                    i - positionStack.Peek () - 1);
                maxArea = Math.Max (maxArea, tempArea);
            }
        }

        while (positionStack.Count != 0) {
            int pos = positionStack.Pop ();
            int tempArea = height[pos] * (positionStack.Count == 0 ?
                i :
                i - positionStack.Peek () - 1);
            maxArea = Math.Max (maxArea, tempArea);
        }

        return maxArea;
    }

    // static void Main (string[] args) {

    //     int[] h = new int[] { 2, 3, 1, 6, 6, 4, 2 };
    //     long result = largestRectangle (h);
    //     Console.WriteLine (result);
    // }
}
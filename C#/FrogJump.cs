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
public class FrogJump {
    public static bool CanCrossUtil (int[] stones, int index, int k) {
        if (stones[index - 1] + k != stones[index]) return false;
        else if (index == stones.Length - 1) return true;
        else {
            return CanCrossUtil (stones, index + 1, k - 1) ||
                CanCrossUtil (stones, index + 1, k) ||
                CanCrossUtil (stones, index + 1, k + 1);
        }
    }
    public static bool CanCross (int[] stones) {
        return CanCrossUtil (stones, 1, 1);
    }
    // public static void Main (string[] args) {
    //     Console.WriteLine (CanCross (new int[] {
    //         0,
    //         1,
    //         3,
    //         5,
    //         6,
    //         8,
    //         12,
    //         17
    //     }));
    // }
}
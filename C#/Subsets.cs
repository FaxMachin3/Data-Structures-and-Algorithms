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

public class SubsetsBT {
    public static IList<IList<int>> Subsets (int[] nums) {
        IList<IList<int>> result = new List<IList<int>> ();
        GenerateSubsets (nums, result, new List<int> (), 0);
        return result;
    }
    public static void GenerateSubsets (int[] nums, IList<IList<int>> result,
        List<int> tempList, int start) {
        result.Add (new List<int> (tempList));
        for (int i = start; i < nums.Length; i++) {
            tempList.Add (nums[i]);
            GenerateSubsets (nums, result, tempList, i + 1);
            tempList.RemoveAt (tempList.Count - 1);
        }
    }
    // public static void Main (string[] args) {
    //     Console.WriteLine (Subsets(new int[] {1, 2, 3}));
    // }
}
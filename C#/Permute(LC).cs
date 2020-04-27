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
public class PermuteArray {
    public static void swap (int[] nums, int i, int j) {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
    public static void PermuteUtil (int[] nums, IList<IList<int>> result, List<int> tempList, int left, int right) {
        if (left == right) {
            result.Add (nums.ToList ());
        } else {
            while (left <= right) {
                swap (nums, left, right);
                PermuteUtil (nums, result, tempList, left + 1, right);
                swap (nums, left, right);
            }
        }
    }
    public static IList<IList<int>> Permute (int[] nums) {
        if (nums.Length == 0 || nums == null) return null;

        IList<IList<int>> result = new List<IList<int>> ();

        PermuteUtil (nums, result, new List<int> (), 0, nums.Length - 1);

        return result;
    }
    // public static void Main (string[] args) {
    //     Console.WriteLine (Permute (new int[] { 1, 2, 3 }));
    // }
}
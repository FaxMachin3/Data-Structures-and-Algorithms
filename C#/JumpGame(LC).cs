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
public class JumpGame {
    public static bool Helper (int[] nums, int index, Dictionary<int, bool> dp) {
        if (dp[index]) return dp[index];
        if (index >= nums.Length - 1) return true;
        if (nums[index] + index >= nums.Length - 1) return true;
        else {
            if (nums[index] >= 1) {
                bool result = false;
                for (int i = 1; i <= nums[index]; i++) {
                    result |= Helper (nums, index + i, dp);
                }
                dp[index] = result;
            } else dp[index] = false;
        }
        return dp[index];
    }
    public static bool CanJump (int[] nums) {
        Dictionary<int, bool> dp = new Dictionary<int, bool> ();
        return Helper (nums, 0, dp);
    }
    // public static void Main (String[] args) {
    //     Console.WriteLine (CanJump (new int[] { 2, 9, 0, 0 }));
    // }
}
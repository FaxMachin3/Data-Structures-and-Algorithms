using System;
public class HR {
    private static int RobUtil (int[] nums, int total, int house, int[] dp) {
        if (house >= nums.Length)
            return total;

        if (dp[house] != 0)
            return dp[house];

        dp[house] = Math.Max (RobUtil (nums, total + nums[house], house + 2, dp),
            RobUtil (nums, total, house + 1, dp));

        return dp[house];
    }
    public static int Rob (int[] nums) {
        int[] dp = new int[nums.Length];

        return RobUtil (nums, 0, 0, dp);
    }
    // public static void Main (string[] args) {
    //     Console.WriteLine (Rob (new int[] { 1, 2, 1, 1 }));
    // }
}
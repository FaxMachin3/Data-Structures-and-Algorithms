using System;
public class MaxArraySum {
    public static int MaxSubArray(int[] nums) {
        int currentMax = nums[0];
        int globalMax = nums[0];
        for(int i = 1; i < nums.Length; i++){
            int one = nums[i];
            int two = nums[i]  + currentMax;
            currentMax = Math.Max(one, two);
            globalMax = Math.Max(currentMax, globalMax);
        }
        return globalMax;
    }
    // static void Main(string[] args) {
    //     Console.WriteLine(MaxSubArray(new int[]{-2,1,-3,4,-1,2,1,-5,4}));
    // }
}
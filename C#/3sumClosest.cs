using System;
public class ThreeSC {
    static int minDiff;
    static int closestSum;

    public static int ThreeSumClosest (int[] nums, int target) {
        minDiff = int.MaxValue;
        closestSum = 0;
        ThreeSumClosestUtil (nums, target, 0, 0, 0);
        return closestSum;
    }

    private static void ThreeSumClosestUtil (int[] nums, int target, int start, int k, int sum) {
        if (k == 3) {
            int absDiff = Math.Abs (target - sum);
            if (absDiff < minDiff) {
                minDiff = absDiff;
                closestSum = sum;
            }
            return;
        }

        for (int i = start; i < nums.Length; i++) {
            ThreeSumClosestUtil (nums, target, i + 1, k + 1, sum + nums[i]);
        }
    }
    // public static void Main (string[] args) {
    //     Console.WriteLine (ThreeSumClosest (new int[] {-1, 2, 1, -4 }, 1));
    // }
}
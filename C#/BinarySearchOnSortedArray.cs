using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
public class BSOSA {
    static int result = -1;
    public static bool BinarySearchTarget (int[] nums, int target, int left, int right) {
        bool x = false;
        if (left > right) x = false;
        else {
            int mid = (left + right) / 2;
            if (target == nums[mid]) {
                result = mid;
                x = true;
            } else {
                if (target > nums[mid]) x = BinarySearchTarget (nums, target, mid + 1, right);
                else x = BinarySearchTarget (nums, target, left, mid - 1);
            }
        }
        return x;
    }
    public static int FindPivot (int[] nums, int left, int right) {
        int result = -1;
        if (left > right) result = -1;
        else {
            int mid = (left + right) / 2;
            if (mid == 0) {
                if (nums[mid] > nums[mid + 1]) result = mid + 1;
                else result = -1;
            } else if (mid == nums.Length - 1) {
                if (nums[mid] < nums[mid - 1]) result = mid;
                else result = -1;
            } else if (nums[mid] < nums[mid - 1] && nums[mid] < nums[mid + 1]) result = mid;
            else {
                if (nums[mid] > nums[0]) result = FindPivot (nums, mid + 1, right);
                else result = FindPivot (nums, left, mid - 1);
            }
        }
        return result;
    }
    public static int Search (int[] nums, int target) {
        int left = 0;
        int right = nums.Length - 1;
        while (left <= right) {
            int mid = (left + right) / 2;
            if (nums[mid] == target) return mid;
            else if (nums[mid] >= nums[left]) {
                if (target >= nums[left] && target < nums[mid]) right = mid - 1;
                else left = mid + 1;
            } else {
                if (target <= nums[right] && target > nums[mid]) left = mid + 1;
                else right = mid - 1;
            }
        }
        return -1;
    }

    // public static void Main (String[] args) {
    //     Console.WriteLine (Search (new int[] { 3, 1 }, 1));
    // }
}
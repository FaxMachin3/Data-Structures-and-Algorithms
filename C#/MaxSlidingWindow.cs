using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class MSW {
    public static int[] MaxSlidingWindow (int[] nums, int k) {
        LinkedList<int> ll = new LinkedList<int> ();
        int[] result = new int[nums.Length - (k - 1)];
        int index = 0;
        int max = int.MinValue;
        int maxIndex = 0;
        int i;
        for (i = 0; i < k; i++) {
            if (nums[i] >= max) {
                max = nums[i];
                maxIndex = i;
            }
            while (ll.Count != 0 && (nums[i] > nums[ll.Last.Value])) {
                ll.RemoveLast ();
            }
            while (ll.Count != 0 && (ll.First.Value <= i - k)) {
                ll.RemoveFirst ();
            }
            ll.AddLast (i);
        }
        ll.AddFirst (maxIndex);
        result[index++] = nums[maxIndex];
        while (i < nums.Length) {
            while (ll.Count != 0 && (nums[i] > nums[ll.Last.Value])) {
                ll.RemoveLast ();
            }
            while (ll.Count != 0 && (ll.First.Value <= i - k)) {
                ll.RemoveFirst ();
            }
            ll.AddLast (i);
            // Console.WriteLine(string.Join(" ",result));
            result[index++] = nums[ll.First.Value];
            i++;
        }
        return result;
    }
    public static void Main (string[] args) {
        Console.WriteLine (string.Join (" ", MaxSlidingWindow (new int[] { 9, 10, 9, -7, -4, -8, 2, -6 }, 5)));
    }
}
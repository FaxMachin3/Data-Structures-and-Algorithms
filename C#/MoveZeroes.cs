using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
class MoveZeroes {
    static void swap (int[] nums, int i, int iZeros) {
        if (iZeros == 0) return;

        int index = i - iZeros;
        for (int j = iZeros; j < nums.Length; j++) {
            nums[index++] = nums[j];
        }
    }

    static void moveZeroes (int[] nums) {
        int totalZeros = 0;
        int iZeros = 0;
        int nonZeros = 0;

        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] == 0) iZeros++;
            if (nums[i] != 0) {
                nonZeros++;
                totalZeros += iZeros;
                swap (nums, i, iZeros);
                iZeros = 0;
            }
        }

        totalZeros += iZeros;

        for (int i = nonZeros; i < nums.Length; i++) {
            nums[i] = 0;
        }

        Console.WriteLine (string.Join (" ", nums));
    }
    // static void Main (string[] args) {
    //     // moveZeroes (new int[] { 0, 1, 0, 3, 12 });
    //     Console.WriteLine ("MoveZeroes");
    //     Console.WriteLine (1>>3);
    // }
}
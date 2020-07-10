using System;
public class HIndex2 {
    public static int HIndex (int[] citations) {
        int len = citations.Length;

        int low = 0;
        int high = len - 1;
        int mid;

        while (low <= high) {
            mid = low + (high - low) / 2;
            if (len - mid <= citations[mid])
                high = mid - 1;
            else
                low = mid + 1;
        }

        return len - low;
    }
    // public static void Main (string[] args) {
    //     Console.WriteLine(HIndex(new int[] {6,7,8,9,10}));
    // }
}
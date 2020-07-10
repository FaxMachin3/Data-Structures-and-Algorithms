using System;
public class TS2 {
    public static int FourSumCount (int[] A, int[] B, int[] C, int[] D) {
        int count = 0;
        FourSumCountUtil (A, B, C, D, 0, 0, 0, 0, ref count);
        return count;
    }

    private static void FourSumCountUtil (int[] A, int[] B, int[] C, int[] D, int a, int b, int c, int d, ref int count) {
        if (a > 1 || b > 1 || c > 1 || d > 1)
            return;

        if (A[a] + B[b] + C[c] + D[d] == 0)
            count++;

        FourSumCountUtil (A, B, C, D, a + 1, b, c, d, ref count);
        FourSumCountUtil (A, B, C, D, a, b + 1, c, d, ref count);
        FourSumCountUtil (A, B, C, D, a, b, c + 1, d, ref count);
        FourSumCountUtil (A, B, C, D, a, b, c, d + 1, ref count);
    }
    // public static void Main (string[] args) {
    //     Console.WriteLine (FourSumCount (new int[] { 1, 2 }, new int[] {-2, -1 }, new int[] {-1, 2 }, new int[] { 0, 2 }));
    // }
}
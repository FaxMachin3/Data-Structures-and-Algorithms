using System;
public class TCS {
    public static int TwoCitySchedCost (int[][] costs) {
        return TwoCitySchedCostUtil (costs, 0, 0, 0, 0);
    }

    private static int TwoCitySchedCostUtil (int[][] costs, int countA, int countB, int pos, int sum) {
        if (pos == costs.Length - 2) {
            if (countA == countB)
                return sum + Math.Min (costs[pos][0] + costs[pos + 1][1],
                    costs[pos][1] + costs[pos + 1][0]);
            else if (Math.Abs (countA - countB) == 2) {
                if (countA > countB)
                    return sum + costs[pos][1] + costs[pos + 1][1];
                else
                    return sum + costs[pos][0] + costs[pos + 1][0];
            } else
                return int.MaxValue;
        }

        int sumChossingAA = TwoCitySchedCostUtil (costs, countA + 2, countB, pos + 2,
            sum + costs[pos][0] + costs[pos + 1][0]);
        int sumChossingBB = TwoCitySchedCostUtil (costs, countA, countB + 2, pos + 2,
            sum + costs[pos][1] + costs[pos + 1][1]);
        int sumChossingAB = TwoCitySchedCostUtil (costs, countA + 1, countB + 1, pos + 2,
            sum + costs[pos][0] + costs[pos + 1][1]);
        int sumChossingBA = TwoCitySchedCostUtil (costs, countA + 1, countB + 1, pos + 2,
            sum + costs[pos][1] + costs[pos + 1][0]);

        return sum + Math.Min (Math.Min (sumChossingAA, sumChossingBB),
            Math.Min (sumChossingAB, sumChossingBA));
    }
    // public static void Main (string[] args) {
    //     Console.WriteLine (TwoCitySchedCost (new int[][] {
    //         new int[] { 10, 20 },
    //             new int[] { 30, 200 },
    //             new int[] { 400, 50 },
    //             new int[] { 30, 20 },
    //             new int[] { 400, 50 },
    //             new int[] { 30, 20 },
    //     }));
    // }
}
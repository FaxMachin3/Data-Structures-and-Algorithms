using System;
class MaxP {
    private static int MaxProfit (int[] prices) {
        int[, ] dp = new int[prices.Length, 3];

        for (int i = 0; i < prices.Length; i++) {
            for (int j = 0; j < 3; j++) {
                dp[i, j] = -1;
            }
        }

        int result = MaxProfitUtil (dp, prices, 0, 0);

        // for (int i = 0; i < prices.Length; i++) {
        //     for (int j = 0; j < 3; j++) {
        //         Console.Write (dp[i, j] + " ");
        //     }
        //     Console.WriteLine ();
        // }

        return result;
    }

    private static int MaxProfitUtil (int[, ] dp, int[] prices, int index, int flag) {
        if (index >= prices.Length)
            return 0;

        if (dp[index, flag] != -1)
            return dp[index, flag];

        if (flag == 0) {
            int buy = MaxProfitUtil (dp, prices, index + 1, 1) + prices[index]; // buy
            int notBuy = MaxProfitUtil (dp, prices, index + 1, 0); // don't buy
            dp[index, flag] = Math.Max (buy, notBuy);
        } else if (flag == 1) {
            int sell = MaxProfitUtil (dp, prices, index + 1, 2) - prices[index]; // sell
            int notSell = MaxProfitUtil (dp, prices, index + 1, 1); // don't sell
            dp[index, flag] = Math.Max (sell, notSell);
        } else if (flag == 2) {
            int coolDown = MaxProfitUtil (dp, prices, index + 1, 0);
            dp[index, flag] = coolDown;
        }

        return dp[index, flag];
    }
    // public static void Main (string[] args) {
    //     Console.WriteLine (MaxProfit (new int[] { 3, 2, 3, 0, 2 }));
    // }
}
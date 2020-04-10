using System;
public class CoinChangeClass {
    public static int NumberOfCoins (int[] coins, int amount, int[] dp) {
        if (amount == 0) return 0;
        if (amount < 0) return int.MaxValue;

        if (dp[amount] != -1) return dp[amount];

        for (int i = coins.Length - 1; i >= 0; i--) {
            dp[amount] = Math.Min (1 + NumberOfCoins (coins, amount - coins[i], dp), NumberOfCoins (coins, amount, dp));
        }

        return dp[amount];
    }
    public static int CoinChange (int[] coins, int amount) {
        int[] dp = new int[amount + 1];
        Array.Sort (coins);
        Array.Fill (dp, -1);
        dp[0] = 0;
        int result = NumberOfCoins (coins, amount, dp);
        return result == int.MinValue ? -1 : result;
    }

    // public static void Main (string[] args) {
    //     Console.WriteLine ("Coin Change");
    //     Console.WriteLine (CoinChange (new int[] { 2, 5 }, 6));
    // }
}
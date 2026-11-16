// LeetCode 70: Climbing Stairs

function climbStairs(n: number): number {
    const dp = new Array(n + 1);
    dp[0] = 0;
    dp[1] = 1;

    function helper(n: number): number {
        if (n === 0) return 1;
        if (n < 0) return 0;
        if (dp[n]) return dp[n];

        dp[n] = helper(n - 1) + helper(n - 2);

        return dp[n];
    }

    return helper(n);
}

// LeetCode 3946: Maximum Number of Items From Sale I

function maximumSaleItems(items: number[][], budget: number): number {
    items.sort((a, b) => a[1] - b[1] || a[0] - b[0]);
    const n = items.length;
    const freeItems = new Int32Array(n);

    for (let i = 0; i < n; i++) {
        for (let j = 0; j < n; j++) {
            if (j === i) continue;
            if (items[j][0] % items[i][0] === 0) freeItems[i] += 1;
        }
    }

    const dp: Array<Int32Array> = Array.from({ length: n }, () => new Int32Array(budget + 1));

    const cheapestPrice = items[0][1];
    for (let b = cheapestPrice; b <= budget; b++) {
        dp[0][b] = Math.floor(b / cheapestPrice) + freeItems[0];
    }

    for (let i = 1; i < n; i++) {
        const price = items[i][1];

        for (let b = 0; b <= budget; b++) {
            const notPick = dp[i - 1][b];
            dp[i][b] = notPick;

            if (b >= price) {
                const pick = 1 + freeItems[i] + dp[i - 1][b - price];
                dp[i][b] = Math.max(dp[i][b], pick);
            }
        }
    }

    return dp[n - 1][budget];
}

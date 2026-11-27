// LeetCode 3946: Maximum Number of Items From Sale I
// Recursive DP: try every affordable quantity for each type.
// The quantity loop can take O(n * budget^2) time.

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

    const memo: Array<Int32Array> = Array.from({ length: n + 1 }, () => new Int32Array(budget + 1));

    function helper(i: number, budget: number): number {
        if (budget <= 0) return 0;
        if (i === n) return 0;
        if (items[i][1] > budget) return 0;

        if (memo[i][budget] !== 0) return memo[i][budget];

        let maxItems = 0;

        let budgetCopy = budget;
        let copies = 1;
        while (budgetCopy >= items[i][1]) {
            const nextBudget = budgetCopy - items[i][1];
            const pick = copies + freeItems[i] + helper(i + 1, nextBudget);
            maxItems = Math.max(maxItems, pick);
            copies++;
            budgetCopy = nextBudget;
        }

        const notPick = helper(i + 1, budget);
        maxItems = Math.max(maxItems, notPick);

        memo[i][budget] = maxItems;

        return memo[i][budget];
    }

    return helper(0, budget);
}

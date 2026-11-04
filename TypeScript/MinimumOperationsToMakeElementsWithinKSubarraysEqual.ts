// LeetCode 3505: Minimum Operations to Make Elements Within K Subarrays Equal
// Sliding window median via Fenwick counts and sums, then rolling DP.
// Time: O(n log n + nk). Extra space: O(n).
function minOperations(nums: number[], x: number, k: number): number {
    const n = nums.length;
    const values = [...new Set(nums)].sort((a, b) => a - b);
    const m = values.length;
    const rank = new Map<number, number>();

    for (let i = 0; i < m; i++) {
        rank.set(values[i], i + 1);
    }

    const counts = new Int32Array(m + 1);
    const sums = new Float64Array(m + 1);
    let total = 0;

    function update(value: number, delta: number): void {
        total += value * delta;

        for (let i = rank.get(value)!; i <= m; i += i & -i) {
            counts[i] += delta;
            sums[i] += value * delta;
        }
    }

    let topStep = 1;
    while (topStep * 2 <= m) topStep *= 2;
    const medianRank = Math.floor((x + 1) / 2);

    function windowCost(): number {
        let index = 0;
        let countBelow = 0;
        let sumBelow = 0;

        // Find the largest prefix containing fewer than medianRank values.
        for (let step = topStep; step > 0; step >>= 1) {
            const next = index + step;

            if (next <= m && countBelow + counts[next] < medianRank) {
                index = next;
                countBelow += counts[next];
                sumBelow += sums[next];
            }
        }

        const median = values[index];
        const below = median * countBelow - sumBelow;
        const atOrAbove = total - sumBelow - median * (x - countBelow);
        return below + atOrAbove;
    }

    const cost = new Float64Array(n - x + 1);
    for (let i = 0; i < x; i++) update(nums[i], 1);

    for (let left = 0; left + x <= n; left++) {
        cost[left] = windowCost();
        if (left + x < n) {
            update(nums[left], -1);
            update(nums[left + x], 1);
        }
    }

    // prev[end] is the cost of selecting t - 1 windows in the first end elements.
    let prev = new Float64Array(n + 1);

    for (let t = 1; t <= k; t++) {
        const curr = new Float64Array(n + 1).fill(Infinity);

        for (let end = t * x; end <= n; end++) {
            curr[end] = Math.min(curr[end - 1], prev[end - x] + cost[end - x]);
        }

        prev = curr;
    }

    return prev[n];
}

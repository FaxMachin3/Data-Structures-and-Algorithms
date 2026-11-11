// LeetCode 3789: Minimum Cost to Acquire Required Items
// Time: O(1). Extra space: O(1).

function minimumCost(
    cost1: number,
    cost2: number,
    costBoth: number,
    need1: number,
    need2: number
): number {
    const shared = Math.min(need1, need2);
    const sharedCost = shared * Math.min(cost1 + cost2, costBoth);

    const remaining1 = need1 - shared;
    const remaining2 = need2 - shared;
    const remainingCost =
        remaining1 * Math.min(cost1, costBoth) +
        remaining2 * Math.min(cost2, costBoth);

    return sharedCost + remainingCost;
}

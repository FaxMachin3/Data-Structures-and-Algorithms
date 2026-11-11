// LeetCode 3693: Climbing Stairs II
// Time: O(n). Extra space: O(1).
function climbStairs(n: number, costs: number[]): number {
    let next1 = 0;
    let next2 = Infinity;
    let next3 = Infinity;

    for (let i = n - 1; i >= 0; i--) {
        let best = costs[i] + 1 + next1;

        if (i + 2 <= n) {
            best = Math.min(best, costs[i + 1] + 4 + next2);
        }
        if (i + 3 <= n) {
            best = Math.min(best, costs[i + 2] + 9 + next3);
        }

        next3 = next2;
        next2 = next1;
        next1 = best;
    }

    return next1;
}

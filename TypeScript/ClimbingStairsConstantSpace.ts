// LeetCode 70: Climbing Stairs
// Time: O(n). Extra space: O(1).

function climbStairs(n: number): number {
    if (n <= 3) return n;

    let zero = 1;
    let one = 1;
    let two = 2;

    for (let i = 2; i <= n; i++) {
        two = zero + one;
        zero = one;
        one = two;
    }

    return two;
}

export { climbStairs };

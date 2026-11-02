// LeetCode 462: Minimum Moves to Equal Array Elements II
// https://leetcode.com/problems/minimum-moves-to-equal-array-elements-ii/
// A median minimizes the sum of absolute differences.
// For even lengths, either middle value (or any value between them) is optimal.
// Time: O(n log n) with typical comparison sorting.
// Auxiliary space depends on the JavaScript sorting implementation.
// Mutates nums by sorting it.
function minMoves2(nums: number[]): number {
    nums.sort((a, b) => a - b);
    const mid = nums[nums.length >>> 1];

    return nums.reduce((moves, num) => moves + Math.abs(mid - num), 0);
}

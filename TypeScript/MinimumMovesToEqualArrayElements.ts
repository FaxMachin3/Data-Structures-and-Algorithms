// LeetCode 453: Minimum Moves to Equal Array Elements
// https://leetcode.com/problems/minimum-moves-to-equal-array-elements/
// Incrementing n - 1 elements is equivalent, up to a common offset,
// to decrementing the excluded element. Reduce all values to the minimum.
// Moves = sum(nums[i] - min(nums)) = sum(nums) - min(nums) * nums.length.
// Time: O(n). Extra space: O(1). Does not mutate nums.
function minMoves(nums: number[]): number {
    let min = Infinity;
    let sum = 0;

    for (let i = 0; i < nums.length; i++) {
        min = Math.min(min, nums[i]);
        sum += nums[i];
    }

    return sum - (min * nums.length);
}

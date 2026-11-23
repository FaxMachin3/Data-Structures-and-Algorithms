// LeetCode 136: Single Number
// Time: O(n). Extra space: O(1).

function singleNumber(nums: number[]): number {
    let xor = nums[0];

    for(let i = 1; i < nums.length; i++) {
        xor ^= nums[i]
    }

    return xor;
};

// LeetCode 2567: Minimum Score by Changing Two Elements

function minimizeSum(nums: number[]): number {
    const n = nums.length;
    nums.sort((a,b) => a-b);

    return Math.min(
        nums[n-2] - nums[1],
        nums[n-3] - nums[0],
        nums[n-1] - nums[2]
    );
};

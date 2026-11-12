// LeetCode 3105: Longest Strictly Increasing or Strictly Decreasing Subarray
// Time: O(n). Extra space: O(1).

function longestMonotonicSubarray(nums: number[]): number {
    if(nums.length <= 1) return nums.length;

    let isIncreasing = nums[1] > nums[0];
    let maxIncOrDec = 1;
    let currMax = 1;

    for(let i = 1; i < nums.length; i++) {
        const prevFlag = isIncreasing;

        if(nums[i] > nums[i-1]) isIncreasing = true;
        else if (nums[i] < nums[i-1]) isIncreasing = false;
        else isIncreasing = !isIncreasing;

        if(prevFlag !== isIncreasing) {
            if (nums[i] === nums[i-1]) currMax = 1
            else currMax = 2;
        } else {
            currMax += 1;
        }

        maxIncOrDec = Math.max(maxIncOrDec, currMax);
    }

    return maxIncOrDec
};

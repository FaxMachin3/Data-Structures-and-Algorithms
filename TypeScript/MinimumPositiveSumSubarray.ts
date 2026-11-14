// LeetCode 3364: Minimum Positive Sum Subarray

function minimumSumSubarray(nums: number[], l: number, r: number): number {
    let minSum = Infinity;
    const prefixSum = new Int32Array(nums.length);
    prefixSum[0] = nums[0]

    for(let i = 1; i < nums.length; i++) {
        prefixSum[i] = nums[i] + prefixSum[i-1];
    }

    for(let i = 0; i < nums.length; i++) {
        for(let j = i+l-1; j < nums.length && j < i+r; j++) {
            const sum = prefixSum[j] - (prefixSum[i-1] ?? 0);
            if(sum > 0) {
                minSum = Math.min(minSum, sum);
            }
        }
    }

    return minSum === Infinity ? -1 : minSum;
};

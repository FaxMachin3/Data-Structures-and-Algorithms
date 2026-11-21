// LeetCode 3041: Maximize Consecutive Elements in an Array After Modification
// Time: O(n log n). Extra space: O(n).

function maxSelectedElements(nums: number[]): number {
    const n = nums.length;
    nums.sort((a, b) => a - b);
    let max = 1;
    const dp = Array.from({ length: n }, () => new Array<number>(2).fill(-1));

    function findNext(lo: number, target: number): number {
        let hi = n;

        while (lo < hi) {
            const mid = lo + Math.floor((hi - lo) / 2);
            const curr = nums[mid];

            if (curr < target) lo = mid + 1;
            else hi = mid;
        }

        return lo < n && nums[lo] === target ? lo : -1;
    }

    function helper(i: number, inc: number): number {
        if (dp[i][inc] !== -1) return dp[i][inc];

        const currVal = nums[i] + inc;
        let len = 1;

        const j = findNext(i + 1, currVal + 1);
        if (j !== -1) {
            len = Math.max(len, 1 + helper(j, 0));
        }

        const k = findNext(i + 1, currVal);
        if (k !== -1) {
            len = Math.max(len, 1 + helper(k, 1));
        }

        dp[i][inc] = len;
        return len;
    }

    for (let i = 0; i < n; i++) {
        max = Math.max(max, helper(i, 0), helper(i, 1));
    }

    return max;
};

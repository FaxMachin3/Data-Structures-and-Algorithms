// LeetCode 238: Product of Array Except Self
// Time: O(n). Extra space: O(n), excluding the result array.

function productExceptSelf(nums: number[]): number[] {
    const n = nums.length;
    const prefixProduct = new Int32Array(n);
    prefixProduct[0] = nums[0]
    const postfixProduct = new Int32Array(n);
    postfixProduct[n-1] = nums[n-1]
    const result = new Array<number>(n)

    for(let i = 1; i < n; i++) {
        prefixProduct[i] = nums[i] * prefixProduct[i-1];
    }
    for(let i = n-2; i >= 0; i--) {
        postfixProduct[i] = nums[i] * postfixProduct[i+1];
    }

    for(let i = 0; i < n; i++) {
        result[i] = (prefixProduct[i-1] ?? 1) * (postfixProduct[i+1] ?? 1);
    }

    return result;
};

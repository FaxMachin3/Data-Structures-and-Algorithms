// LeetCode 3420: Count Non-Decreasing Subarrays After K Operations
// Time: O(n). Extra space: O(n).

function countNonDecreasingSubarrays(nums: number[], k: number): number {
    const n = nums.length;
    const deque = new Int32Array(n);
    let head = 0;
    let tail = 0;

    let right = n - 1;
    let cost = 0;
    let count = 0;

    // The deque holds group starts from rightmost to leftmost.
    for (let left = n - 1; left >= 0; left--) {
        while (head < tail && nums[deque[tail - 1]] < nums[left]) {
            const start = deque[--tail];
            const end = head < tail ? deque[tail - 1] : right + 1;
            cost += (nums[left] - nums[start]) * (end - start);
        }
        deque[tail++] = left;

        while (cost > k) {
            const start = deque[head];
            cost -= nums[start] - nums[right];

            if (start === right) head++;
            right--;
        }

        count += right - left + 1;
    }

    return count;
}

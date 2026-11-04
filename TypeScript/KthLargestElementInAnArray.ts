// LeetCode 215: Kth Largest Element in an Array
// Randomized Hoare Quickselect: expected O(n) time, O(1) extra space.
// Worst-case O(n^2) time. Rearranges nums in place.
function findKthLargest(nums: number[], k: number): number {
    k -= 1;
    let low = 0;
    let high = nums.length - 1;

    while (low < high) {
        // Exclude high so the split always shrinks the range.
        const pivot = nums[low + Math.floor(Math.random() * (high - low))];
        let i = low - 1;
        let j = high + 1;

        while (true) {
            do { i++; } while (nums[i] > pivot);
            do { j--; } while (nums[j] < pivot);

            if (i >= j) break;
            [nums[i], nums[j]] = [nums[j], nums[i]];
        }

        // j splits the range; it is not necessarily the pivot's index.
        if (k <= j) high = j;
        else low = j + 1;
    }

    return nums[low];
}

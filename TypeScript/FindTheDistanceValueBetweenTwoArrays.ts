// LeetCode 1385: Find the Distance Value Between Two Arrays
// https://leetcode.com/problems/find-the-distance-value-between-two-arrays/

// Brute force: O(n * m) worst-case time, O(1) extra space.
// Does not mutate either input array.
function findTheDistanceValueBruteForce(
    arr1: number[],
    arr2: number[],
    d: number
): number {
    let count = 0;

    for (let i = 0; i < arr1.length; i++) {
        let flag = false;
        for (let j = 0; j < arr2.length; j++) {
            if (Math.abs(arr1[i] - arr2[j]) <= d) {
                flag = true;
                break;
            }
        }
        if (!flag) count++;
    }

    return count;
}

// Sort + binary search: O(m log m + n log m) time with typical sorting.
// Sorts arr2 in place; sorting auxiliary space is engine-dependent.
function findTheDistanceValue(
    arr1: number[],
    arr2: number[],
    d: number
): number {
    arr2.sort((a, b) => a - b);

    function hasEleInRangeBS(left: number, right: number): boolean {
        let low = 0;
        let high = arr2.length - 1;

        while (low <= high) {
            const mid = low + Math.floor((high - low) / 2);
            const num = arr2[mid];

            if (num >= left && num <= right) return true;
            if (num < left) low = mid + 1;
            if (num > right) high = mid - 1;
        }

        return false;
    }

    let count = 0;
    for (const num of arr1) {
        const left = num - d;
        const right = num + d;

        if (!hasEleInRangeBS(left, right)) count++;
    }

    return count;
}

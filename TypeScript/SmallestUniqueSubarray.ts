// LeetCode 3934: Smallest Unique Subarray

function smallestUniqueSubarray(nums: number[]): number {
    const n = nums.length;
    let max = nums[0];
    for (let i = 1; i < n; i++) {
        max = Math.max(max, nums[i]);
    }
    const min = n;
    const MOD = 1_000_000_007;
    const BASE = max + 1;

    function hasUnique(len: number): boolean {
        let power = 1;
        let hash = nums[0];
        const map = new Map<number, boolean>();

        let rightDigit = 1;
        for (; rightDigit < len; rightDigit++) {
            hash = (hash * BASE + nums[rightDigit]) % MOD;
            power = (power * BASE) % MOD
        }
        while (rightDigit <= n) {
            map.set(hash, !map.has(hash))

            if (rightDigit === n) break;

            const leftDigit = nums[rightDigit - len];
            const removed = (leftDigit * power) % MOD;
            hash = (hash - removed + MOD) % MOD
            hash = (hash * BASE + nums[rightDigit++]) % MOD;
        }

        for (const seenOnce of map.values()) {
            if (seenOnce) return true;
        }

        return false;
    }

    let lo = 1;
    let hi = n;
    while (lo <= hi) {
        const mid = lo + Math.floor((hi - lo) / 2);
        if (hasUnique(mid)) {
            hi = mid - 1;
        } else {
            lo = mid + 1;
        }
    }

    return lo;
};

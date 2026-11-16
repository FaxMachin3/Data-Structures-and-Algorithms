// LeetCode 3: Longest Substring Without Repeating Characters

function lengthOfLongestSubstring(s: string): number {
    let lo = 0;
    let hi = 0;
    let max = 0;
    const set = new Set<string>();

    while (hi < s.length) {
        if (!set.has(s[hi])) {
            set.add(s[hi++]);
        } else {
            max = Math.max(max, hi - lo);
            set.delete(s[lo++]);
        }
    }

    max = Math.max(max, hi - lo);

    return max;
}

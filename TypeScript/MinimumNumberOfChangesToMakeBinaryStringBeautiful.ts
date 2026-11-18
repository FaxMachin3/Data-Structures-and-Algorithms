// LeetCode 2914: Minimum Number of Changes to Make Binary String Beautiful
// Time: O(n). Extra space: O(1).

function minChanges(s: string): number {
    let count = 0;
    for(let i = 1; i < s.length; i += 2) {
        if(s[i] !== s[i-1]) count++;
    }
    return count;
};

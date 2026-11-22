// LeetCode 2124: Check if All A's Appears Before All B's
// Time: O(n). Extra space: O(1).

function checkString(s: string): boolean {
    let foundB = false;

    for(let i = 0; i < s.length; i++) {
        if(s[i] === 'b') foundB = true;
        else if(foundB && s[i] === 'a') return false;
    }

    return true;
};

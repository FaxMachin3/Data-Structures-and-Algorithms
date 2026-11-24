// LeetCode 3411: Maximum Subarray With Equal Products

function gcd(a: number, b: number) {
    if(b === 0) return a;
    return gcd(b, a%b);
}

function maxLength(nums: number[]): number {
    let longest = 0;

    for(let i = 0; i < nums.length; i++) {
        let p = 1;
        let g = 0;
        let l = 1;

        for(let j = i; j < nums.length; j++) {
            const num = nums[j];
            p *= num;
            g = gcd(g, num);
            l = (l/gcd(l, num))*num;

            if(p === g*l) longest = Math.max(longest, j-i+1);
            if(p > g*l) break;
        }
    }

    return longest;
};

// LeetCode 1979: Find Greatest Common Divisor of Array

const gcd = (a: number, b: number) => b === 0 ? a : gcd(b, a%b);
function findGCD(nums: number[]): number {
    let max = nums[0];
    let min = nums[0];

    for(const num of nums) {
        max = Math.max(max, num);
        min = Math.min(min, num);
    }

    return gcd(max, min);
};

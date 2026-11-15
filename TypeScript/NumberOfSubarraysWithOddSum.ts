// LeetCode 1524: Number of Sub-arrays With Odd Sum
// Time: O(n). Extra space: O(1).

function numOfSubarrays(arr: number[]): number {
    const MOD = 1_000_000_007;
    let sum = 0;
    let count = 0;
    let odds = 0;
    let evens = 1;

    for(let i = 0; i < arr.length; i++) {
        sum += arr[i];

        if(sum % 2 === 0) {
            evens++;
            count = (count + odds) % MOD;
        }
        else {
            odds++;
            count = (count + evens) % MOD;
        }
    }

    return count;
};

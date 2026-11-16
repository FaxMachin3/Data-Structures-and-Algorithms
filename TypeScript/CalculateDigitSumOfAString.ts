// LeetCode 2243: Calculate Digit Sum of a String

function digitSum(s: string, k: number): string {
    if(s.length <= k) return s;

    let str = "";

    for(let i = 0; i < s.length; i += k) {
        let sum = 0
        for(let j = i; j < s.length && j < i+k; j++) {
            sum += Number(s[j])
        }
        str += sum;
    }

    return digitSum(str, k);
};

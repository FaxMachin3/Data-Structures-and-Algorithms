// LeetCode 1071: Greatest Common Divisor of Strings

function dividesString(str1: string, str2: string, i: number): boolean {
    let j = 0;

    while(j < str2.length) {
        const compareI = j % (i+1);
        if(str1[compareI] !== str2[j++]) return false;
    }

    return true;
}

function gcdOfStrings(str1: string, str2: string): string {
    const m = str1.length;
    const n = str2.length;
    if(m > n) return gcdOfStrings(str2, str1);

    for(let i = m - 1; i >= 0; i--) {
        if(m % (i+1) !== 0 ||
        n % (i+1) !== 0) {
            continue;
        }
        if(dividesString(str1, str1, i) &&
            dividesString(str1, str2, i)) {
                return str1.substring(0, i+1);
            }
    }

    return "";
};

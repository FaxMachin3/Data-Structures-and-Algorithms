// LeetCode 345: Reverse Vowels of a String
// Time: O(n). Extra space: O(n).

function reverseVowels(s: string): string {
    const vowelSet = new Set(['A', 'E', 'I', 'O', 'U', 'a', 'e', 'i', 'o', 'u']);
    const result: string[] = s.split("");

    let lo = 0;
    let hi = s.length - 1;

    while (lo < hi) {
        while(lo < hi && !vowelSet.has(result[lo])) lo++;
        while(lo < hi && !vowelSet.has(result[hi])) hi--;

        if(lo >= hi) break;

        [result[lo], result[hi]] = [result[hi], result[lo]]
        lo++; hi--;
    }

    return result.join("");
};

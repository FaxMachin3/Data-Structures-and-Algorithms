// LeetCode 1768: Merge Strings Alternately
// Time: O(n + m). Extra space: O(n + m).

function mergeAlternately(word1: string, word2: string): string {
    const chrArr: string[] = new Array<string>(word1.length+word2.length);
    const maxLength = Math.max(word1.length, word2.length);

    let k = 0;
    for (let i = 0; i < maxLength; i++) {
        if (i < word1.length) chrArr[k++] = word1[i];
        if (i < word2.length) chrArr[k++] = word2[i];
    }

    return chrArr.join("");
};

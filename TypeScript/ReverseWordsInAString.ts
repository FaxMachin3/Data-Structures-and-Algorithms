// LeetCode 151: Reverse Words in a String
// Time: O(n). Extra space: O(n).

function reverseWords(s: string): string {
    return s.split(" ").filter(str => str.length > 0).reverse().join(" ");
};

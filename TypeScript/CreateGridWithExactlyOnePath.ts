// LeetCode 3963: Create Grid With Exactly One Path
// https://leetcode.com/problems/create-grid-with-exactly-one-path/
// Keep the top row and rightmost column free; block every other cell.
// The only path moves right across the top, then down the final column.
// Time: O(m * n). Output space: O(m * n).
function createGrid(m: number, n: number): string[] {
    if (m < 1) return [];
    if (m === 1) return [".".repeat(n)];

    const res = new Array<string>(m);

    for (let i = 0; i < m; i++) {
        if (i === 0) {
            res[i] = ".".repeat(n);
        } else {
            res[i] = "#".repeat(n - 1) + ".";
        }
    }

    return res;
}

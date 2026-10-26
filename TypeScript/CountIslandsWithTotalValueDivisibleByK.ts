// LeetCode 3619: Count Islands With Total Value Divisible by K
// https://leetcode.com/problems/count-islands-with-total-value-divisible-by-k/
// Time: O(rows * cols). Extra space: O(rows * cols) recursion stack.
// Mutates grid by setting visited land to 0.
// A large connected island may exceed the JavaScript recursion limit.

function sumOfIsland(
    grid: number[][],
    rows: number,
    cols: number,
    i: number,
    j: number
): number {
    if (
        i === rows || j === cols ||
        i < 0 || j < 0 ||
        grid[i][j] <= 0
    ) {
        return 0;
    }

    const curr = grid[i][j];
    grid[i][j] = 0;

    const sum = curr +
        sumOfIsland(grid, rows, cols, i + 1, j) +
        sumOfIsland(grid, rows, cols, i - 1, j) +
        sumOfIsland(grid, rows, cols, i, j + 1) +
        sumOfIsland(grid, rows, cols, i, j - 1);

    return sum;
}

function countIslands(grid: number[][], k: number): number {
    const rows = grid.length;
    const cols = grid[0].length;
    let totalIslands = 0;

    for (let i = 0; i < rows; i++) {
        for (let j = 0; j < cols; j++) {
            const sum = sumOfIsland(grid, rows, cols, i, j);
            if (sum > 0 && sum % k === 0) {
                totalIslands += 1;
            }
        }
    }

    return totalIslands;
}

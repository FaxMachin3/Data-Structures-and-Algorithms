// LeetCode 1254: Number of Closed Islands
// 0 = land, 1 = water. Visited land is marked as water.
// Time: O(rows * cols). Extra space: O(rows * cols) recursion stack.
// Mutates grid. Large connected components can exceed the JS call stack.
function isClosedIsland(
    grid: number[][],
    i: number,
    j: number,
    rows: number,
    cols: number
): boolean {
    if (i < 0 || j < 0 || i >= rows || j >= cols) {
        return false;
    }
    if (grid[i][j] === 1) return true;

    grid[i][j] = 1;

    // Explore every direction before combining: chained recursive &&
    // calls short-circuit and can leave an open component partly unvisited.
    const down = isClosedIsland(grid, i + 1, j, rows, cols);
    const up = isClosedIsland(grid, i - 1, j, rows, cols);
    const right = isClosedIsland(grid, i, j + 1, rows, cols);
    const left = isClosedIsland(grid, i, j - 1, rows, cols);

    return down && up && right && left;
}

function closedIsland(grid: number[][]): number {
    const rows = grid.length;
    if (rows === 0 || grid[0].length === 0) return 0;
    const cols = grid[0].length;
    let closedIslands = 0;

    for (let i = 1; i < rows - 1; i++) {
        for (let j = 1; j < cols - 1; j++) {
            if (grid[i][j] === 1) continue;
            if (isClosedIsland(grid, i, j, rows, cols)) {
                closedIslands++;
            }
        }
    }

    return closedIslands;
}

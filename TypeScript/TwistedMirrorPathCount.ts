// LeetCode 3665: Twisted Mirror Path Count
// https://leetcode.com/problems/twisted-mirror-path-count/
// Memoize valid continuations by (row, column, incoming direction).
// Mirrors force a turn; empty cells allow both right and down.
// Time: O(rows * cols). Extra space: O(rows * cols),
// plus O(rows + cols) for the recursion stack.
function uniquePaths(grid: number[][]): number {
    const MOD = 1_000_000_007;
    const rows = grid.length;
    const cols = grid[0].length;

    enum Direction {
        DOWN,
        RIGHT
    }

    const dp = Array.from({ length: rows }, () =>
        Array.from({ length: cols }, () =>
            new Array<number>(2).fill(-1)
        )
    );

    function uniquePathsHelper(i: number, j: number, prev: Direction): number {
        if (i === rows || j === cols) return 0;
        if (i === rows - 1 && j === cols - 1) return 1;

        if (dp[i][j][prev] !== -1) {
            return dp[i][j][prev];
        }

        let intermediatePaths = 0;

        if (grid[i][j] === 1) {
            if (prev === Direction.DOWN) {
                intermediatePaths = uniquePathsHelper(i, j + 1, Direction.RIGHT);
            } else {
                intermediatePaths = uniquePathsHelper(i + 1, j, Direction.DOWN);
            }
        } else {
            intermediatePaths =
                uniquePathsHelper(i + 1, j, Direction.DOWN) +
                uniquePathsHelper(i, j + 1, Direction.RIGHT);
        }

        dp[i][j][prev] = intermediatePaths % MOD;
        return dp[i][j][prev];
    }

    // The start is empty, so either initial direction gives the same count.
    return uniquePathsHelper(0, 0, Direction.DOWN);
}

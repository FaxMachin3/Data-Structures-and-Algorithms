using System;
public class SRLC {
    public static void Solve (char[][] board) {
        int rows = board.Length;
        int cols = board[0].Length;

        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (board[r][c] == 'O')
                    Dfs (board, r, c);
            }
        }
    }

    private static bool Dfs (char[][] board, int row, int col) {
        if (row < 0 || row >= board.Length || col < 0 || col >= board[0].Length)
            return true;

        if (board[row][col] == 'X')
            return true;

        if (board[row][col] == 'O' &&
            (row == 0 || row == board.Length - 1) ||
            (col == 0 || col == board[0].Length - 1))
            return false;

        board[row][col] = 'X';

        bool top = Dfs (board, row - 1, col);
        bool right = Dfs (board, row, col + 1);
        bool bottom = Dfs (board, row + 1, col);
        bool left = Dfs (board, row, col - 1);

        if (!(top && right && bottom && left)) {
            board[row][col] = 'O';
            return false;
        }

        return true;
    }
    // public static void Main (string[] args) {
    //     var input = new char[][] {
    //         new char[] { 'X', 'X', 'X', 'X' },
    //         new char[] { 'X', 'O', 'O', 'X' },
    //         new char[] { 'X', 'X', 'O', 'X' },
    //         new char[] { 'X', 'X', 'O', 'X' },
    //     };

    //     Solve (input);

    //     for (int i = 0; i < input.Length; i++) {
    //         for (int j = 0; j < input[0].Length; j++) {
    //             Console.Write (input[i][j] + " ");
    //         }
    //         Console.WriteLine ();
    //     }
    // }
}
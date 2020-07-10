using System;
public class VS {
    public static bool IsValidSudoku (char[][] board) {
        for (int i = 0; i < 9; i++) {
            for (int j = 0; j < 9; j++) {
                if (board[i][j] != '.' && !CheckValidity (board, i, j, board[i][j]))
                    return false;
            }
        }

        return true;
    }

    private static bool CheckValidity (char[][] board, int i, int j, char c) {
        bool[] rowHas = new bool[10];
        bool[] colHas = new bool[10];
        bool[] blockHas = new bool[10];
        int blockRow = (i / 3) * 3;
        int blockCol = (j / 3) * 3;

        for (int k = 0; k < 9; k++) {
            char row = board[k][j];
            char col = board[i][k];
            char block = board[blockRow + k / 3][blockCol + k % 3];

            if (row == '.' || col == '.' || block == '.')
                continue;

            if (rowHas[row - '0'] ||
                colHas[col - '0'] ||
                blockHas[block - '0'])
                return false;

            rowHas[row - '0'] = true;
            colHas[row - '0'] = true;
            blockHas[row - '0'] = true;
        }

        return true;
    }
    // public static void Main (string[] args) {
    //     Console.WriteLine (IsValidSudoku (new char[][] {
    //         new char[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
    //             new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
    //             new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
    //             new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
    //             new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
    //             new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
    //             new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
    //             new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
    //             new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
    //     }));
    // }
}
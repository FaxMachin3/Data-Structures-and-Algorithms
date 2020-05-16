using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
public class WS {
    public static bool Exist (char[][] board, string word) {
        int[] dr = new int[] {-1, 0, 1, 0 };
        int[] dc = new int[] { 0, 1, 0, -1 };

        Stack<Tuple<int, int, int>> s = new Stack<Tuple<int, int, int>> ();
        Stack<Tuple<int, int>> track = new Stack<Tuple<int, int>> ();

        for (int row = 0; row < board.Length; row++) {
            for (int col = 0; col < board[0].Length; col++) {
                if (board[row][col] != word[0]) continue;

                if (0 == word.Length - 1)
                    return true;

                bool[, ] visited = new bool[board.Length, board[0].Length];
                int[, ] subPath = new int[board.Length, board[0].Length];
                s.Push (new Tuple<int, int, int> (row, col, 0));

                while (s.Count != 0) {
                    Tuple<int, int, int> pos = s.Pop ();
                    int x = pos.Item1;
                    int y = pos.Item2;
                    int index = pos.Item3;

                    int countSubPath = 0;

                    visited[x, y] = true;

                    track.Push (new Tuple<int, int> (x, y));

                    for (int i = 0; i < 4; i++) {
                        int newRow = x + dr[i];
                        int newCol = y + dc[i];

                        if (newRow < 0 || newCol < 0) continue;
                        if (newRow >= board.Length || newCol >= board[0].Length) continue;
                        if (visited[newRow, newCol]) continue;

                        if (board[newRow][newCol] == word[index + 1]) {
                            if (index + 1 == word.Length - 1)
                                return true;
                            s.Push (new Tuple<int, int, int> (newRow, newCol, index + 1));
                            countSubPath++;
                        }
                    }

                    subPath[x, y] = countSubPath;
                    if (subPath[x, y] == 0) {
                        Tuple<int, int> tempPos = track.Pop ();
                        int cur_x = tempPos.Item1;
                        int cur_y = tempPos.Item2;
                        while (subPath[cur_x, cur_y] <= 1) {
                            visited[cur_x, cur_y] = false;
                            if (track.Count == 0) { break; }
                            tempPos = track.Pop ();
                            cur_x = tempPos.Item1;
                            cur_y = tempPos.Item2;
                        }
                        subPath[cur_x, cur_y]--;
                    }
                }

                s.Clear ();
                track.Clear ();
            }
        }

        return false;
    }
    // public static void Main (string[] args) {
    //     Console.WriteLine (Exist (new char[][] {
    //         new char[] { 'A', 'B', 'C', 'E' },
    //             new char[] { 'S', 'F', 'E', 'S' },
    //             new char[] { 'A', 'D', 'E', 'E' }
    //     }, "ABCESEEEFS"));
    // }
}
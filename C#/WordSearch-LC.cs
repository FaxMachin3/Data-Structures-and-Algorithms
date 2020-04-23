using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
public class WS {
    public static bool Exist (char[][] board, string word) {
        int[] dr = new int[] {-1, 0, 1, 0 };
        int[] dc = new int[] { 0, 1, 0, -1 };
        Stack<Tuple<int, int>> s = new Stack<Tuple<int, int>> ();
        for (int i = 0; i < board.Length; i++) {
            for (int j = 0; j < board[0].Length; j++) {
                s.Clear();
                int[, ] vis = new int[board.Length, board[0].Length];
                if (board[i][j] == word[0]) {
                    if (word.Length == 1) return true;
                    else {
                        s.Push (new Tuple<int, int> (i, j));
                        vis[i, j] = 1;
                    }
                }
                int index = 1;
                while (s.Count > 0) {
                    Tuple<int, int> popped = s.Pop ();
                    bool flag = true;
                    int x = popped.Item1;
                    int y = popped.Item2;
                    for (int k = 0; k < dr.Length; k++) {
                        int newX = x + dr[k];
                        int newY = y + dc[k];
                        if (newX < 0 || newY < 0) continue;
                        else if (newX >= board.Length || newY >= board[0].Length) continue;
                        else if (vis[newX, newY] == 1) continue;
                        else if (board[newX][newY] != word[index]) continue;

                        if (board[newX][newY] == word[index]) {
                            vis[newX, newY] = 1;
                            if (index == word.Length - 1) return true;
                            s.Push (new Tuple<int, int> (newX, newY));
                            flag = false;
                        }
                    }
                    if (!flag) index++;
                }
            }
        }
        return false;
    }
    // public static void Main (string[] args) {
    //     // Console.WriteLine (Exist (new char[][] {
    //     //     new char[] { 'A', 'B', 'C', 'E' },
    //     //         new char[] { 'S', 'F', 'E', 'S' },
    //     //         new char[] { 'A', 'D', 'E', 'E' }
    //     // }, "ABCESEEEFS"));
    // }
}
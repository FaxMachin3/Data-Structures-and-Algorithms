using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
public class RO {
    public static int OrangesRotting (int[][] grid) {
        Queue<Tuple<int, int>> q = new Queue<Tuple<int, int>> ();
        int minutesElapsed = 0;
        int goodApples = 0;

        int[] dr = new int[] {-1, 0, 1, 0 };
        int[] dc = new int[] { 0, -1, 0, 1 };

        for (int i = 0; i < grid.Length; i++) {
            for (int j = 0; j < grid[0].Length; j++) {
                if (grid[i][j] == 2) q.Enqueue (new Tuple<int, int> (i, j));
                if (grid[i][j] == 1) goodApples++;
            }
        }

        q.Enqueue (null);

        while (q.Count != 0) {
            Tuple<int, int> point = q.Dequeue ();
            if (point == null) {
                if (q.Count == 0)
                    break;
                q.Enqueue (null);
                minutesElapsed++;
                continue;
            }
            int x = point.Item1;
            int y = point.Item2;

            for (int i = 0; i < dr.Length; i++) {
                int newX = x + dr[i];
                int newY = y + dc[i];

                if (newX < 0 || newY < 0 || newX >= grid.Length || newY >= grid[0].Length)
                    continue;
                if (grid[newX][newY] == 2 || grid[newX][newY] == 0) continue;

                if (grid[newX][newY] == 1) {
                    goodApples--;
                    grid[newX][newY] = 2;
                    q.Enqueue (new Tuple<int, int> (newX, newY));
                }
            }
        }
        if(goodApples != 0) return -1;

        return minutesElapsed;
    }
    // public static void Main (string[] args) {
    //     Console.WriteLine (OrangesRotting (new int[][] {
    //         new int[] { 2, 1, 1 },
    //             new int[] { 1, 1, 0 },
    //             new int[] { 0, 1, 2 }
    //     }));
    // }
}
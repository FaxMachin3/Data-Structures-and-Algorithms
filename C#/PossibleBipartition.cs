using System;
using System.Collections.Generic;

public class PB {
    public static bool PossibleBipartition (int N, int[][] dislikes) {
        Dictionary<int, LinkedList<int>> adjacencyList = new Dictionary<int, LinkedList<int>> ();
        int[] color = new int[N + 1];
        color[0] = 2;

        for (int i = 1; i <= N; i++) {
            adjacencyList[i] = new LinkedList<int> ();
        }

        foreach (var ele in dislikes) {
            adjacencyList[ele[0]].AddLast (ele[1]);
            adjacencyList[ele[1]].AddLast (ele[0]);
        }

        for (int i = 1; i <= N; i++) {
            if (color[i] == 0 && !DFS (color, i, 0, adjacencyList))
                return false;
        }

        return true;
    }

    private static bool DFS (int[] color, int node, int parent,
        Dictionary<int, LinkedList<int>> adjacencyList) {
        if (color[node] == 0)
            color[node] = color[parent] == 1 ? 2 : 1;
        else
            return !(color[node] == color[parent]);

        foreach (var ele in adjacencyList[node]) {
            if (!DFS (color, ele, node, adjacencyList))
                return false;
        }

        return true;
    }

    // public static void Main (string[] args) {
    //     Console.WriteLine (PossibleBipartition (3, new int[][] {
    //         new int[] { 1, 2 },
    //             new int[] { 1, 3 },
    //             new int[] { 2, 3 }
    //     }));
    // }

    // private static bool BFS (int[] color, int node, Dictionary<int, LinkedList<int>> adjacencyList) {
    //     Queue<int> q = new Queue<int> ();
    //     q.Enqueue (node);
    //     color[node] = 1;

    //     while (q.Count != 0) {
    //         int curr = q.Dequeue ();
    //         foreach (var ele in adjacencyList[curr]) {
    //             if (color[ele] == 0) {
    //                 color[ele] = color[curr] == 1 ? 2 : 1;
    //                 q.Enqueue (ele);
    //             } else if (color[ele] == color[curr])
    //                 return false;
    //         }
    //     }

    //     return true;
    // }
}
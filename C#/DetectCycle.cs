/*
// Sample code to perform I/O:

name = Console.ReadLine();                  // Reading input from STDIN
Console.WriteLine("Hi, {0}.", name);        // Writing output to STDOUT

// Warning: Printing unwanted or ill-formatted data to output will cause the test cases to fail
*/

// Write your code here
using System;
using System.Collections.Generic;

public class DC {
    static Dictionary<int, LinkedList<int>> adjacencyList;
    static int totalCycles;

    public static void MakeList (int[] edge) {
        adjacencyList[edge[0]].AddLast (edge[1]);
        adjacencyList[edge[1]].AddLast (edge[0]);
    }

    public static bool isCycle (bool[] visited, int node, int parent) {
        visited[node] = true;

        foreach (var e in adjacencyList[node]) {
            if (!visited[e]) {
                if (isCycle (visited, e, node))
                    return true;
            } else if (e != parent)
                return true;
        }

        return false;
    }

    public static void CountCycle (int m) {
        bool[] visited = new bool[m + 1];

        for (int i = 1; i <= m; i++) {
            if (!visited[i]) {
                if (isCycle (visited, i, -1))
                    totalCycles++;
            }
        }
    }

    // public static void Main (string[] args) {
    //     int m = 5;
    //     // int n = 4;
    //     adjacencyList = new Dictionary<int, LinkedList<int>> ();
    //     totalCycles = 0;
    //     for (int i = 1; i <= m; i++) {
    //         adjacencyList[i] = new LinkedList<int> ();
    //     }
    //     int[][] input = new int[4][] {
    //         new int[] { 1, 2 },
    //         new int[] { 3, 4 },
    //         new int[] { 5, 4 },
    //         new int[] { 3, 5 },
    //     };
    //     foreach (var edge in input) {
    //         MakeList (edge);
    //     }
    //     CountCycle (m);
    //     Console.WriteLine (totalCycles);
    // }
}
using System;
using System.Collections;
using System.Collections.Generic;

public class To {
    public int to;
    public int cost;
    public To (int t, int c) {
        to = t;
        cost = c;
    }
}
public class CF {
    public static int FindCheapestPrice (int n, int[][] flights, int src, int dst, int K) {
        Dictionary<int, LinkedList<To>> adjacencyList = new Dictionary<int, LinkedList<To>> ();
        int[] cost = new int[n];
        Array.Fill (cost, int.MaxValue);
        cost[src] = 0;

        for (int i = 0; i < n; i++) {
            adjacencyList[i] = new LinkedList<To> ();
        }

        foreach (var data in flights) {
            adjacencyList[data[0]].AddLast (new To (data[1], data[2]));
        }

        Dfs (cost, adjacencyList, src, K);

        return cost[dst] == int.MaxValue ? -1 : cost[dst];
    }

    private static void Dfs (int[] cost, Dictionary<int, LinkedList<To>> adjacencyList, int node, int K) {
        if (K < 0)
            return;

        K--;

        foreach (var e in adjacencyList[node]) {
            cost[e.to] = Math.Min (cost[e.to], e.cost + cost[node]);
            Dfs (cost, adjacencyList, e.to, K);
        }
    }

    // public static void Main (string[] args) {
    //     // Console.WriteLine (FindCheapestPrice (4, new int[][] {
    //     //     new int[] { 0, 1, 1 },
    //     //         new int[] { 0, 2, 5 },
    //     //         new int[] { 1, 2, 1 },
    //     //         new int[] { 2, 3, 1 }
    //     // }, 0, 3, 1));
    // }
}
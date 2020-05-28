using System;
public class UF {
    static int[] parent;
    static int[] size;
    private static int Find (int node) {
        if (parent[node] != node)
            parent[node] = Find (parent[node]);
        return parent[node];
    }

    private static void Union (int node1, int node2) {
        int x = Find (node1);
        int y = Find (node2);

        parent[node1] = parent[node2];
    }

    public static bool CanFinish (int numCourses, int[][] prerequisites) {
        parent = new int[numCourses];
        size = new int[numCourses];

        for (int i = 0; i < numCourses; i++) {
            parent[i] = i;
            size[i] = 1;
        }

        foreach (var e in prerequisites) {
            if (Find (e[0]) == Find (e[1]))
                return false;
            Union (e[0], e[1]);
        }

        return true;
    }
    // public static void Main (string[] args) {
    //     Console.WriteLine (CanFinish (3, new int[][] {
    //         new int[] { 0, 1 },
    //             new int[] { 0, 2 },
    //             new int[] { 1, 2 },
    //     }));
    // }
}
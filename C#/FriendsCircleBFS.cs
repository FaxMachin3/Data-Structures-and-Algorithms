using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class FC {

    // Complete the maxCircle function below.
    static int[] maxCircle(int[][] queries) {
        int[] result = new int[queries.Length];
        int maxHandShakes = 0;
        Dictionary<int,LinkedList<int>> adjacentList = new Dictionary<int,LinkedList<int>>();
        for(int i = 0; i < queries.Length; i++){
            adjacentList[queries[i][0]] = new LinkedList<int>();
            adjacentList[queries[i][1]] = new LinkedList<int>();
        }
        for(int i = 0; i < queries.Length; i++){
            adjacentList[queries[i][0]].AddLast(queries[i][1]);
            adjacentList[queries[i][1]].AddLast(queries[i][0]);
            int currHandShakes = dfs(adjacentList,queries[i][0]);
            if(currHandShakes > maxHandShakes)
                maxHandShakes = currHandShakes;
            result[i] = maxHandShakes;
        }
        return result;
    }
    static int dfs(Dictionary<int,LinkedList<int>> adjacentList, int root){
        int count = 1;
        Dictionary<int, bool> visited = new Dictionary<int, bool>();
        Queue<int> q = new Queue<int>();
        q.Enqueue(root);
        visited[root] = true;
        while(q.Count > 0){
            int f = q.Dequeue();
            foreach(var ele in adjacentList[f]){
                if(!visited.ContainsKey(ele)){
                    q.Enqueue(ele);
                    visited[ele] = true;
                    count++;
                }
            }
        }
        return count;
    }

    // static void Main(string[] args) {
    //     int[] ans = maxCircle(new int[][]{
    //         new int[]{1,2},
    //         new int[]{3,4},
    //         new int[]{1,3},
    //         new int[]{5,6},
    //         new int[]{5,7},
    //         new int[]{7,4},
    //     });

    //     Console.WriteLine(string.Join("\n", ans));
    // }
}

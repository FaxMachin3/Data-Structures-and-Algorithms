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

class NC {
    static int findShortest(int graphNodes, int[] graphFrom, int[] graphTo, long[] ids, int val) {
        int n = graphNodes;
        int dist = -1;
        int[] distance = new int[n + 1];
        Queue<int> queue = new Queue<int>();
        bool[] visited = new bool[n + 1];
        Dictionary<int, LinkedList<int>> adjacencyList = new Dictionary<int, LinkedList<int>>();

        for(int i = 1; i <= n; i++){
            adjacencyList[i] = new LinkedList<int>();
        }

        for(int i = 0; i < graphFrom.Length; i++){
            adjacencyList[graphFrom[i]].AddLast(graphTo[i]);
            adjacencyList[graphTo[i]].AddLast(graphFrom[i]);
        }

        for(int i = 0; i < n; i++){
            if(ids[i] == val){
                queue.Enqueue(i + 1);
            }
        }
        int[] parent = new int[n + 1];
        while(queue.Count > 0){
            int front = queue.Dequeue();
            foreach(var ele in adjacencyList[front]){
                if(ele == parent[front])
                        continue;
                if(ids[ele - 1] == ids[front - 1] && ids[ele - 1] == val && ids[front - 1] == val){
                    dist = 1;
                    break;
                }
                else{
                    if(parent[ele] != 0){
                        if(parent[ele] == parent[front])
                            continue;
                        dist = distance[ele] + distance[front] + 1;
                        break;
                    }
                    else{
                        if(parent[front] == 0)
                            parent[ele] = front;
                        else{
                            if(parent[ele] == 0)
                                parent[ele] = parent[front];
                        }
                    }
                }
                queue.Enqueue(ele);
                distance[ele] = distance[front] + 1;
            }
            if(dist != -1)
                break;
        }
        return dist;
    }

    // static void Main(string[] args) {
    //     int ans = findShortest(4, new int[]{1, 1, 4}, new int[]{2, 3, 2}, new long[]{1, 2, 3, 4}, 2);

    //     Console.WriteLine(ans);
    // }
}
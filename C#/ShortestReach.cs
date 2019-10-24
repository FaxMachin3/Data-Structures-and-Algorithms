using System;
using System.Collections.Generic;
using System.IO;
class SR {
    static void ShortestReach(int[][] edges, int n, int source){
        int[] distance = new int[n + 1];
        Dictionary<int, LinkedList<int>> adjacencyList = new Dictionary<int, LinkedList<int>>();
        Queue<int> queue = new Queue<int>();

        for(int i = 1; i <= n; i++){
            adjacencyList[i] = new LinkedList<int>();
        }

        for(int i = 0; i < edges.Length; i++){
            adjacencyList[edges[i][0]].AddLast(edges[i][1]);
            adjacencyList[edges[i][1]].AddLast(edges[i][0]);
        }

        queue.Enqueue(source);

        while(queue.Count > 0){
            int front = queue.Dequeue();
            foreach(var ele in adjacencyList[front]){
                if(distance[ele] == 0 && ele != source){
                    distance[ele] = distance[front] + 6;
                    queue.Enqueue(ele);
                }
            }
        }

        for(int i = 1; i <= n; i++){
            if(i == source)
                continue;
            else if(distance[i] == 0)
                Console.Write(-1 + " ");
            else
                Console.Write(distance[i] + " ");
        }
        Console.WriteLine();
    }
    // static void Main(String[] args) {
    //     ShortestReach(new int[][]{
    //         new int[]{1,2},
    //         new int[]{1,3},
    //     }, 4, 1);
    // }
}


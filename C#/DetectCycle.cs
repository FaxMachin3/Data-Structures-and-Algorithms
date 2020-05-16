// using System;
// using System.Collections.Generic;

// public class DC {
//     static Dictionary<int, LinkedList<int>> adjacencyList;
//     static int totalCycles;

//     public static void MakeList (int[] edge) {
//         adjacencyList[edge[0]].AddLast (edge[1]);
//         adjacencyList[edge[1]].AddLast (edge[0]);
//     }

//     public static void CountCycle (int m) {
//         bool[] visited = new bool[m + 1];
//         int[] parent = new int[m + 1];
//         parent[1] = -1;
//         parent[0] = -1;

//         Stack<int> s = new Stack<int> ();
//         for (int i = 1; i <= m; i++) {
//             if (visited[i]) continue;
//             s.Push (i);
//             visited[i] = true;
//             while (s.Count > 0) {
//                 bool flag = false;
//                 int node = s.Pop ();
//                 foreach (var ele in adjacencyList[node]) {
//                     if (!visited[ele]) {
//                         visited[ele] = true;
//                         parent[ele] = node;
//                         s.Push (ele);
//                     } else if (ele != parent[node]) {
//                         totalCycles++;
//                         flag = true;
//                         break;
//                     }
//                 }
//                 if (flag) {
//                     s.Clear ();
//                     break;
//                 }
//             }
//         }
//     }

//     // public static void Main (string[] args) {
//     //     int[] arr = new int[] { 17, 15 };
//     //     int m = arr[0];
//     //     int n = arr[1];
//     //     adjacencyList = new Dictionary<int, LinkedList<int>> ();
//     //     totalCycles = 0;
//     //     for (int i = 1; i <= m; i++) {
//     //         adjacencyList[i] = new LinkedList<int> ();
//     //     }
//     //     MakeList (new int[] { 1, 8 });
//     //     MakeList (new int[] { 1, 12 });
//     //     MakeList (new int[] { 5, 11 });
//     //     MakeList (new int[] { 11, 9 });
//     //     MakeList (new int[] { 9, 15 });
//     //     MakeList (new int[] { 15, 5 });
//     //     MakeList (new int[] { 4, 13 });
//     //     MakeList (new int[] { 3, 13 });
//     //     MakeList (new int[] { 4, 3 });
//     //     MakeList (new int[] { 10, 16 });
//     //     MakeList (new int[] { 7, 10 });
//     //     MakeList (new int[] { 16, 7 });
//     //     MakeList (new int[] { 14, 3 });
//     //     MakeList (new int[] { 14, 4 });
//     //     MakeList (new int[] { 17, 6 });
//     //     MakeList (new int[] { 12, 8 });
//     //     CountCycle (m);
//     //     Console.WriteLine (totalCycles);
//     // }
// }
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

class RAL2 {

    // Complete the roadsAndLibraries function below.
    static long roadsAndLibraries(long n, long c_lib, long c_road, long[][] cities) {
        if(c_lib <= c_road  ){
            return n * c_lib;
        }
        Dictionary<long, LinkedList<long>> adjacencyList = new Dictionary<long, LinkedList<long>>();
        bool[] visited = new bool[n + 1];
        Stack<long> stack = new Stack<long>();

        for(long i = 1; i <= n; i++){
            adjacencyList[i] = new LinkedList<long>();
        }

        for(long i = 0; i < cities.Length; i++){
            adjacencyList[cities[i][0]].AddLast(cities[i][1]);
            adjacencyList[cities[i][1]].AddLast(cities[i][0]);
        }

        long noOfComponents = 0;
        long noOfEdges = 0;
        //DFS
        for(int i = 1; i <= n; i++){
            if(visited[i]){
                continue;
            }
            stack.Push(i);
            visited[i] = true;
            noOfComponents++;
            while(stack.Count > 0){
                long top = stack.Pop();
                foreach(var e in adjacencyList[top]){
                    if(!visited[e]){
                        stack.Push(e);
                        visited[e] = true;
                        noOfEdges++;
                    }
                }
            }
        }

        // Console.WriteLine(noOfComponents+" "+noOfEdges);

        // foreach(var ele in adjacencyList){
        //     Console.Write(ele.Key+" --> ");
        //     foreach(var e in ele.Value){
        //         Console.Write(e+" ");
        //     }
        //     Console.WriteLine();
        // }
        
        return noOfComponents *  c_lib + noOfEdges * c_road;
    }

    // static void Main(string[] args) {
    //     long q = Convert.ToInt64(Console.ReadLine());

    //     for (long qItr = 0; qItr < q; qItr++) {
    //         string[] nmC_libC_road = Console.ReadLine().Split(' ');

    //         long n = Convert.ToInt64(nmC_libC_road[0]);

    //         long m = Convert.ToInt64(nmC_libC_road[1]);

    //         long c_lib = Convert.ToInt64(nmC_libC_road[2]);

    //         long c_road = Convert.ToInt64(nmC_libC_road[3]);

    //         long[][] cities = new long[m][];

    //         for (long i = 0; i < m; i++) {
    //             cities[i] = Array.ConvertAll(Console.ReadLine().Split(' '), citiesTemp => Convert.ToInt64(citiesTemp));
    //         }

    //         long result = roadsAndLibraries(n, c_lib, c_road, cities);

    //         Console.WriteLine(result);
    //     }
    // }
}

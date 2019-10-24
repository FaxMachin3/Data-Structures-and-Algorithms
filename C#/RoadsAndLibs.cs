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

class RAL {

    // Complete the roadsAndLibraries function below.
    static long roadsAndLibraries(long n, long c_lib, long c_road, long[][] cities) {
        if(c_lib <= c_road)
            return c_lib * n;
            
        long[,] adjacentMatrix = new long[n + 1, n + 1];
        Stack<long> stack = new Stack<long>();
        bool[] visited = new bool[n + 1];

        foreach(var city in cities){
            adjacentMatrix[city[0], city[1]] = 1;
            adjacentMatrix[city[1], city[0]] = 1;
        }

        // for(int i = 0; i < adjacentMatrix.Length; i++){
        //     for(int j = 0; j < adjacentMatrix.Length; j++){
        //         Console.Write(adjacentMatrix[i,j]+" ");
        //     }
        //     Console.WriteLine();
        // }

        long noOfComponents = 0;
        long noOfEdges = 0;
        
        for(long i = 1; i <= n; i++){
            if(visited[i]){
                continue;
            }
            stack.Push(i);
            visited[i] = true;
            noOfComponents++;
            while(stack.Count > 0){
                long top = stack.Pop();
                for(long j = 1; j <= n; j++){
                    if(!visited[j] && adjacentMatrix[top,j] == 1){
                        stack.Push(j);
                        visited[j] = true;
                        noOfEdges++;
                    }
                }
            }
        }

        // Console.WriteLine(noOfCycles+" "+noOfRoads);

        return noOfComponents * c_lib + noOfEdges * c_road;
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

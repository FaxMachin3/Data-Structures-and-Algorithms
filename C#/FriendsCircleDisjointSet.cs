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
class FCDS {
    static Dictionary<int,int> parent;
    static Dictionary<int,int> size;
    static int max = 0;
    public static int Find(int x){
        int root = x;
        
        while(parent[root] != root){
            root = parent[root];
        }

        while(x != root){
            int temp = parent[x];
            parent[x] = root;
            x = temp;
        }

        return root;
    }
    public static void Union(int x, int y){
        int a = Find(x);
        int b = Find(y);

        if(a == b)  return;

        if(size[a] > size[b]){
            parent[b] = a;
            size[a] += size[b];
            if(size[a] > max)   max = size[a];
        }
        else{
            parent[a] = b;
            size[b] += size[a];
            if(size[b] > max)   max = size[b];
        }
        
    }

    // Complete the maxCircle function below.
    static int[] maxCircle(int[][] queries) {
        int[] result = new int[queries.Length];
        parent = new Dictionary<int, int>();
        size = new Dictionary<int, int>();

        for(int i = 0; i < queries.Length; i++){
            parent[queries[i][0]] = queries[i][0];
            parent[queries[i][1]] = queries[i][1];
            size[queries[i][0]] = 1;
            size[queries[i][1]] = 1;
        }

        for(int i = 0; i < queries.Length; i++){
            Union(queries[i][0],queries[i][1]);
            result[i] = max;
        }

        return result;
    }
    // static void Main(string[] args) {
    //     int[] ans = maxCircle(new int[][]{
    //         new int[]{1,2z},
    //         new int[]{3,4},
    //         new int[]{1,3},
    //         new int[]{5,6},
    //         new int[]{5,7},
    //         new int[]{7,4},
    //     });

    //     Console.WriteLine(string.Join("\n", ans));
    // }
}

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

class Result
{
    static int[] parent;
    static int[] size;
    public static void Union(int a, int b){
        int x = Find(a);
        int y = Find(b);

        if(x == y)  return;
        
        if(size[a] > size[b]){
            parent[b] = a;
            size[a] += size[b];
        }
        else{
            parent[a] = b;
            size[b] += size[a];
        }
    }
    public static int Find(int a){
        int root = a;

        while(parent[root] != root){
            root = parent[root];
        }

        while(a != root){
            int temp = parent[a];
            parent[a] = root;
            a = temp;
        }
        return root;
    }
    public static int kruskals(int gNodes, List<int> gFrom, List<int> gTo, List<int> gWeight)
    {

        int min = 0;
        parent = new int[gNodes + 1];
        size = new int[gNodes + 1];

        for(int i = 1; i < gNodes; i++){
            parent[i] = i;
            size[i] = 1;
        }
        
        // List<Edge> list = new List<Edge>();
        // for(int i = 0; i < gWeight.Count; i++){
        //     list.Add(new Edge(gFrom[i],gTo[i],gWeight[i]));
        // }

        // var sortedWeight = list.OrderBy(x => x.gWeight).ToList<Edge>();

        // for(int i = 0; i < sortedWeight.Count; i++){
        //     Console.WriteLine(sortedWeight[i].gFrom+" "+sortedWeight[i].gTo+" "+sortedWeight[i].gWeight+" ");
        // }

        // ! BUBBLE SORT:
        for(int i = 0; i < gWeight.Count; i++){
            for(int j = 0; j < gWeight.Count - i - 1; j++){
                if(gWeight[j] > gWeight[j + 1]){
                    int temp = gWeight[j];
                    gWeight[j] = gWeight[j+1];
                    gWeight[j+1] = temp;
                    temp = gTo[j];
                    gTo[j] = gTo[j+1];
                    gTo[j+1] = temp;
                    temp = gFrom[j];
                    gFrom[j] = gFrom[j+1];
                    gFrom[j+1] = temp;
                }
                else if(gWeight[j] == gWeight[j + 1]){
                    int sum1 = gFrom[j] + gTo[j] + gWeight[j];
                    int sum2 = gFrom[j + 1] + gTo[j + 1] + gWeight[j + 1];
                    if(sum1 >= sum2){
                        int temp = gWeight[j];
                        gWeight[j] = gWeight[j+1];
                        gWeight[j+1] = temp;
                        temp = gTo[j];
                        gTo[j] = gTo[j+1];
                        gTo[j+1] = temp;
                        temp = gFrom[j];
                        gFrom[j] = gFrom[j+1];
                        gFrom[j+1] = temp;
                    }
                }
            }
        }
        
        //! KRUSHKAL's ALGO
        int count = 0;
        for(int i = 0; i < gWeight.Count && count < gNodes; i++){
            int x = Find(gFrom[i]);
            int y = Find(gTo[i]);
            if(x == y)
                continue;
            else{
                count++;
                min += gWeight[i];
                Union(x,y);
            }
        }

        for(int i = 0; i < gWeight.Count; i++){
            Console.WriteLine(gFrom[i]+" "+gTo[i]+" "+gWeight[i]);
        }
        return min;
    }

}

class KK
{
    // public static void Main(string[] args)
    // {
    //     int res = Result.kruskals(4, new List<int>{2,3,2,2,3,3}, new List<int>{1,4,4,4,2,2}, new List<int>{1000,299,200,100,300,6});
    //     Console.WriteLine(res);
    // }
}

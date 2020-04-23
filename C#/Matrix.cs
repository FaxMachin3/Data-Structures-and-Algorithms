using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;

class MAT {
    static int[] parents;
    static bool[] containsCar;
    static int result = 0;
    static int find (int n) {
        if (parents[n] != n)
            parents[n] = find (parents[n]);
        return parents[n];
    }

    static void union (int a, int b, int weight) {
        var ar = find (a);
        var br = find (b);
        if (containsCar[ar] && containsCar[br])
            result += weight;
        if (!containsCar[ar] && !containsCar[br]) {
            parents[br] = ar;
        } else {
            parents[br] = ar;
            containsCar[br] = true;
            containsCar[ar] = true;
        }
    }
    struct Road {
        public int source { get; set; }
        public int dest { get; set; }
        public int weight { get; set; }
    }
    // Complete the minTime function below.
    static int minTime (int[][] roads, int[] machines) {
        int n = roads.Length + 1;
        int k = machines.Length;
        parents = new int[n];
        containsCar = new bool[n];
        var cars = new HashSet<int> ();
        for (int i = 0; i < k; i++) {
            cars.Add (machines[i]);
            containsCar[machines[i]] = true;
        }

        for (int i = 0; i < n; i++)
            parents[i] = i;
        var rds = new List<Road> ();
        for (int i = 0; i < n - 1; i++)
            rds.Add (new Road { source = roads[i][0], dest = roads[i][1], weight = roads[i][2] });
        rds.Sort (new roadComparer ());
        for (int i = 0; i < n - 1; i++) {
            union (rds[i].source, rds[i].dest, rds[i].weight);
        }
        return result;
    }

    class roadComparer : IComparer<Road> {
        public int Compare (Road x, Road y) {
            return y.weight - x.weight;
        }
    }

    // static void Main(string[] args)
    // {
    //     int result = minTime(new int[][]{
    //         new int[]{2,1,8},
    //         new int[]{1,0,5},
    //         new int[]{2,4,5},
    //         new int[]{1,3,4},
    //         // new int[]{9, 78, 35},
    //         // new int[]{9 , 54, 45},
    //         // new int[]{78,  69, 27},
    //         // new int[]{9 , 55, 9},
    //         // new int[]{9 , 1, 78},
    //         // new int[]{1 , 92, 7},
    //         // new int[]{55,  42, 57},
    //         // new int[]{1 , 84, 4},
    //         // new int[]{1 , 5, 38},
    //         // new int[]{92,  8 ,75},
    //         // new int[]{55,  30, 99},
    //         // new int[]{69,  7 ,9},
    //         // new int[]{1 , 81 ,45},
    //         // new int[]{8 , 31 ,4},
    //         // new int[]{42,  23, 100},
    //         // new int[]{78,  95, 3},
    //         // new int[]{54,  14, 14},
    //         // new int[]{84,  53, 80},
    //         // new int[]{92,  32, 8},
    //         // new int[]{42,  86, 40},
    //         // new int[]{1 , 64 ,93},
    //         // new int[]{78,  60, 65},
    //         // new int[]{64,  76, 24},
    //         // new int[]{42,  89, 86},
    //         // new int[]{7 , 28 ,48},
    //         // new int[]{69,  62, 26},
    //         // new int[]{1 , 40 ,23},
    //         // new int[]{78,  38, 29},
    //         // new int[]{8 , 44 ,39},
    //         // new int[]{78,  3 ,37},
    //         // new int[]{54,  26, 17},
    //         // new int[]{62,  50, 24},
    //         // new int[]{76,  66, 37},
    //         // new int[]{30,  51, 75},
    //         // new int[]{86,  43, 91},
    //         // new int[]{5 , 77 ,32},
    //         // new int[]{64,  91, 11},
    //         // new int[]{14,  10, 36},
    //         // new int[]{26,  20, 19},
    //         // new int[]{9 , 52 ,50},
    //         // new int[]{77,  94, 32},
    //         // new int[]{44,  67, 63},
    //         // new int[]{64,  15, 61},
    //         // new int[]{92,  0 ,73},
    //         // new int[]{10,  37, 23},
    //         // new int[]{89,  2 ,37},
    //         // new int[]{92,  18, 51},
    //         // new int[]{26,  47, 25},
    //         // new int[]{30,  87, 15},
    //         // new int[]{47,  36, 35},
    //         // new int[]{92,  72, 16},
    //         // new int[]{28,  75, 93},
    //         // new int[]{78,  73, 66},
    //         // new int[]{20,  19, 64},
    //         // new int[]{73,  57, 1},
    //         // new int[]{91,  6 ,50},
    //         // new int[]{54,  33, 41},
    //         // new int[]{78,  11, 38},
    //         // new int[]{37,  71, 55},
    //         // new int[]{5 , 63 ,52},
    //         // new int[]{10,  46, 22},
    //         // new int[]{94,  82, 19},
    //         // new int[]{95,  83, 51},
    //         // new int[]{57,  90, 10},
    //         // new int[]{63,  58, 94},
    //         // new int[]{43,  45, 23},
    //         // new int[]{72,  68, 62},
    //         // new int[]{82,  85, 88},
    //         // new int[]{58,  4, 94},
    //         // new int[]{82,  41, 62},
    //         // new int[]{3 , 22, 68},
    //         // new int[]{54,  70, 78},
    //         // new int[]{31,  74, 27},
    //         // new int[]{36,  29, 61},
    //         // new int[]{33,  24, 76},
    //         // new int[]{40,  35, 61},
    //         // new int[]{83,  79, 51},
    //         // new int[]{8 , 59, 20},
    //         // new int[]{45,  34, 26},
    //         // new int[]{38,  12, 18},
    //         // new int[]{70,  99, 25},
    //         // new int[]{40,  80, 81},
    //         // new int[]{31,  97, 58},
    //         // new int[]{69,  21, 16},
    //         // new int[]{83,  13, 22},
    //         // new int[]{80,  48, 49},
    //         // new int[]{97,  65, 44},
    //         // new int[]{74,  17, 1},
    //         // new int[]{68,  16, 92},
    //         // new int[]{50,  98, 54},
    //         // new int[]{94,  27, 76},
    //         // new int[]{81,  61, 67},
    //         // new int[]{85,  49, 96},
    //         // new int[]{81,  93, 31},
    //         // new int[]{22,  25, 67},
    //         // new int[]{57,  96, 93},
    //         // new int[]{82,  88, 92},
    //         // new int[]{86,  56, 80},
    //         // new int[]{25,  39, 44},
    //     }, new int[]{
    //         2,4,0
    //         // 1
    //         // ,95
    //         // ,90
    //         // ,11
    //         // ,48
    //         // ,49
    //         // ,23
    //         // ,6
    //         // ,0
    //         // ,76
    //         // ,3
    //         // ,83
    //         // ,85
    //         // ,31
    //         // ,44
    //         // ,54
    //         // ,87
    //         // ,38
    //         // ,16
    //         // ,61
    //         // ,22
    //         // ,21
    //         // ,29
    //     });

    //     Console.WriteLine(result);
    // }
}
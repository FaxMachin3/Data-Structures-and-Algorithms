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
class TNS {
    static void Print<T> (T a) {
        Console.WriteLine (a);
    }
    // static void Main (string[] args) {
    //     // int a = 3; //0011
    //     // int b = 4; //0100

    //     // Console.WriteLine(a | b); // 7
    //     // Console.WriteLine(a & b); // 0
    //     // Console.WriteLine(a ^ b); // 7
    //     // Console.WriteLine(~a); // -4
    //     // Console.WriteLine(~b); // -5
    //     // Console.WriteLine(-123 ^ -123); //0
    //     // Console.WriteLine(a >> 1); // 1
    //     // Console.WriteLine(a << 1); // 6
    //     // Console.WriteLine(b >> 1); // 2
    //     // Console.WriteLine(b << 1); // 8
    //     // Console.WriteLine("~~~~~~~~~~~~~~~~~~");
    //     // Console.WriteLine('z' - 'a');
    //     // Console.WriteLine("~~~~~~~~~~~~~~~~~~");
    //     // double temp = 0;
    //     // for (int i = 31; i >= 0; i--) {
    //     //     temp += Math.Pow (2, i);
    //     //     Console.Write (temp + " ");
    //     // }
    //     // for (int i = 0; i < 33; i++) {
    //     //     temp += Math.Pow (2, i);
    //     //     Console.Write (temp + " ");
    //     // }
    //     // Console.WriteLine ();
    //     // Console.WriteLine (temp);
    //     // Console.Write(Convert.ToString((uint)Math.Pow(2,31) + (uint)Math.Pow(2,30),2));

    //     // Dictionary<int, LinkedListNode<Tuple<int, int>>> map = new Dictionary<int, LinkedListNode<Tuple<int, int>>> ();
    //     // LinkedList<Tuple<int, int>> testList = new LinkedList<Tuple<int, int>> ();
    //     // LinkedListNode<Tuple<int, int>> temp = new LinkedListNode<Tuple<int, int>> (new Tuple<int, int> (1, 2));
    //     // map.Add (1, temp);
    //     // testList.AddLast (temp);
    //     // testList.AddLast (new Tuple<int, int> (5, 3));
    //     // Console.WriteLine (map[1].Next.Value);
    //     // Console.WriteLine (testList.First.Value);

    //     // Console.WriteLine (Convert.ToChar ((1 + Math.Min (
    //     //     Math.Min ('3' - '0',
    //     //         '3' - '0'),
    //     //     '4' - '0')).ToString ()));

    //     // Console.WriteLine(long.MinValue);

    //     // int[][] staggeredArr = new int[5][] {
    //     //     new int[] { 3, 4 },
    //     //         new int[] { 2, 3 },
    //     //         new int[] { 5, 6 },
    //     //         new int[] { 1, 2 },
    //     //         new int[] { 0, 1 }
    //     // };

    //     // Array.Sort(staggeredArr, (x,y) => (x[0]-y[0]));

    //     // foreach(var e in staggeredArr){
    //     //     Console.WriteLine(e[0]+" "+e[1]);
    //     // }

    //     // int[] arr = {0,1,0,0,1};
    //     // Console.WriteLine(Convert.ToString(15,16));

    //     // TNS[] test = new TNS[10];
    //     // foreach(var ele in test) {
    //     //     Console.WriteLine(ele == null);
    //     // }
    // }
}
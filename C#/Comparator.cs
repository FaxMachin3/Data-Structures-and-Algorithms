using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Compi : IComparer<string>
{
    public int Compare(string x, string y){
        if(x.Length < y.Length) return -1;
        else if(x.Length > y.Length)    return 1;
        else{
            return x.CompareTo(y);
        }
    }
}

class Comparer{
    // public static void Main(string[] args){
    //     Compi c = new Compi();
    //     string[] arr = new string[5]{"subham", "raj", "killer", "rajesh", "rakesh"};
    //     Array.Sort(arr,delegate(string x, string y){
    //         if(x.Length < y.Length) return -1;
    //         else if(x.Length > y.Length)    return 1;
    //         else{
    //             return x.CompareTo(y);
    //         }
    //     });
    //     Console.WriteLine(string.Join(" ",arr));
    
    // int[] a = new int[] {10, 40, 33, 33, 31, 56, 57, 6};
    // Console.WriteLine(string.Join( " " , a.Distinct().ToArray().OrderBy(x => x)));
    // }
}
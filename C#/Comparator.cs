using System;
using System.Collections;
using System.Collections.Generic;

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
    //     Array.Sort(arr,c);
    //     Console.WriteLine(string.Join(" ",arr));
    // }
}
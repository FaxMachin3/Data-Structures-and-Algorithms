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

class FB {

    // Complete the flippingBits function below.
    static long flippingBits(long n) {
        long[] totalBits = new long[32];
        StringBuilder bits = new StringBuilder(Convert.ToString(n,2));
        int j = bits.Length - 1;
        for(int i = totalBits.Length - 1; i >= 32 - bits.Length; i--){
            totalBits[i] = Convert.ToInt64(bits[j--].ToString());
        }
        Console.WriteLine(string.Join("",totalBits));
        return -1;
    }

    // static void Main(string[] args) {

    //         long result = flippingBits(3);
    //         Console.WriteLine(result);
    //         Dictionary<int,LinkedList<int>> adjacentList = new Dictionary<int,LinkedList<int>>;
    //         for(int i = 1; i <= queries.Length * 2; i++){
    //             adjacentList[i] = new LinkedList<int>();
    //         }
    //         for(int i = 0; i < queries.Length; i++){
    //             adjacentList[i].AddLast()
    //         }
    // }
}

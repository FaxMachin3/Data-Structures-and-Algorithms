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
class TNS {
    static void Print<T>(T a){
        Console.WriteLine(a);
    }
    // static void Main(string[] args) {
    //     int a = 3; //0011
    //     int b = 4; //0100

    //     Console.WriteLine(a | b); // 7
    //     Console.WriteLine(a & b); // 0
    //     Console.WriteLine(a ^ b); // 7
    //     Console.WriteLine(~a); // -4
    //     Console.WriteLine(~b); // -5
    //     Console.WriteLine(-123 ^ -123); //0
    //     Console.WriteLine(a >> 1); // 1
    //     Console.WriteLine(a << 1); // 6
    //     Console.WriteLine(b >> 1); // 2
    //     Console.WriteLine(b << 1); // 8
    //     Console.WriteLine("~~~~~~~~~~~~~~~~~~");
    //     Console.WriteLine('z' - 'a');
    //     Console.WriteLine("~~~~~~~~~~~~~~~~~~");
    //     double temp = 0;
    //     for(int i = 31;i >= 0; i--){
    //         temp += Math.Pow(2,i);
    //         Console.Write(temp+" ");
    //     }
    //     Console.WriteLine();
    //     Console.Write(Convert.ToString((uint)Math.Pow(2,31) + (uint)Math.Pow(2,30),2));
    // }
}

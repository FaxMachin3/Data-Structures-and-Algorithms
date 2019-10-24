

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

class RSD {

    // Complete the superDigit function below.
    static int superDigit(string n, int k) {
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < k % 9; i++){
            sb.Append(n);
        }
        return Helper(sb);
    }
    static int Helper(StringBuilder str){
        if(str.Length == 1)
            return Convert.ToInt32(str.ToString());
        else{
            long sum = 0;
            for(int i = 0; i < str.Length; i++){
                sum += Convert.ToInt32(str[i].ToString());
            }
            return Helper(new StringBuilder(sum.ToString()));
        }
    }

    // static void Main(string[] args) {
    //     int result = superDigit("123", 3);
    //     Console.WriteLine(result);
    // }
}

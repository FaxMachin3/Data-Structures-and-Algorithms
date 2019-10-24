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

class PP {

    // Complete the poisonousPlants function below.
    static int poisonousPlants(int[] p) {
        int n = p.Length;
        int[] days = new int[n];
        Stack<int> tempStack = new Stack<int>();
        int min = p[0];
        int max = 0;
        tempStack.Push(0);
        for(int i = 1; i < n; i++){
            if(p[i] > p[i - 1])
                days[i] = 1;
            
            min = min < p[i]? min : p[i];

            while((tempStack.Count != 0) && (p[tempStack.Peek()] >= p[i])){
                if(p[i] > min)
                    days[i] = days[i] > days[tempStack.Peek()] + 1? days[i] : days[tempStack.Peek()] + 1;
                tempStack.Pop();
            }
            max = max > days[i]? max : days[i];
            tempStack.Push(i);
        }

        return max;
    }

    // static void Main(string[] args) {
    //     int[] p = new int[] {6, 5, 8, 4, 7, 10, 9};
    //     int result = poisonousPlants(p);

    //     Console.WriteLine(result);
    // }
}

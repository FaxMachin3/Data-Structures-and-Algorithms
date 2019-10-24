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
class Stock{
    public static int[] StockSpan(int[] stocks){
        int[] spanArr = new int[stocks.Length];
        Stack indexes = new Stack(stocks.Length);
        indexes.Push(0);
        spanArr[0] = 1;
        int i = 1;
        while(i < stocks.Length){
            if(indexes.IsEmpty()){
                indexes.Push(i);
                spanArr[i] = i + 1;
                i++;
            }
            else{
                int peek = indexes.Peek();
                if(stocks[i] >= stocks[peek]){
                    int pop = indexes.Pop();
                }
                else{
                    spanArr[i] = i - peek;
                    indexes.Push(i);
                    i++;
                }
            }
        }
        return spanArr;
    }
    // static void Main(string[] args){
    //     int[] h = new int[] {10, 4, 5, 90, 120, 80};
    //     int[] result = StockSpan(h);
    //     Console.Write(string.Join(" ",result));
    // }
}
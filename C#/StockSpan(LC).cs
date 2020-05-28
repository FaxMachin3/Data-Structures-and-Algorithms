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
public class NodeInfo {
    public NodeInfo nextBiggerNode;
    public int price;
    public int count;
    public NodeInfo (NodeInfo node, int p, int c) {
        nextBiggerNode = node;
        price = p;
        count = c;
    }
}
public class StockSpanner {
    LinkedList<NodeInfo> stock;
    public StockSpanner () {
        stock = new LinkedList<NodeInfo> ();
    }

    public int Next (int price) {
        int count = 1;

        NodeInfo temp = null;
        if (stock.First != null)
            temp = stock.First.Value; //head

        while (temp != null && temp.price <= price) {
            count += temp.count;
            temp = temp.nextBiggerNode;
        }

        stock.AddFirst (new NodeInfo (temp, price, count));

        return count;
    }
}

public class SPLC {
    // public static void Main () {
    //     StockSpanner obj = new StockSpanner ();
    //     Console.WriteLine (obj.Next (100));
    //     Console.WriteLine (obj.Next (80));
    //     Console.WriteLine (obj.Next (60));
    //     Console.WriteLine (obj.Next (70));
    //     Console.WriteLine (obj.Next (60));
    //     Console.WriteLine (obj.Next (75));
    //     Console.WriteLine (obj.Next (85));
    // }
}
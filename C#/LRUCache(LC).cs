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
public class LRUCache {
    int size;
    LinkedList<Tuple<int, int>> lruCache;
    Dictionary<int, LinkedListNode<Tuple<int, int>>> map;
    public LRUCache (int capacity) {
        size = capacity;
        lruCache = new LinkedList<Tuple<int, int>> ();
        map = new Dictionary<int, LinkedListNode<Tuple<int, int>>> ();
    }

    public int Get (int key) {
        if (map.ContainsKey (key)) {
            LinkedListNode<Tuple<int, int>> temp = map[key];
            lruCache.Remove (temp);
            AddLast (temp.Value.Item1, temp.Value.Item2);
            return temp.Value.Item2;
        }
        return -1;
    }

    public void Put (int key, int value) {
        if (!map.ContainsKey (key)) {
            if (lruCache.Count == size) {
                LinkedListNode<Tuple<int, int>> temp = lruCache.First;
                map.Remove (temp.Value.Item1);
                lruCache.Remove (temp);
            }
            AddLast (key, value);
        } else {
            lruCache.Remove (map[key]);
            AddLast (key, value);
        }
    }

    public void AddLast (int key, int value) {
        LinkedListNode<Tuple<int, int>> node = new LinkedListNode<Tuple<int, int>> (
            new Tuple<int, int> (key, value));
        lruCache.AddLast (node);
        map[key] = node;
    }
}

class DriverLRU {
    // public static void Main (String[] args) {
    //     LRUCache obj = new LRUCache (2);
    //     obj.Put (2, 1);
    //     obj.Put (1, 1);
    //     obj.Put (2, 3);
    //     obj.Put (4, 1);
    //     Console.WriteLine (obj.Get (1));
    //     Console.WriteLine (obj.Get (2));
    // }
}
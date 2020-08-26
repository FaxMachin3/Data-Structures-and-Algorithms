using System;
using System.Collections.Generic;
using System.Text;
public class StreamChecker {
    List<TrieNode> pointers;
    TrieNode root;
    StringBuilder s;

    public StreamChecker (string[] words) {
        root = new TrieNode ();
        pointers = new List<TrieNode> ();
        s = new StringBuilder ();

        foreach (var word in words) {
            Insert (word);
        }
    }

    public bool Query (char letter) {
        s.Append (letter);

        return Search (letter);
    }

    private void Insert (string word) {
        var temp = root;

        for (int i = word.Length - 1; i >= 0; i--) {
            int index = word[i] - 'a';

            if (temp.children[index] == null)
                temp.children[index] = new TrieNode ();

            temp = temp.children[index];
        }

        temp.isLeaf = true;
    }

    private bool Search (char c) {
        var temp = root;

        for (int i = s.Length - 1; i >= 0; i--) {
            int index = s[i] - 'a';
            if (temp.children[index] == null)
                return false;
            else if (temp.children[index].isLeaf)
                return true;
            temp = temp.children[index];
        }

        return false;
    }
}

public class SOC {
    // public static void Main (string[] args) {
    //     StreamChecker obj = new StreamChecker (new string[] {
    //         "cd",
    //         "f",
    //         "kl"
    //     });
    //     Console.WriteLine (obj.Query ('a'));
    //     Console.WriteLine (obj.Query ('b'));
    //     Console.WriteLine (obj.Query ('c'));
    //     Console.WriteLine (obj.Query ('d'));
    //     Console.WriteLine (obj.Query ('e'));
    //     Console.WriteLine (obj.Query ('f'));
    //     Console.WriteLine (obj.Query ('g'));
    //     Console.WriteLine (obj.Query ('h'));
    //     Console.WriteLine (obj.Query ('i'));
    //     Console.WriteLine (obj.Query ('j'));
    //     Console.WriteLine (obj.Query ('k'));
    //     Console.WriteLine (obj.Query ('l'));
    // }
}
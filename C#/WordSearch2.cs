using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TrieNode {
    public TrieNode[] children;
    public bool isLeaf;
    public string word;

    public TrieNode () {
        children = new TrieNode[26];
    }
}
public class Trie {
    public TrieNode root;

    public Trie () {
        root = new TrieNode ();
    }

    public void Insert (string word) {
        TrieNode temp = root;

        foreach (var chr in word) {
            int index = chr - 'a';
            if (temp.children[index] == null)
                temp.children[index] = new TrieNode ();
            temp = temp.children[index];
        }

        temp.isLeaf = true;
        temp.word = word;
    }
}

public class WS2 {
    public static IList<string> FindWords (char[][] board, string[] words) {
        HashSet<string> result = new HashSet<string> ();
        int m = board.Length;
        int n = board[0].Length;
        bool[, ] visited = new bool[m, n];

        Trie t = new Trie ();
        foreach (var word in words) {
            t.Insert (word);
        }

        for (int r = 0; r < m; r++) {
            for (int c = 0; c < n; c++) {
                if (t.root.children[board[r][c] - 'a'] != null)
                    FindWordsUtil (result, board, visited, r, c, t.root);
            }
        }

        return result.ToList<string> ();
    }

    private static void FindWordsUtil (HashSet<string> result, char[][] board, bool[, ] visited,
        int row, int col, TrieNode node) {
        if (row < 0 ||
            row >= board.Length ||
            col < 0 ||
            col >= board[0].Length)
            return;

        if (node.children[board[row][col] - 'a'] == null)
            return;

        if (visited[row, col])
            return;

        if (node.children[board[row][col] - 'a'].isLeaf)
            result.Add (node.children[board[row][col] - 'a'].word);

        visited[row, col] = true;

        FindWordsUtil (result, board, visited, row + 1, col, node.children[board[row][col] - 'a']);
        FindWordsUtil (result, board, visited, row, col + 1, node.children[board[row][col] - 'a']);
        FindWordsUtil (result, board, visited, row - 1, col, node.children[board[row][col] - 'a']);
        FindWordsUtil (result, board, visited, row, col - 1, node.children[board[row][col] - 'a']);

        visited[row, col] = false;
    }
    // public static void Main (string[] args) {
    //     Console.WriteLine (FindWords (new char[][] {
    //         new char[] { 'o', 'a', 'a', 'n' },
    //             new char[] { 'e', 't', 'a', 'e' },
    //             new char[] { 'i', 'h', 'k', 'r' },
    //             new char[] { 'i', 'f', 'l', 'v' }
    //     }, new string[] { "oath", "pea", "eat", "rain" }));
    // }
}
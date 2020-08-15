using System;
public class WordDictionary {
    public TrieNode root;
    /** Initialize your data structure here. */
    public WordDictionary () {
        root = new TrieNode ();
    }

    /** Adds a word into the data structure. */
    public void AddWord (string word) {
        TrieNode temp = root;

        for (int i = 0; i < word.Length; i++) {
            int index = word[i] - 'a';

            if (temp.children[index] == null)
                temp.children[index] = new TrieNode ();

            temp = temp.children[index];
        }

        temp.isLeaf = true;
    }

    /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
    public bool Search (string word) {
        TrieNode temp = root;
        return SearchUtil (word, 0, temp);
    }

    private bool SearchUtil (string word, int index, TrieNode temp) {
        if (index >= word.Length)
            return true;

        if (word[index] == '.') {
            foreach (var child in temp.children) {
                if (child != null && SearchUtil (word, index + 1, child))
                    return true;
            }
        } else {
            int i = word[index] - 'a';
            if (temp.children[i] == null)
                return false;
            else
                return SearchUtil (word, index + 1, temp.children[i]);
        }

        return false;
    }
}

public class TestWD {
    // public static void Main (string[] args) {
    //     WordDictionary obj = new WordDictionary ();
    //     obj.AddWord ("bad");
    //     obj.AddWord ("dad");
    //     obj.AddWord ("mad");
    //     Console.WriteLine (obj.Search ("pad"));
    //     Console.WriteLine (obj.Search ("bad"));
    //     Console.WriteLine (obj.Search (".ad"));
    //     Console.WriteLine (obj.Search ("b.."));
    // }
}
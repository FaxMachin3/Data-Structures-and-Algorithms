using System;
using System.Collections.Generic;
using System.Text;
public class WB2 {
    public static IList<string> WordBreak (string s, IList<string> wordDict) {
        IList<string> result = new List<string> ();
        Trie t = new Trie ();

        foreach (var word in wordDict) {
            t.Insert (word);
        }

        PopulateStrings (result, t.root, t.root, new StringBuilder (), s, 0);

        return result;
    }

    private static void PopulateStrings (IList<string> result, TrieNode t, TrieNode temp,
        StringBuilder tempString, string s, int index) {
        if (index == s.Length - 1) {
            tempString.Append (s[index]);

            if (temp.children[s[index] - 'a'] != null && temp.children[s[index] - 'a'].isLeaf) {
                Console.WriteLine (tempString.ToString ());
                result.Add (tempString.ToString ());
            }

            tempString.Remove (tempString.Length - 1, 1);

            return;
        }

        int i = s[index] - 'a';

        if (temp.children[i] != null) {
            tempString.Append (s[index]);

            if (temp.children[i].isLeaf) {
                tempString.Append (" ");
                PopulateStrings (result, t, t, tempString, s, index + 1);
                tempString.Remove (tempString.Length - 1, 1);
            }

            PopulateStrings (result, t, temp.children[i], tempString, s, index + 1);
            tempString.Remove (tempString.Length - 1, 1);
        }
    }
    // public static void Main (string[] args) {
    //     WordBreak ("catsanddog", new List<string> {
    //         "cat",
    //         "cats",
    //         "and",
    //         "sand",
    //         "dog"
    //     });
    // }
}
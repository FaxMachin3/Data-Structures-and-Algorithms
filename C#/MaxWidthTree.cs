using System;
using System.Collections;
using System.Collections.Generic;
public class MaxWidthTree {
    public static int WidthOfBinaryTree (TreeNode root) {
        List<int> lefts = new List<int> ();
        return DFS (root, 1, 0, lefts);
    }

    private static int DFS (TreeNode node, int index, int depth, List<int> lefts) {
        if (node == null)
            return 0;

        if (depth >= lefts.Count)
            lefts.Add (index);

        int curr = index + 1 - lefts[depth];
        int left = DFS (node.left, index * 2, depth + 1, lefts);
        int right = DFS (node.right, index * 2 + 1, depth + 1, lefts);

        return Math.Max (curr, Math.Max (left, right));
    }
    // public static void Main (string[] args) {
    //     TreeNode root = new TreeNode (1);
    //     root.left = new TreeNode (3);
    //     root.right = new TreeNode (2);
    //     root.left.left = new TreeNode (5);
    //     root.left.right = new TreeNode (3);
    //     root.right.left = new TreeNode (9);
    //     Console.WriteLine (WidthOfBinaryTree (root));
    // }
}
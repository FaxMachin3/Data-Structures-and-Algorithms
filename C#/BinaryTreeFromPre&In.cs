using System;
using System.Collections.Generic;
public class BTFPI {
    public static TreeNode BuildTree (int[] preorder, int[] inorder) {
        if (preorder == null || preorder.Length == 0)
            return null;

        Dictionary<int, int> mapIndex = new Dictionary<int, int> ();

        for (int i = 0; i < inorder.Length; i++) {
            mapIndex[inorder[i]] = i;
        }

        return BuildTreeUtil (preorder, inorder, mapIndex, 0, preorder.Length - 1, 0, inorder.Length - 1);
    }

    private static TreeNode BuildTreeUtil (int[] preorder, int[] inorder, Dictionary<int, int> mapIndex,
        int pStart, int pEnd, int iStart, int iEnd) {
        if (pStart > pEnd || iStart > iEnd)
            return null;

        TreeNode root = new TreeNode (preorder[pStart]);

        int rootIndex = mapIndex[preorder[pStart]];

        int leftSize = rootIndex - iStart;
        int rightSize = iEnd - rootIndex;

        root.left = BuildTreeUtil (preorder, inorder, mapIndex,
            pStart + 1, pStart + leftSize - 1, iStart, rootIndex - 1);
        root.right = BuildTreeUtil (preorder, inorder, mapIndex,
            pEnd - rightSize, pEnd, rootIndex + 1, iEnd);

        return root;
    }
    public static void Main (string[] args) {
        Console.WriteLine (BuildTree (new int[] { 3, 9, 20, 15, 7 }, new int[] { 9, 3, 15, 20, 7 }));
    }
}
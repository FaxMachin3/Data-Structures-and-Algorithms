using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode (int x) { val = x; }
}

public class BSTPreorder {
    public static int ConstructBST (TreeNode root, int pos, int[] preorder, int min, int max) {
        if (pos == preorder.Length || preorder[pos] < min || preorder[pos] > max) return pos;

        if (preorder[pos] < root.val) {
            root.left = new TreeNode (preorder[pos]);
            pos++;
            pos = ConstructBST (root.left, pos, preorder, min, root.val - 1);
        }

        if (pos == preorder.Length || preorder[pos] < min || preorder[pos] > max) return pos;

        root.right = new TreeNode (preorder[pos]);
        pos++;
        pos = ConstructBST (root.right, pos, preorder, root.val + 1, max);
        return pos;
    }
    public static TreeNode BstFromPreorder (int[] preorder) {
        if (preorder.Length == 0) return null;

        TreeNode root = new TreeNode (preorder[0]);
        if (preorder.Length == 1) return root;

        int postion = ConstructBST (root, 1, preorder, int.MinValue, int.MaxValue);
        return root;
    }
    public static void Main (string[] args) {
        TreeNode bst = BstFromPreorder (new int[] { 8, 5, 1, 7, 10, 12 });
    }
}
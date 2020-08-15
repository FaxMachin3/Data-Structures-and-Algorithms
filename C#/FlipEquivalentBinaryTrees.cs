using System;
public class FEBT {
    public static bool FlipEquiv (TreeNode root1, TreeNode root2) {
        Invert (root1);
        return FlipEquivUtil (root1, root2);
    }

    private static TreeNode Invert (TreeNode root1) {
        if (root1 == null)
            return null;

        root1.left = Invert (root1.left);
        root1.right = Invert (root1.right);

        (root1.left, root1.right) = (root1.right, root1.left);

        return root1;
    }

    private static bool FlipEquivUtil (TreeNode root1, TreeNode root2) {
        if (root1 == null || root2 == null)
            return root1 == root2;

        Console.WriteLine (root1.val + " " + root2.val);
        if (root1.val != root2.val)
            return false;

        return FlipEquivUtil (root1.left, root2.left) &&
            FlipEquivUtil (root1.right, root2.right);
    }
    // public static void Main (string[] args) {
    //     TreeNode root1 = new TreeNode (1);
    //     root1.left = new TreeNode (2);
    //     root1.right = new TreeNode (3);
    //     root1.left.left = new TreeNode (4);
    //     root1.left.right = new TreeNode (5);
    //     root1.right.left = new TreeNode (6);
    //     root1.left.right.left = new TreeNode (7);
    //     root1.left.right.right = new TreeNode (8);

    //     TreeNode root2 = new TreeNode (1);
    //     root2.right = new TreeNode (2);
    //     root2.left = new TreeNode (3);
    //     root2.right.left = new TreeNode (4);
    //     root2.right.right = new TreeNode (5);
    //     root2.right.left = new TreeNode (6);
    //     root2.left.right.left = new TreeNode (7);
    //     root2.left.right.right = new TreeNode (8);

    //     FlipEquiv (root1, root2);
    // }
}
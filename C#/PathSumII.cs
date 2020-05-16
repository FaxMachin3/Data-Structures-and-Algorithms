using System;
using System.Collections;
using System.Collections.Generic;

public class TreeNodePS {
    public int val;
    public TreeNodePS left;
    public TreeNodePS right;
    public TreeNodePS (int val = 0, TreeNodePS left = null, TreeNodePS right = null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class PS {
    public static IList<IList<int>> PathSum (TreeNodePS root, int sum) {
        IList<IList<int>> result = new List<IList<int>> ();
        PathSumUtil (root, sum, result, new List<int> (), null);

        return result;
    }
    private static void PathSumUtil (TreeNodePS node, int sum, IList<IList<int>> result,
        List<int> tempList, TreeNodePS currParent) {
        if (node == null) return;

        sum -= node.val;
        tempList.Add (node.val);
        if (sum == 0 && node.left == null && node.right == null) {
            result.Add (new List<int> (tempList));
        }

        PathSumUtil (node.left, sum, result, tempList, node);
        PathSumUtil (node.right, sum, result, tempList, node);

        tempList.RemoveAt(tempList.Count - 1);
    }
    // public static void Main (string[] args) {
    //     TreeNodePS root = new TreeNodePS (5);
    //     root.left = new TreeNodePS (4);
    //     root.right = new TreeNodePS (8);

    //     root.left.left = new TreeNodePS (11);

    //     root.left.left.left = new TreeNodePS (7);
    //     root.left.left.right = new TreeNodePS (2);

    //     root.right.left = new TreeNodePS (13);
    //     root.right.right = new TreeNodePS (4);

    //     root.right.right.left = new TreeNodePS (5);
    //     root.right.right.right = new TreeNodePS (1);

    //     var result = PathSum (root, 22);
    //     Console.WriteLine ();
    //     Console.WriteLine ();
    //     Console.WriteLine ();
    // }
}
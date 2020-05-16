using System;
using System.Collections;
using System.Collections.Generic;
public class TreeNodeVO {
    public int val;
    public TreeNodeVO left;
    public TreeNodeVO right;
    public TreeNodeVO (int val = 0, TreeNodeVO left = null, TreeNodeVO right = null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
public class NodeVO {
    public int val;
    public int depth;
    public NodeVO (int a, int b) {
        val = a;
        depth = b;
    }
}
public class VO {
    static Dictionary<int, List<NodeVO>> color = new Dictionary<int, List<NodeVO>> ();
    static int min = int.MaxValue;
    static int max = int.MinValue;
    public static IList<IList<int>> VerticalTraversal (TreeNodeVO root) {
        IList<IList<int>> result = new List<IList<int>> ();

        FindMinMax (root, 0);

        for (int i = min; i <= max; i++) {
            color[i] = new List<NodeVO> ();
        }

        FillMap (root, 0, 0);

        foreach (var value in color.Values) {

            value.Sort ((x, y) => {
                if (x.depth == y.depth)
                    return x.val - y.val;
                else
                    return x.depth - y.depth;
            });

            List<int> temp = new List<int> ();

            foreach (var n in value) {
                temp.Add (n.val);
            }

            result.Add (temp);
        }

        return result;
    }

    private static void FindMinMax (TreeNodeVO nodeVO, int key) {
        if (nodeVO == null)
            return;

        min = Math.Min (min, key);
        max = Math.Max (max, key);

        FindMinMax (nodeVO.left, key - 1);
        FindMinMax (nodeVO.right, key + 1);
    }

    private static void FillMap (TreeNodeVO nodeVO, int key, int depth) {
        if (nodeVO == null)
            return;

        color[key].Add (new NodeVO (nodeVO.val, depth));

        FillMap (nodeVO.left, key - 1, depth + 1);
        FillMap (nodeVO.right, key + 1, depth + 1);
    }
    // public static void Main (string[] args) {
    //     TreeNodeVO root = new TreeNodeVO (0);
    //     root.left = new TreeNodeVO (8);
    //     root.right = new TreeNodeVO (1);

    //     root.right.left = new TreeNodeVO (3);
    //     root.right.right = new TreeNodeVO (2);

    //     root.right.left.right = new TreeNodeVO (4);
    //     root.right.right.left = new TreeNodeVO (5);

    //     root.right.left.right.right = new TreeNodeVO (7);
    //     root.right.right.left.left = new TreeNodeVO (6);

    //     var result = VerticalTraversal (root);
    //     Console.WriteLine ();
    //     Console.WriteLine ();
    //     Console.WriteLine ();
    // }
}
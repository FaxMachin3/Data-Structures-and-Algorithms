using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Node1{
        public int data {get;set;}
        public Node1 leftNode {get;set;}
        public Node1 rightNode {get;set;}
    }

class SN {
    static int[][] result;
    public static void InOrderTraversal(Node1 root, int i = 0){
        if(root == null) return;
        // result = new int[1];
        InOrderTraversal(root.leftNode);
        Console.Write(root.data+" ");
        InOrderTraversal(root.rightNode);
    }
    static int[][] swapNodes(int[][] indexes, int[] queries) {
        result = new int[queries.Length][];
        Node1 root = new Node1() {data = 1};
        Queue<Node1> queue = new Queue<Node1>();
        queue.Enqueue(root);

        for(int i = 0; i < indexes.Length; i++){
            Node1 front = queue.Dequeue();
            int left = indexes[i][0];
            int right = indexes[i][1];
            if(left != -1){
                front.leftNode = new Node1() {data = left};
                queue.Enqueue(front.leftNode);
            }
            if(right != -1){
                front.rightNode = new Node1() {data = right};
                queue.Enqueue(front.rightNode);
            }
        }

        // !SWAP
        for(int i = 0; i < queries.Length; i++){
            Queue<Node1> tempQueue = new Queue<Node1>();
            int k = 1;
            tempQueue.Enqueue(root);
            tempQueue.Enqueue(null);
            while(tempQueue.Count > 0){
                Node1 front = tempQueue.Dequeue();
                
                if(front == null){
                    tempQueue.Enqueue(null);
                    if(tempQueue.Peek() == null)    break;
                    k++;
                    continue;
                }
                
                if(front.leftNode != null)
                    tempQueue.Enqueue(front.leftNode);
                if(front.rightNode != null)
                    tempQueue.Enqueue(front.rightNode);
                
                if(k % queries[i] == 0){
                    Node1 temp = new Node1();
                    temp = front.leftNode;
                    front.leftNode = front.rightNode;
                    front.rightNode = temp;
                }
            }
            // InOrderTraversal(root);
            // *IN-order traversal
            int[] tempArray = new int[indexes.Length + 1];
            Stack<Node1> stack = new Stack<Node1>();
            int a = 0;
            Node1 current = root;
            while(current != null || stack.Count > 0){
                while(current != null){
                    stack.Push(current);
                    current = current.leftNode;
                }

                current = stack.Pop();

                tempArray[a++] = current.data;

                current = current.rightNode;
            }
            result[i] = tempArray;
        }

        return result;
    }

    // static void Main(string[] args) {
    //     int[][] result = swapNodes(
    //         new int[][]{
    //             new int[]{2, 3},
    //             new int[]{4, -1},
    //             new int[]{5, -1},
    //             new int[]{6, -1},
    //             new int[]{7, 8},
    //             new int[]{-1, 9},
    //             new int[]{-1, -1},
    //             new int[]{10, 11},
    //             new int[]{-1, -1},
    //             new int[]{-1, -1},
    //         },
    //         new int[] {
    //             2, 4
    //         }
    //     );

    //     // Console.WriteLine("IGNORE: "+String.Join("\n", result.Select(x => String.Join(" ", x))));
    //     for(int i = 0; i < result.Length; i++){
    //         for(int j = 0; j <result[0].Length; j++){
    //             Console.Write(result[i][j]+" ");
    //         }
    //         Console.WriteLine();
    //     }
    // }
}

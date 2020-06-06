using System;
using System.Collections.Generic;
public class MaxHeap {
    int[] maxHeap;
    int lastIndex;
    public MaxHeap (int size) {
        maxHeap = new int[size];
        lastIndex = -1;
    }
    public int GetParentIndex (int i) {
        return (i - 1) / 2 < 0 ? -1 : (i - 1) / 2;
    }
    public int GetLeftChildIndex (int i) {
        return (i * 2) + 1 > lastIndex ? -1 : (i * 2) + 1;
    }
    public int GetRightChildIndex (int i) {
        return (i * 2) + 2 > lastIndex ? -1 : (i * 2) + 2;
    }
    public int GetParent (int i) {
        int index = (i - 1) / 2;
        if (index >= 0) {
            return maxHeap[index];
        }
        return -1;
    }
    public int GetLeftChild (int i) {
        int index = (i * 2) + 1;
        if (index <= lastIndex) {
            return maxHeap[index];
        }
        return -1;
    }
    public int GetRightChild (int i) {
        int index = (i * 2) + 2;
        if (index <= lastIndex) {
            return maxHeap[index];
        }
        return -1;
    }
    public int Poll () {
        if (lastIndex < 0) return -1;
        int temp = maxHeap[0];
        maxHeap[0] = maxHeap[lastIndex];
        maxHeap[lastIndex] = 0;
        lastIndex--;
        BubbleDown (0);
        return temp;
    }
    public int Peek () {
        if (lastIndex >= 0) return maxHeap[0];
        return -1;
    }
    public void Insert (int ele) {
        maxHeap[++lastIndex] = ele;
        BubbleUp (lastIndex);
    }
    public void BubbleUp (int index) {
        while (GetParent (index) != -1 && GetParent (index) < maxHeap[index]) {
            Swap (GetParentIndex (index), index);
            index = GetParentIndex (index);
        }
    }
    public void BubbleDown (int index) {
        while (GetLeftChildIndex (index) != -1) {
            int smallChildIndex = GetLeftChildIndex (index);
            if (GetRightChild (index) != -1 && maxHeap[smallChildIndex] < GetRightChild (index))
                smallChildIndex = GetRightChildIndex (index);
            if (maxHeap[smallChildIndex] < maxHeap[index]) break;
            Swap (index, smallChildIndex);
            index = smallChildIndex;
        }
    }
    public void Swap (int i, int j) {
        int temp = maxHeap[i];
        maxHeap[i] = maxHeap[j];
        maxHeap[j] = temp;
    }
}
class SolMHeap {
    // static void Main (string[] args) {
    //     int[] arr = { 50, 60, 34, 21, 6, 78, 23, 67, 34, 67, 89, 1 };
    //     MaxHeap newHeap = new MaxHeap (arr.Length);
    //     foreach (var ele in arr) {
    //         newHeap.Insert (ele);
    //     }
    //     Console.WriteLine (newHeap.Poll ());
    //     Console.WriteLine (newHeap.Poll ());
    //     Console.WriteLine (newHeap.Poll ());
    //     Console.WriteLine (newHeap.Poll ());
    //     Console.WriteLine (newHeap.Poll ());
    //     Console.WriteLine (newHeap.Poll ());
    //     Console.WriteLine (newHeap.Poll ());
    //     Console.WriteLine (newHeap.Poll ());
    //     Console.WriteLine (newHeap.Poll ());
    //     Console.WriteLine (newHeap.Poll ());
    //     Console.WriteLine (newHeap.Poll ());
    //     Console.WriteLine (newHeap.Poll ());
    //     Console.WriteLine (newHeap.Poll ());
    //     Console.WriteLine (newHeap.Poll ());
    //     Console.WriteLine (newHeap.Poll ());
    //     Console.WriteLine (newHeap.Poll ());
    //     Console.WriteLine (newHeap.Poll ());
    //     Console.WriteLine (newHeap.Poll ());
    //     Console.WriteLine (newHeap.Poll ());
    // }
}
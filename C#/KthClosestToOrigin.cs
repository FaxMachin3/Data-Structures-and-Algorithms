using System;
public class MaxHeapKth {
    int[] maxHeapKth;
    int lastIndex;
    int[][] points;
    public MaxHeapKth (int size, int[][] p) {
        maxHeapKth = new int[size];
        points = p;
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
        if (i == 0) return -1;
        int index = (i - 1) / 2;
        if (index >= 0) {
            return maxHeapKth[index];
        }
        return -1;
    }
    public int GetLeftChild (int i) {
        int index = (i * 2) + 1;
        if (index <= lastIndex) {
            return maxHeapKth[index];
        }
        return -1;
    }
    public int GetRightChild (int i) {
        int index = (i * 2) + 2;
        if (index <= lastIndex) {
            return maxHeapKth[index];
        }
        return -1;
    }
    public int Poll () {
        if (lastIndex < 0) return -1;
        int temp = maxHeapKth[0];
        maxHeapKth[0] = maxHeapKth[lastIndex];
        maxHeapKth[lastIndex] = 0;
        lastIndex--;
        BubbleDown (0);
        return temp;
    }
    public int Peek () {
        if (lastIndex >= 0) return maxHeapKth[0];
        return -1;
    }
    public void Insert (int ele) {
        maxHeapKth[++lastIndex] = ele;
        BubbleUp (lastIndex);
    }
    public void BubbleUp (int index) {
        while (GetParent (index) != -1) {
            int i = GetParent (index);
            int j = maxHeapKth[index];
            int parrent = points[i][0] * points[i][0] + points[i][1] * points[i][1];
            int current = points[j][0] * points[j][0] + points[j][1] * points[j][1];
            if (parrent > current) break;
            Swap (GetParentIndex (index), index);
            index = GetParentIndex (index);
        }
    }
    public void BubbleDown (int index) {
        while (GetLeftChildIndex (index) != -1) {
            int smallChildIndex = GetLeftChildIndex (index);
            int i, j, smallChild;
            if (GetRightChild (index) != -1) {
                i = maxHeapKth[smallChildIndex];
                j = GetRightChild (index);
                smallChild = points[i][0] * points[i][0] + points[i][1] * points[i][1];
                int rightChild = points[j][0] * points[j][0] + points[j][1] * points[j][1];
                if (smallChild < rightChild)
                    smallChildIndex = GetRightChildIndex (index);
            }
            i = maxHeapKth[smallChildIndex];
            j = maxHeapKth[index];
            smallChild = points[i][0] * points[i][0] + points[i][1] * points[i][1];
            int child = points[j][0] * points[j][0] + points[j][1] * points[j][1];
            if (smallChild < child) break;
            Swap (index, smallChildIndex);
            index = smallChildIndex;
        }
    }
    public void Swap (int i, int j) {
        int temp = maxHeapKth[i];
        maxHeapKth[i] = maxHeapKth[j];
        maxHeapKth[j] = temp;
    }
}

public class SolutionKth {
    public static int[][] KClosest (int[][] points, int K) {
        int[][] result = new int[K][];
        MaxHeapKth heap = new MaxHeapKth (K, points);

        int i = 0;
        while (i < K) {
            heap.Insert (i++);
        }

        while (i < points.Length) {
            int currDist = points[i][0] * points[i][0] + points[i][1] * points[i][1];
            int j = heap.Peek ();
            int maxDist = points[j][0] * points[j][0] + points[j][1] * points[j][1];

            if (currDist < maxDist) {
                heap.Poll ();
                heap.Insert (i);
            }

            i++;
        }

        int index = K - 1;
        while (heap.Peek () != -1) {
            result[index--] = points[heap.Poll ()];
        }

        return result;
    }

    // public static void Main (string[] args) {
    //     var result = KClosest (new int[][] {
    //         new int[] { 1, 3 },
    //             new int[] {-2, 2 },
    //             new int[] { 2, -2 },
    //     }, 2);

    //     Console.WriteLine (result);
    // }
}
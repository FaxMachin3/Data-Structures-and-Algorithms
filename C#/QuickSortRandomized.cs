using System;

class QuickSortRandomized {
    public static void Swap(int[] a, int i, int j){
        int temp = a[i];
        a[i] = a[j];
        a[j] = temp;
    }
    public static int Partition(int[] a, int l, int h){
        int randomPivot = new Random().Next(l, h + 1);
        int i = l;
        int j = h;

        while(i < j){
            while(a[i] < a[randomPivot])    i++;
            while(a[j] > a[randomPivot])    j--;
            if(i < j)   Swap(a, i, j);
        }

        Swap(a, i, randomPivot);

        return i;
    }
    public static void QuickSort(int[] a, int l, int h){
        if(l < h){
            int j = Partition(a, l, h);
            QuickSort(a, l, j - 1);
            QuickSort(a, j + 1, h);
        }
    }
    // public static void Main(string[] args){
    //     int[] arr = {67, 12, 95, 56, 85, 1, 100, 23, 60, 9};

    //     int low = 0;
    //     int high = arr.Length - 1;
    //     Console.WriteLine(string.Join(" ",arr));
    //     QuickSort(arr, low, high);
    //     Console.WriteLine(string.Join(" ",arr));
    // }
}
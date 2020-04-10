using System;
namespace MergeSortDemo {
   class Example {
      static public void merge(int[] arr, int left, int mid, int right) {
         int i, j, k;
         int n1 = mid - left + 1;
         int n2 = right - mid;
        //  Console.WriteLine(left+" "+mid+" "+right);
        //  Console.WriteLine(n1+" "+n2);
         int[] L = new int[n1];
         int[] R = new int[n2];
         for (i = 0; i < n1; i++) {
            L[i] = arr[left + i];
         }
         for (j = 0; j < n2; j++) {
            R[j] = arr[mid + 1 + j];
         }
        //  Console.WriteLine(string.Join(", ",L));
        //  Console.WriteLine(string.Join(", ",R));
         i = 0;
         j = 0;
         k = left;
         while (i < n1 && j < n2) {
            if (L[i] <= R[j]) {
               arr[k] = L[i];
               i++;
            } else {
               arr[k] = R[j];
               j++;
            }
            k++;
         }
         while (i < n1) {
            arr[k] = L[i];
            i++;
            k++;
         }
         while (j < n2) {
            arr[k] = R[j];
            j++;
            k++;
         }
      }
      static public void mergeSort(int[] arr, int left, int right) {
         if (left < right) {
            int mid = (left + right) / 2;
            mergeSort(arr, left, mid);
            mergeSort(arr, mid + 1, right);
            merge(arr, left, mid, right);
         }
      }
      // static void Main(string[] args) {
      //    int[] arr = {76, 3, 89, 23, 1, 55, 78, 99, 12, 65, 100, 3, 2};
      //    int n = arr.Length - 1, i;
      //    Console.WriteLine("Merge Sort");
      //    Console.Write("Initial array is: ");
      //    for (i = 0; i < n; i++) {
      //       Console.Write(arr[i] + " ");
      //    }
      //    Console.WriteLine();
      //    mergeSort(arr, 0, n);
      //    Console.Write("\nSorted Array is: ");
      //    for (i = 0; i < n; i++) {
      //       Console.Write(arr[i] + " ");
      //    }
      // }
   }
}
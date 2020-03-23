using System;
namespace QuickSortDemo {
   class Example {
      static public int Partition(int[] arr, int low, int high) {
         
        int pivot = arr[high];  
          
        // index of smaller element 
        int i = (low - 1);  
        for (int j = low; j < high; j++) 
        { 
            // If current element is smaller  
            // than the pivot 
            if (arr[j] < pivot) 
            { 
                i++; 
  
                // swap arr[i] and arr[j] 
                int temp = arr[i]; 
                arr[i] = arr[j]; 
                arr[j] = temp; 
            } 
        } 
  
        // swap arr[i+1] and arr[high] (or pivot) 
        int temp1 = arr[i+1]; 
        arr[i+1] = arr[high]; 
        arr[high] = temp1; 
  
        return i+1; 
      }
      static public void quickSort(int[] arr, int left, int right) {
         if (left < right) {
            int pivot = Partition(arr, left, right);
            quickSort(arr, left, pivot - 1);
            quickSort(arr, pivot + 1, right);
         }
      }
      // static void Main(string[] args) {
      //    int[] arr = {67, 12, 95, 56, 85, 1, 100, 23, 60, 9, 123, 3, 3}; 
      //    int n = arr.Length, i;
      //    Console.WriteLine("Quick Sort");
      //    Console.Write("Initial array is: ");   
      //    for (i = 0; i < n; i++) {
      //       Console.Write(arr[i] + " ");
      //    }
      //    quickSort(arr, 0, arr.Length - 1);
      //    Console.Write("\nSorted Array is: ");   
      //    for (i = 0; i < n; i++) {
      //       Console.Write(arr[i] + " ");
      //    }
      // }
   }
}
using System;
using System.Collections.Generic;
class MinHeap{
    List<int> heapList;
    public MinHeap(){
        heapList = new List<int>();
    }
    private int GetParentIndex(int index){
        return (index - 1) / 2;
    }
    private int GetLeftChildIndex(int index){
        return (index * 2) + 1;
    }
    private int GetRightChildIndex(int index){
        return (index * 2) + 2;
    }
    private int GetParent(int index){
        return (index <= 0)? int.MinValue : heapList[GetParentIndex(index)];
    }
    private int GetLeftChild(int index){
        return (GetLeftChildIndex(index) > LastIndex())? int.MaxValue : heapList[GetLeftChildIndex(index)];
    }
    private int GetRightChild(int index){
        return (GetRightChildIndex(index) > LastIndex())? int.MaxValue : heapList[GetRightChildIndex(index)];
    }
    private int LastIndex(){
        return heapList.Count - 1;
    }
    private int RemoveLast(){
        int value = heapList[LastIndex()];
        heapList.RemoveAt(LastIndex());
        return value;
    }
    private void Swap(int IndexOne, int IndexTwo){
            int temp = heapList[IndexOne];
            heapList[IndexOne] = heapList[IndexTwo];
            heapList[IndexTwo] = temp;
    }
    private void BubbleUp(int index){
        while(GetParent(index) > heapList[index]){
            Swap(GetParentIndex(index), index);
            index = GetParentIndex(index);
        }
    }
    private void BubbleDown(int index){
        while(GetLeftChild(index) < heapList[index]){
            int smallChildIndex = GetLeftChildIndex(index);
            if(smallChildIndex > LastIndex()) break;
            if(heapList[smallChildIndex] > GetRightChild(index))   smallChildIndex = GetRightChildIndex(index);
            Swap(index, smallChildIndex);
            index = smallChildIndex;
        }
    }
    public int Peek(){
        if(LastIndex() > 0)
            return heapList[0];
        return int.MaxValue;
    }
    public void Insert(int ele){
        heapList.Add(ele);
        BubbleUp(LastIndex());
    }
    public int Poll(){
        if(heapList.Count == 0) return -1;
        else{
            Swap(0, LastIndex());
            int value = RemoveLast();
            if(heapList.Count > 0)  BubbleDown(0);
            return value;
        }
    }
    public int Remove(int ele){
        if(heapList.Count == 0) return -1;
        else{
            int index = heapList.IndexOf(ele);
            Swap(index, LastIndex());
            int value = RemoveLast();
            if(heapList.Count > 0)  BubbleDown(index);
            return value;
        }
    }
}
class Sol{
    // static void Main(string[] args){
    //     int[] arr = {50,60,34,21,6,78,23,67,34,67,89,1};
    //     MinHeap newHeap = new MinHeap();
    //     foreach(var ele in arr){
    //         newHeap.Insert(ele);
    //     }
    //     Console.WriteLine(newHeap.Poll());
    //     Console.WriteLine(newHeap.Poll());
    //     Console.WriteLine(newHeap.Poll());
    //     Console.WriteLine(newHeap.Poll());
    //     Console.WriteLine(newHeap.Poll());
    //     Console.WriteLine(newHeap.Poll());
    //     Console.WriteLine(newHeap.Poll());
    //     Console.WriteLine(newHeap.Poll());
    //     Console.WriteLine(newHeap.Poll());
    //     Console.WriteLine(newHeap.Poll());
    //     Console.WriteLine(newHeap.Poll());
    //     Console.WriteLine(newHeap.Poll());
    //     Console.WriteLine(newHeap.Poll());
    //     Console.WriteLine(newHeap.Poll());
    //     Console.WriteLine(newHeap.Poll());
    //     Console.WriteLine(newHeap.Poll());
    //     Console.WriteLine(newHeap.Poll());
    //     Console.WriteLine(newHeap.Poll());
    //     Console.WriteLine(newHeap.Poll());
    // }
}
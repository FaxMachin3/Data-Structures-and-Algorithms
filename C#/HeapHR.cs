using System;
using System.Collections.Generic;
using System.IO;
class HHR {
    static List<int> heapList = new List<int>();
    static Dictionary<int, List<int>> heapIndex = new Dictionary<int, List<int>>();
    static int GetParentIndex(int index){
        return (index - 1) / 2;
    }
    static int GetLeftChildIndex(int index){
        return (index * 2) + 1;
    }
    static int GetRightChildIndex(int index){
        return (index * 2) + 2;
    }
    static int GetParent(int index){
        return (index <= 0)? int.MinValue : heapList[GetParentIndex(index)];
    }
    static int GetLeftChild(int index){
        return (GetLeftChildIndex(index) > LastIndex())? int.MaxValue : heapList[GetLeftChildIndex(index)];
    }
    static int GetRightChild(int index){
        return (GetRightChildIndex(index) > LastIndex())? int.MaxValue : heapList[GetRightChildIndex(index)];
    }
    static int LastIndex(){
        return heapList.Count - 1;
    }
    static int RemoveLast(){
        int value = heapList[LastIndex()];
        heapList.RemoveAt(LastIndex());
        return value;
    }
    static void Swap(int IndexOne, int IndexTwo){
            int temp = heapList[IndexOne];
            heapList[IndexOne] = heapList[IndexTwo];
            heapList[IndexTwo] = temp;
    }
    static void BubbleUp(int index){
        while(GetParent(index) > heapList[index]){
            Swap(GetParentIndex(index), index);
            index = GetParentIndex(index);
        }
    }
    static void BubbleDown(int index){
        while(GetLeftChild(index) != int.MaxValue){
            int smallChildIndex = GetLeftChildIndex(index);
            if(smallChildIndex > LastIndex()) break;
            if(heapList[smallChildIndex] > GetRightChild(index))   smallChildIndex = GetRightChildIndex(index);
            Swap(index, smallChildIndex);
            index = smallChildIndex;
        }
    }
    static int Peek(){
        if(LastIndex() >= 0)
            return heapList[0];
        return int.MaxValue;
    }
    static void Insert(int ele){
        heapList.Add(ele);
        BubbleUp(LastIndex());
    }
    static int Remove(int ele){
        if(heapList.Count == 0) return -1;
        else{
            int index = heapList.IndexOf(ele);
            if(index == -1) return index;
            Swap(index, LastIndex());
            int value = RemoveLast();
            if(heapList.Count > 0 && index <= LastIndex())  BubbleDown(index);
            return value;
        }
    }
    static int RemoveMin(){
        if(heapList.Count == 0) return -1;
        else{
            Swap(0, LastIndex());
            int value = RemoveLast();
            if(heapList.Count > 0)  BubbleDown(0);
            return value;
        }
    }
    // static void Main(String[] args) {
    //     string[] arr = {
    //         "1 286789035",
    //         "1 255653921",
    //         "1 274310529",
    //         "1 494521015",
    //         "3",
    //         "2 255653921",
    //         "2 286789035",
    //         "3",
    //         "1 236295092",
    //         "1 254828111",
    //         "2 254828111",
    //         "1 465995753",
    //         "1 85886315",
    //         "1 7959587",
    //         "1 20842598",
    //         "2 7959587",
    //         "3",
    //         "1 -51159108",
    //         "3",
    //         "2 -51159108",
    //         "3",
    //         "1 789534713",
    //     };
    //     foreach(var ele in arr){
    //         string[] temp = ele.Split(' ');
    //         int a = Convert.ToInt32(temp[0]);
    //         if(a == 1)  Insert(Convert.ToInt32(temp[1]));
    //         else if(a == 2) Remove(Convert.ToInt32(temp[1]));
    //         else    Console.WriteLine(Peek());
    //     }
    // }
}


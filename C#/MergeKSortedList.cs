using System;
using System.Collections;
using System.Collections.Generic;
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode (int x) { val = x; }
    public ListNode () { }
}
public class MH {
    ListNode[] minHeap;
    int lastIndex;
    public MH (int size) {
        minHeap = new ListNode[size];
        lastIndex = -1;
    }
    public int GetLastIndex () {
        return lastIndex;
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
    public ListNode GetParent (int i) {
        int index = (i - 1) / 2;
        if (index >= 0) {
            return minHeap[index];
        }
        return null;
    }
    public ListNode GetLeftChild (int i) {
        int index = (i * 2) + 1;
        if (index <= lastIndex) {
            return minHeap[index];
        }
        return null;
    }
    public ListNode GetRightChild (int i) {
        int index = (i * 2) + 2;
        if (index <= lastIndex) {
            return minHeap[index];
        }
        return null;
    }
    public ListNode Poll () {
        if (lastIndex < 0) return null;
        ListNode temp = minHeap[0];
        minHeap[0] = minHeap[lastIndex];
        minHeap[lastIndex] = null;
        lastIndex--;
        BubbleDown (0);
        return temp;
    }
    public ListNode Peek () {
        if (lastIndex >= 0) return minHeap[0];
        return null;
    }
    public void Insert (ListNode ele) {
        if (ele == null) return;
        minHeap[++lastIndex] = ele;
        BubbleUp (lastIndex);
    }
    public void BubbleUp (int index) {
        while (GetParent (index) != null && GetParent (index).val > minHeap[index].val) {
            Swap (GetParentIndex (index), index);
            index = GetParentIndex (index);
        }
    }
    public void BubbleDown (int index) {
        while (GetLeftChildIndex (index) != -1) {
            int smallChildIndex = GetLeftChildIndex (index);
            if (GetRightChild (index) != null && minHeap[smallChildIndex].val > GetRightChild (index).val) smallChildIndex = GetRightChildIndex (index);
            if (minHeap[smallChildIndex].val > minHeap[index].val) break;
            Swap (index, smallChildIndex);
            index = smallChildIndex;
        }
    }
    public void Swap (int i, int j) {
        ListNode temp = minHeap[i];
        minHeap[i] = minHeap[j];
        minHeap[j] = temp;
    }
}

public class MKSL {
    // public static void Main (string[] args) {
    //     ListNode result = new ListNode ();
    //     ListNode one = new ListNode (1);
    //     ListNode two = new ListNode (1);
    //     ListNode three = new ListNode (2);
    //     // ListNode four = new ListNode (-8);
    //     // ListNode six = new ListNode (-9);
    //     // ListNode seven = new ListNode (-3);

    //     one.next = new ListNode (4);
    //     one.next.next = new ListNode (5);
    //     // one.next.next.next = new ListNode (-3);
    //     // one.next.next.next.next = new ListNode (-1);
    //     // one.next.next.next.next.next = new ListNode (-1);
    //     // one.next.next.next.next.next.next = new ListNode (0);
    //     two.next = new ListNode (3);
    //     two.next.next = new ListNode (4);
    //     // six.next.next.next = new ListNode (-4);
    //     // six.next.next.next.next = new ListNode (-2);
    //     // six.next.next.next.next.next = new ListNode (2);
    //     // six.next.next.next.next.next.next = new ListNode (3);
    //     three.next = new ListNode (6);
    //     // seven.next.next = new ListNode (-2);
    //     // seven.next.next.next = new ListNode (-1);
    //     // seven.next.next.next.next = new ListNode (0);
    //     ListNode[] lists = new ListNode[] { one, two, three };
    //     MH heap = new MH (lists.Length);
    //     for (int i = 0; i < lists.Length; i++) {
    //         heap.Insert (lists[i]);
    //     }
    //     ListNode head = result;
    //     while (heap.GetLastIndex () > -1) {
    //         ListNode polled = heap.Poll ();
    //         if (polled.val == int.MaxValue) break;
    //         if (polled.next != null) heap.Insert (polled.next);
    //         else heap.Insert (new ListNode (int.MaxValue));
    //         Console.WriteLine (polled.val);
    //         head = polled;
    //         head = head.next;
    //     }
    //     // return result;
    // }
}
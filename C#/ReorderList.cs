using System;
public class RL {
    public static void ReorderList (ListNode head) {
        ListNode tail = ReverseSecondHalf (head);

        while (head != null && tail != null) {
            ListNode temp1 = head.next;
            head.next = tail;
            ListNode temp2 = tail.next;
            tail.next = temp1;
            head = temp1;
            tail = temp2;
        }

        if(head != null) head.next = null;
    }

    private static ListNode ReverseSecondHalf (ListNode node) {
        ListNode slow = node;
        ListNode fast = node;

        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;
        }

        return Reverse (slow);
    }

    private static ListNode Reverse (ListNode node) {
        ListNode prev = null;
        ListNode curr = node;

        while (curr != null) {
            ListNode temp = curr.next;
            curr.next = prev;
            prev = curr;
            curr = temp;
        }

        return prev;
    }

    // public static void Main (string[] args) {
    //     ListNode obj = new ListNode (1);
    //     obj.next = new ListNode (2);
    //     obj.next.next = new ListNode (3);
    //     obj.next.next.next = new ListNode (4);
    //     obj.next.next.next.next = new ListNode (5);
    //     obj.next.next.next.next.next = new ListNode (6);
    //     // obj.next.next.next.next.next.next = new ListNode (7);

    //     ReorderList (obj);

    //     var temp = obj;
    //     while (temp != null) {
    //         Console.Write (temp.val + " ");
    //         temp = temp.next;
    //     }
    //     Console.WriteLine ();
    // }
}
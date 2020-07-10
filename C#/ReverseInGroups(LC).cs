using System;
using System.Collections;
using System.Collections.Generic;
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class RIG {
    public static ListNode ReverseKGroup (ListNode head, int k) {
        if (head == null)
            return null;
        int count = CountNodes (head);

        int loop = count / k;

        ListNode prev = null;
        ListNode firstNodeOfGroup = head;
        while (loop-- > 0) {
            ListNode curr = firstNodeOfGroup;
            int insideLoop = k;
            ListNode cnext = curr.next;
            while (insideLoop-- > 0) {
                curr.next = prev;
                prev = curr;
                curr = cnext;
                cnext = curr.next;
            }
            firstNodeOfGroup.next = curr;
            firstNodeOfGroup = curr;
        }

        return prev;
    }

    private static int CountNodes (ListNode head) {
        int c = 0;
        while (head != null) {
            c++;
            head = head.next;
        }
        return c;
    }
    // public static void Main (string[] args) {
    //     var input = new ListNode (1);
    //     input.next = new ListNode (2);
    //     input.next.next = new ListNode (3);
    //     input.next.next.next = new ListNode (4);
    //     input.next.next.next.next = new ListNode (5);

    //     var result = ReverseKGroup (input, 2);

    //     var temp = result;
    //     var temp2 = input;

    //     while (temp != null) {
    //         Console.Write (temp.val + "-->");
    //         temp = temp.next;
    //     }
    //     Console.WriteLine ();
    //     while (temp2 != null) {
    //         Console.Write (temp2.val + "-->");
    //         temp2 = temp2.next;
    //     }
    //     Console.WriteLine ();
    // }
}
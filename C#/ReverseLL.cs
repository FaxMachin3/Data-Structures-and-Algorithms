using System;
public class RLL {
    public static ListNode ReverseList (ListNode head) {
        if (head == null)
            return null;

        ListNode prev = null;
        ListNode curr = head;
        ListNode cnext = head.next;

        while (curr != null && curr.next != null) {
            curr.next = prev;
            prev = curr;
            curr = cnext;
            cnext = curr.next;
        }

        curr.next = prev;
        head = curr;

        return head;
    }
    // public static void Main (string[] args) {
    //     var input = new ListNode (1);
    //     input.next = new ListNode (2);
    //     input.next.next = new ListNode (3);
    //     input.next.next.next = new ListNode (4);
    //     input.next.next.next.next = new ListNode (5);

    //     var result = ReverseList (input);

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
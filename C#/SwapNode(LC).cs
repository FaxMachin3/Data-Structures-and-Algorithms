using System;

public class SNLC {
    public static ListNode SwapPairs (ListNode head) {
        var newNode = new ListNode (-1);
        newNode.next = head;
        var temp = newNode;

        while (head != null && head.next != null) {
            var first = head;
            var second = head.next;

            temp.next = second;
            first.next = second.next;
            second.next = first;

            temp = first;
            head = first.next;
        }

        return newNode.next;
    }
    // public static void Main (string[] args) {
    //     var input = new ListNode (1);
    //     input.next = new ListNode (2);
    //     input.next.next = new ListNode (3);
    //     input.next.next.next = new ListNode (4);
    //     var result = SwapPairs (input);

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
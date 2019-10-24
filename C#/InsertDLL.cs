using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class IDLL {

    class DoublyLinkedListNode {
        public int data;
        public DoublyLinkedListNode next;
        public DoublyLinkedListNode prev;

        public DoublyLinkedListNode(int nodeData) {
            this.data = nodeData;
            this.next = null;
            this.prev = null;
        }
    }

    class DoublyLinkedList {
        public DoublyLinkedListNode head;
        public DoublyLinkedListNode tail;

        public DoublyLinkedList() {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData) {
            DoublyLinkedListNode node = new DoublyLinkedListNode(nodeData);

            if (this.head == null) {
                this.head = node;
            } else {
                this.tail.next = node;
                node.prev = this.tail;
            }

            this.tail = node;
        }
    }

    static void PrintDoublyLinkedList(DoublyLinkedListNode node) {
        while (node != null) {
            Console.Write(node.data);

            node = node.next;

            if (node != null) {
                Console.Write(" ");
            }
        }
    }

    // Complete the sortedInsert function below.

    /*
     * For your reference:
     *
     * DoublyLinkedListNode {
     *     int data;
     *     DoublyLinkedListNode next;
     *     DoublyLinkedListNode prev;
     * }
     *
     */
     static DoublyLinkedListNode reverse(DoublyLinkedListNode head) {
        DoublyLinkedListNode currNode = head;
        DoublyLinkedListNode prevNode = null;
        DoublyLinkedListNode nextNode = currNode.next;

        return reverseUtil(head, prevNode, currNode, nextNode);
    }

    static DoublyLinkedListNode reverseUtil(DoublyLinkedListNode head, DoublyLinkedListNode prevNode, DoublyLinkedListNode currNode, DoublyLinkedListNode nextNode){
        if(currNode.next == null){
            currNode.next = prevNode;
            currNode.prev = null;
            head = currNode;
            return head;
        }

        currNode.next = prevNode;
        currNode.prev = nextNode;
        prevNode = currNode;
        currNode = nextNode;
        nextNode = currNode.next;

        return reverseUtil(head, prevNode, currNode, nextNode);
    }
    static DoublyLinkedListNode sortedInsert(DoublyLinkedListNode head, int data) {
        DoublyLinkedListNode newNode = new DoublyLinkedListNode(data);
        DoublyLinkedListNode nextNode = head;

        while(nextNode.next != null && nextNode.data < data){
            nextNode = nextNode.next;
        }

        DoublyLinkedListNode prevNode = nextNode.prev;
        if(prevNode == null){
            head = newNode;
            newNode.next = nextNode;
            nextNode.prev = newNode;
        }
        else if(nextNode.data >= data){
            newNode.next = nextNode;
            newNode.prev = prevNode;
            nextNode.prev = newNode;
            prevNode.next = newNode;
        }
        else{
            newNode.next = null;
            newNode.prev = nextNode;
            nextNode.next = newNode;
        }
    
        return head;
    }

    // static void Main(string[] args) {
    //     // DoublyLinkedList llist = new DoublyLinkedList();

    //     // int llistCount = 26;
    //     // int[] listItem = new int[] {
    //     //     7,
    //     //     7,
    //     //     8,
    //     //     28,
    //     //     32,
    //     //     33,
    //     //     39,
    //     //     48,
    //     //     48,
    //     //     53,
    //     //     55,
    //     //     62,
    //     //     64,
    //     //     66,
    //     //     68,
    //     //     68,
    //     //     76,
    //     //     81,
    //     //     87,
    //     //     88,
    //     //     90,
    //     //     91,
    //     //     92,
    //     //     94,
    //     //     95,
    //     //     97
    //     // };

    //     // for (int i = 0; i < llistCount; i++) {
    //     //     llist.InsertNode(listItem[i]);
    //     // }

    //     // int data = 94;

    //     // DoublyLinkedListNode llist1 = sortedInsert(llist.head, data);

    //     // PrintDoublyLinkedList(llist1);
    //     // Console.WriteLine();
    //     DoublyLinkedList ll = new DoublyLinkedList();
    //     int[] temp = new int[] {1,2,3,4};
    //     foreach(var ele in temp){
    //         ll.InsertNode(ele);
    //     }
    //     DoublyLinkedListNode result = reverse(ll.head);
    //     PrintDoublyLinkedList(result);
    //     Console.WriteLine();
    // }
}

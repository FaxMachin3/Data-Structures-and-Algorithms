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

class Node{
    public int data;
    public Node next;
    public Node(int d){
        this.data = d;
        next = null;
    }
}
class LinkedList{
    Node head;
    public void InsertAtEnd(int d){
        if(head == null){
            head = new Node(d);
            head.next = null;
        }
        else{
            Node newNode = new Node(d);
            Node current = head;
            while(current.next != null)
                current = current.next;
            current.next = newNode;
        }
    }
    public void InsertAtBeg(int d){
        if(head == null){
            head = new Node(d);
            head.next = null;
        }
        else{
            Node lastHead = head;
            head = new Node(d);
            head.next = lastHead;
        }
    }
    public void PrintList(){
        Node current = head;
        while(current != null){
            Console.WriteLine(current.data);
            current = current.next;
        }
    }

       // static void Main(string[] args) {
    //     LinkedList newList = new LinkedList();
    //     newList.InsertAtBeg(2);
    //     newList.InsertAtBeg(1);
    //     newList.InsertAtBeg(99);
    //     newList.InsertAtBeg(231);
    //     newList.InsertAtBeg(22);
    //     newList.PrintList();
    // }
}
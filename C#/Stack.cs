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

class Stack
{
    int[] stack;
    int max;
    int top;
    public Stack(int len){
        stack = new int[len];
        top = -1;
        max = len;
    }
    public bool IsEmpty(){
        if(top == -1)
            return true;
        return false;
    }
    public bool IsFull(){
        if(top == max)
            return true;
        return false;
    }
    public void Push(int ele){
        if(IsFull())
            Console.WriteLine("Stack full");
        else
            stack[++top] = ele;
    }
    public int Pop(){
        if(IsEmpty()){
            Console.WriteLine("Stack is empty");
            return -1;
        }
        else
            return stack[top--];
    }
    public int Peek(){
        if(IsEmpty()){
            Console.WriteLine("Stack is empty");
            return -1;
        }
        else
            return stack[top];
    }
}
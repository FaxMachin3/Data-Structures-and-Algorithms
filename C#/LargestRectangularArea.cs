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



class Solution {

    class Stack{
        long[] stack;
        long top = -1;
        long MAX;
        public Stack(int length){
            stack = new long[length];
            MAX = length;
        }
        public bool isEmpty(){
            if(top == -1)
                return true;
            return false;
        }
        public bool isFull(){
            if(top == MAX)
                return true;
            return false;
        }
        public void push(long data){
            stack[++top] = data;
        }
        public long pop(){
            if(top == -1)
                return -1;
            return stack[top--];
        }
        public long peek(){
            if(top == -1)
                return -1;
            return stack[top];
        }
        public void PrintStack(){
            foreach(var ele in stack){
                Console.Write(ele+" ");
            }
            Console.WriteLine();
        }
    }

    // Complete the largestRectangle function below.
    static long largestRectangle(int[] h) {
        long maxArea = 0;
        Stack positionStack = new Stack(h.Length);
        long i = 0;
        while(i < h.Length){
            // Console.WriteLine(i);
            // positionStack.PrintStack();
            if(positionStack.isEmpty()){
                // Console.WriteLine(h[i]);
                positionStack.push(i++);
            }
            else{
                if(h[i] >= h[positionStack.peek()]){
                    positionStack.push(i++);
                }
                else{
                    long topEle = h[positionStack.pop()];
                    long peek = positionStack.peek();
                    long tempArea = topEle * ( positionStack.isEmpty() ? i : (i - peek - 1) );
                    if(tempArea > maxArea)
                        maxArea = tempArea;
                }
            }
        }
        while(!positionStack.isEmpty()){
            long topEle = positionStack.pop();
                    long tempArea = h[topEle] * ( positionStack.isEmpty() ? i : (i - positionStack.peek() - 1) );
                    // Console.WriteLine(tempArea);
                    if(tempArea > maxArea)
                        maxArea = tempArea;
        }
        return maxArea;
    }

    // static void Main(string[] args) {

    //     int[] h = new int[] {2, 3, 1, 6, 6, 4, 2};
    //     long result = largestRectangle(h);
    //     Console.WriteLine(result);
    // }
}

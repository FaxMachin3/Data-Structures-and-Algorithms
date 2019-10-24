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

class Queue{
    int[] queue;
    int front, rear, max;
    public Queue(int n){
        queue = new int[n];
        front = 0;
        rear = -1;
        max = n;
    }
    public bool IsEmpty(){
        if(front == rear + 1)
            return true;
        return false;
    }
    public bool IsFull(){
        if(rear == max - 1)
            return true;
        return false;
    }
    public void Enqueue(int data){
        if(IsFull()){
            Console.WriteLine("Full!");
            return;
        }
        else
            queue[++rear] = data;
    }
    public int Dequeue(){
        if(IsEmpty()){
            Console.WriteLine("Empty!");
            return -1;
        }
        else
            return queue[front++];
    }
    public int Peek(){
        if(IsEmpty()){
            Console.WriteLine("Empty!");
            return -1;
        }
        else
            return queue[front];
    }
    public void Print(){
        for(int i = front; i <= rear; i++)
            Console.Write(queue[i]+" ");
        Console.WriteLine();
    }
}
class Point{
    public int x;
    public int y;
    public Point(int x, int y){
        this.x = x;
        this.y = y;
    }
}
class Castle {

    // Complete the minimumMoves function below.
    static int minimumMoves(string[] grid, int startX, int startY, int goalX, int goalY){
        int m = grid.Length;
        int n = grid[0].Length;
        Queue xQueue = new Queue(m * n);
        Queue yQueue = new Queue(m * n);
        bool[,] visited = new bool[m , n];
        int[,] dist = new int[m , n];

        for(int i = 0; i < m; i++){
            for(int j = 0; j < n; j++){
                if(grid[i][j] == 'X')
                    visited[i,j] = true;
            }
        }

        xQueue.Enqueue(startX);
        yQueue.Enqueue(startY);
        visited[startX,startY] = true;
        dist[startX,startY] = 0;

        while(!xQueue.IsEmpty()){
            int x = xQueue.Dequeue();
            int y = yQueue.Dequeue();
            // !UP
            for(int i = x - 1; i >= 0; i--){
                if(i == goalX && y == goalY)
                    return dist[x,y] + 1;
                if(!visited[i,y]){
                    xQueue.Enqueue(i);
                    yQueue.Enqueue(y);
                    visited[i,y] = true;
                    dist[i,y] = dist[x,y] + 1;
                } else break;
            }
            // !DOWN
            for(int i = x + 1; i < m; i++){
                if(i == goalX && y == goalY)
                    return dist[x,y] + 1;
                if(!visited[i,y]){
                    xQueue.Enqueue(i);
                    yQueue.Enqueue(y);
                    visited[i,y] = true;
                    dist[i,y] = dist[x,y] + 1;
                } else break;
            }
            // !LEFT
            for(int i = y - 1; i >= 0; i--){
                if(x == goalX && i == goalY)
                    return dist[x,y] + 1;
                if(!visited[x,i]){
                    xQueue.Enqueue(x);
                    yQueue.Enqueue(i);
                    visited[x,i] = true;
                    dist[x,i] = dist[x,y] + 1;
                } else break;
            }
            // !RIGHT
            for(int i = y + 1; i < n; i++){
                if(x == goalX && i == goalY)
                    return dist[x,y] + 1;
                if(!visited[x,i]){
                    xQueue.Enqueue(x);
                    yQueue.Enqueue(i);
                    visited[x,i] = true;
                    dist[x,i] = dist[x,y] + 1;
                } else break;
            }
        }
        return -1;
    }

    // static void Main(string[] args) {
    //     string[] grid = new string[]{
    //         "...XX..",
    //         ".X.X.X.",
    //         ".X.X...",
    //         "....X.X",
    //         "..X.X..",
    //         "X.X...X",
    //         "..X...."
    //         // "...",
    //         // ".X.",
    //         // ".X."
    //     };

    //     int startX = Convert.ToInt32(6);

    //     int startY = Convert.ToInt32(0);

    //     int goalX = Convert.ToInt32(0);

    //     int goalY = Convert.ToInt32(6);

    //     int result = minimumMoves(grid, startX, startY, goalX, goalY);

    //     Console.WriteLine(result);
    // }
}

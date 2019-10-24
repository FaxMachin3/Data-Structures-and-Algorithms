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
class Point1{
    public int x;
    public int y;
}
class CC {
    // Complete the maxRegion function below.
    static int maxRegion(int[][] grid) {
        Stack<Point1> stack = new Stack<Point1>();
        bool[,] visited = new bool[grid.Length, grid[0].Length];
        int largestRegion = -1;
        int tempCount = 1;

        for(int i = 0; i < grid.Length; i++){
            for(int j = 0; j < grid[0].Length; j++){
                if(grid[i][j] == 1){
                    stack.Push(null);
                    stack.Push(new Point1() {x=i,y=j});
                }
            }
        }

        int[] dr = {-1,1,0,0,  -1,1,-1,1};
        int[] dc = {0,0,-1,1,  -1,1,1,-1};

        while(stack.Count > 0){
            Point1 p = stack.Pop();
            if(p == null){
                largestRegion = Math.Max(tempCount, largestRegion);
                tempCount = 1;
                continue;
            }
            visited[p.x,p.y] = true;
            for(int i = 0; i < dr.Length; i++){
                int newX = p.x + dr[i];
                int newY = p.y + dc[i];

                if(newX < 0 || newY < 0)    continue;
                if(newX >= grid.Length || newY >= grid[0].Length)  continue;
                if(visited[newX, newY]) continue;
                if(grid[newX][newY] == 0)   continue;

                visited[newX, newY] = true;
                stack.Push(new Point1() {x=newX,y=newY});
                tempCount++;
            }
        }

        return largestRegion;
    }

    // static void Main(string[] args) {
    //     int res = maxRegion(new int[][]{
    //         new int[]{0,0,1,1},
    //         new int[]{0,1,1,0},
    //         new int[]{0,0,1,0},
    //         new int[]{1,0,0,0},
    //     });

    //     Console.WriteLine(res);
    // }
}

using System;
using System.Collections;
using System.Collections.Generic;

public class Asteroid {
    public static int[] AsteroidCollision(int[] asteroids) {
        if(asteroids.Length <= 1)   return asteroids;
        
        Stack<int> s = new Stack<int>();
        s.Push(asteroids[0]);
        
        for(int i = 1; i < asteroids.Length; i++){
            if(s.Count > 0 && s.Peek() < 0)    s.Push(asteroids[i]);
            else{
                int flag = 0;
                while(s.Count > 0 && s.Peek() > 0 && asteroids[i] < 0){
                    int peek = s.Peek();
                    int og = asteroids[i];
                    int current = Math.Abs(og);
                    // Console.WriteLine(peek +" " +og +" " +current);

                    if (peek == current) {
                        flag = 1;
                        break;
                    }
                    else if (peek < current) { s.Pop(); }
                    else if (peek > current) {
                        flag = 2;
                        break;
                        }
                    // Console.WriteLine(s.Peek());
                }
                if(flag == 0)   s.Push(asteroids[i]);
                else if(flag == 1)  { if(s.Count > 0)  s.Pop(); }
                else if(flag == 2)  continue;
                // Console.WriteLine(string.Join("->",s.ToArray()));
            }
        }
        
        int[] result = new int[s.Count];
        
        for(int i = result.Length - 1; i >= 0; i--){
            result[i] = s.Pop();
        }
        
        return result;
    }

    public static void Main(String[] args){
        Console.WriteLine(string.Join(" ",AsteroidCollision(new int[]{1,-2,-2,-2})));
    }
}
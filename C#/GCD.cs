using System;
using System.Linq;
class test{
    static int GCD(int a, int b){
        if(b == 0)
            return a;
        return GCD(b, a % b);
    }
    // public static void Main(string[] args){
    //         int[] inp = {48,12,20};
    //         int temp = inp[0];
    //         for(int i = 1; i < inp.Length; i++){
    //             temp = GCD(inp[i], temp);
    //         }
    //         int min = inp.Min();
    //         // Console.WriteLine(min);
    //         // Console.WriteLine(inp.Min(ele => {
    //         //     if(ele == min
    //         //          return int.MaxValue;
    //         //     else return ele;
    //         //     }));
    //         Console.WriteLine(temp);
    // }
}
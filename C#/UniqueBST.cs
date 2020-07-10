using System;
public class UBST {
    public static int NumTrees(int n) {
        return NumTreesUtil(1, n);
    }
    
    private static int NumTreesUtil(int start, int end) {
        if(start > end)
            return 0;
        
        if(start < 1)
            return 0;
        
        if(end - start + 1 == 1)
            return 1;
        
        if(end - start + 1 == 2)
            return 2;
        
        int count = 0;
        
        for(int i = start; i <= end; i++) {
            int left = NumTreesUtil(i - 1, end);
            int right = NumTreesUtil(i + 1, end);
            
            count += left + right;
        }
        
        return count;
    }
    // public static void Main(string[] args) {
    //     Console.WriteLine(NumTrees(3));
    // }
}
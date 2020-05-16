using System;
public class NextGreater {
    public static int NextGreaterElement (int n) {
        if (n < 10) return n;
        char[] result = n.ToString ().ToCharArray ();
        int len = result.Length;

        int i;
        for (i = len - 1; i > 0; i--) {
            if (result[i - 1] < result[i]) break;
        }

        if (i == 0) return -1;

        char temp = result[i - 1];
        result[i - 1] = result[len - 1];
        result[len - 1] = temp;

        int l = i + 1;
        int h = len - 1;
        while (l < h) {
            temp = result[l];
            result[l] = result[h];
            result[h] = temp;
            l++;
            h--;
        }

        return Convert.ToInt32 (new string (result));
    }
    // public static void Main(string[] args){
    //     Console.WriteLine(NextGreaterElement(12));
    // }
}
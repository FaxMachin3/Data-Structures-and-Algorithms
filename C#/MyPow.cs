using System;
public class MP {
    public static double MyPow (double x, int n) {
        if (n == 0)
            return 1;

        double res = MyPow (x, n / 2);

        if (n % 2 == 0)
            return res * res;
        else {
            if (n > 0)
                return x * res * res;
            else
                return (res * res) / x;
        }
    }
    // public static void Main(string[] args) {
    //     Console.WriteLine(MyPow(2,-7));
    //     Console.WriteLine('1' - '0');
    // }
}
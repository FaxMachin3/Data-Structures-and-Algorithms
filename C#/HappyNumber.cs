using System;
class HappyNumber {
    static bool happyNumber (int n) {
        if (n == 1 || n == 7) return true;
        int sum = n;
        int temp = n;
        while (sum > 9) {
            sum = 0;
            while (temp != 0) {
                sum += Convert.ToInt32 (Math.Pow (temp % 10, 2));
                temp /= 10;
            }
            if (sum == 1) return true;
            Console.WriteLine (sum + " " + temp);
            temp = sum;
        }
        if (sum == 7) return true;
        return false;
    }
    // static void Main (string[] args) {
    //     Console.WriteLine (happyNumber (11));
    // }
}
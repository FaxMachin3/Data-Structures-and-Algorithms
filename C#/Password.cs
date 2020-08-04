using System;
using System.Text;
class PrintPassword {
    private static void GeneratePasswords (string str, StringBuilder tempStr, int index, ref int count) {
        if (tempStr.Length >= str.Length) {
            Console.WriteLine (tempStr.ToString () +" "+(++count));
            return;
        }

        if (index >= str.Length) return;

        tempStr.Append (str[index]);
        GeneratePasswords (str, tempStr, index + 1, ref count);
        tempStr.Remove (tempStr.Length - 1, 1);
        tempStr.Append (Char.ToUpper (str[index]));
        GeneratePasswords (str, tempStr, index + 1, ref count);
        tempStr.Remove (tempStr.Length - 1, 1);
    }
    // public static void Main (string[] args) {
    //     int count = 0;
    //     GeneratePasswords ("eight", new StringBuilder (), 0, ref count);
    // }
}
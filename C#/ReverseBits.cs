using System;
public class RB {
    public static uint reverseBits (uint n) {
        uint result = 0;

        for(int i = 0; i < 31; i++) {
            uint bit = n & 1;
            if (bit == 1)
                result |= 1;
            result <<= 1;
            n >>= 1;
        }

        return result;
    }
    // public static void Main (string[] args) {
    //     // Console.WriteLine (Convert.ToUInt64 ("00000010100101000001111010011100", 2));
    //     Console.WriteLine (reverseBits (43261596));
    // }
}
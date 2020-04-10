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

class SpecialString {

    // Complete the substrCount function below.
    static long substrCount(int n, string s) {
        // store count of special 
        // Palindromic substring 
        int result = 0; 
    
        // it will store the count  
        // of continues same char 
        int[] sameChar = new int[n]; 
        for(int v = 0; v < n; v++) 
        sameChar[v] = 0; 
    
        int i = 0; 
    
        // traverse string character 
        // from left to right 
        while (i < n)  
        { 
    
            // store same character count 
            int sameCharCount = 1; 
    
            int j = i + 1; 
    
            // count smiler character 
            while (j < n &&  
                s[i] == s[j]) 
            { 
                sameCharCount++; 
                j++; 
            } 
    
            // Case : 1 
            // so total number of  
            // substring that we can 
            // generate are : K *( K + 1 ) / 2 
            // here K is sameCharCount 
            result += (sameCharCount *  
                    (sameCharCount + 1) / 2); 
    
            // store current same char  
            // count in sameChar[] array 
            sameChar[i] = sameCharCount;
    
            // increment i 
            i = j; 
        } 
    
        // Case 2: Count all odd length 
        //         Special Palindromic 
        //         substring 
        for (int j = 1; j < n; j++) 
        { 
            // if current character is  
            // equal to previous one  
            // then we assign Previous  
            // same character count to 
            // current one 
            
            if (s[j] == s[j - 1]) 
                sameChar[j] = sameChar[j - 1]; 

            // case 2: odd length 
            if (j > 0 && j < (n - 1) && 
            (s[j - 1] == s[j + 1] && 
                s[j] != s[j - 1])) 
                result += Math.Min(sameChar[j - 1], 
                                sameChar[j + 1]);
        }

        return result;
    }

    // static void Main(string[] args) {
    //     string s = "mnonopoo";

    //     Console.WriteLine(substrCount(s.Length, s));
    // }
}

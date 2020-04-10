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

class MTR {

    // Complete the minTime function below.

    static long minTime(long[] machines, long goal)
    {
        long min = machines[0];
        long max = machines[0];
        foreach(var machine in machines){
            if(machine > max)
                max = machine;
            if(machine < min)
                min = machine;
        }
        long maximumPossibleTime = max * goal / machines.Length;
        long minimumPossibleTime = min * goal / machines.Length;
        long numberOfDays = BinarySearchForOptimalTime(machines, goal, minimumPossibleTime, maximumPossibleTime);
        return numberOfDays;
    }

    static long BinarySearchForOptimalTime(long[] machines, long goal, long min, long max)
    {
        long mid = 0, noOfItems;

        while(min<max)
        {
            mid = min + (max - min) / 2;
            noOfItems = CalculateItemsForGivenDays(machines, mid);
            if(noOfItems < goal)
                min = mid + 1;
            else
                max = mid;
        }
        return max;
    }

    static long CalculateItemsForGivenDays(long[] machines, long days)
    {
        long items = 0;
        for(int i=0; i<machines.Length; i++)
            items += (days/machines[i]);
        return items;
    }

    // static void Main(string[] args) {
    //     long ans = minTime(new long[] {1, 3, 4}, 10);

    //     Console.WriteLine(ans);
    // }
}

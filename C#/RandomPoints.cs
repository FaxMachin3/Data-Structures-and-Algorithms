using System;
using System.Collections.Generic;
public class RPS {
    int numberOfPoints;
    List<int> cumulativeSum;
    int[][] rects;
    Random rand;
    public RPS (int[][] rects) {
        this.numberOfPoints = 0;
        this.cumulativeSum = new List<int> (rects.Length);
        this.rand = new Random ();
        this.rects = rects;

        Populate ();
    }

    public int[] Pick () {
        int newPick = rand.Next (numberOfPoints + 1);
        int rectIndex = FindRect (newPick);

        int width = rects[rectIndex][2] - rects[rectIndex][0] + 1;
        int height = rects[rectIndex][3] - rects[rectIndex][1] + 1;
        int pointsInRect = width * height;

        int startingPoint = cumulativeSum[rectIndex] - pointsInRect;

        return new int[] {
            rects[rectIndex][0] + (newPick - startingPoint) % width,
                rects[rectIndex][1] + (newPick - startingPoint) / width
        };
    }

    private void Populate () {
        foreach (var rect in rects) {
            numberOfPoints += (rect[2] - rect[0] + 1) * (rect[3] - rect[1] + 1);
            cumulativeSum.Add (numberOfPoints);
        }
    }

    private int FindRect (int newPick) {
        int left = 0;
        int right = rects.Length - 1;

        while (left <= right) {
            int mid = left + (right - left) / 2;

            if (cumulativeSum[mid] == newPick)
                return mid;
            else if (cumulativeSum[mid] > newPick)
                right = mid - 1;
            else
                left = mid + 1;
        }

        return left;
    }
}

class RP {
    // public static void Main (string[] args) {
    //     var obj = new RPS (new int[][] {
    //         new int[] {-2, -2, -1, -1 },
    //             new int[] { 1, 0, 3, 0 }
    //     });

    //     Console.WriteLine (string.Join (",", obj.Pick ()));
    //     Console.WriteLine (string.Join (",", obj.Pick ()));
    //     Console.WriteLine (string.Join (",", obj.Pick ()));
    //     Console.WriteLine (string.Join (",", obj.Pick ()));
    //     Console.WriteLine (string.Join (",", obj.Pick ()));
    // }
}
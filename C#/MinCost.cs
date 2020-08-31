using System;
public class MC {
    static int[] daysTravel;
    static int minCost;

    public static int MincostTickets (int[] days, int[] costs) {
        daysTravel = new int[] { 1, 7, 30 };
        minCost = int.MaxValue;

        MincostTicketsUtil (days, costs, 0, 0, 0);

        return minCost;
    }

    private static void MincostTicketsUtil (int[] days, int[] costs, int index, int day, int cost) {
        if (index >= days.Length) {
            minCost = Math.Min (minCost, cost);
            return;
        }

        if (index > 0 && days[index] < day) {
            MincostTicketsUtil (days, costs, index + 1, day, cost);
            return;
        }

        for (int i = 0; i < 3; i++) {
            MincostTicketsUtil (days, costs, index + 1, days[index] + daysTravel[i], cost + costs[i]);
        }
    }

    // public static void Main (string[] args) {
    //     Console.WriteLine (MincostTickets (new int[] { 1, 4, 6, 7, 8, 20 }, new int[] { 2, 7, 15 }));
    // }
}
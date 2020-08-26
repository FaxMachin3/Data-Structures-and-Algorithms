using System;
public class MC {
    static int[] daysTravel;

    public static int MincostTickets (int[] days, int[] costs) {
        daysTravel = new int[] { 1, 7, 30 };
        return MincostTicketsUtil (days, costs, 0, 0);
    }

    private static int MincostTicketsUtil (int[] days, int[] costs, int dayIndex, int daysLeft) {
        if (dayIndex >= days.Length)
            return 0;

        if (dayIndex > 0) {
            int left = days[dayIndex] - days[dayIndex] - 1;
            daysLeft -= left;
            if (daysLeft > 0)
                return MincostTicketsUtil (days, costs, dayIndex + 1, daysLeft - 1);
        }

        int cost = int.MaxValue;

        for (int i = 0; i < 3; i++) {
            cost = Math.Min (cost, costs[i] + MincostTicketsUtil (days, costs, dayIndex + 1,
                daysTravel[i] - 1));
        }

        return cost;
    }

    public static void Main (string[] args) {
        Console.WriteLine (MincostTickets (new int[] { 1, 4, 6, 7, 8, 20 }, new int[] { 2, 7, 15 }));
    }
}
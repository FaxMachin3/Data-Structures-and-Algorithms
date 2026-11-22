// LeetCode 435: Non-overlapping Intervals
// Time: O(n log n). The scan uses O(1) extra space.

function eraseOverlapIntervals(intervals: number[][]): number {
    intervals.sort((a, b) => a[1] - b[1]);
    let overlaps = 0;
    let lastInterval = intervals[0][1];

    for (let i = 1; i < intervals.length; i++) {
        const [start, end] = intervals[i];

        if (lastInterval > start) {
            overlaps++;
            continue;
        }

        lastInterval = end;
    }

    return overlaps;
};

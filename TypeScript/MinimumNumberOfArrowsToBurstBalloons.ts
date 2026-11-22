// LeetCode 452: Minimum Number of Arrows to Burst Balloons
// Time: O(n log n). The scan uses O(1) extra space.

function findMinArrowShots(points: number[][]): number {
    points.sort((a,b) => a[1]-b[1]);
    let arrows = 1;
    let lastArrowAt = points[0][1];

    for(let i = 1; i < points.length; i++) {
        const [start, end] = points[i];
        if(lastArrowAt >= start) continue;

        lastArrowAt = end;
        arrows++;
    }

    return arrows;
};

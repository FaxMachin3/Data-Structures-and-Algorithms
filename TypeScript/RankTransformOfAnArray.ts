// LeetCode 1331: Rank Transform of an Array

function arrayRankTransform(arr: number[]): number[] {
    const n = arr.length;
    const sorted = arr.map((num, i) => [num, i]).sort((a, b) => a[0] - b[0]);
    const ranks = new Array(n);

    let rank = 1;
    for (let i = 0; i < n; i++) {
        const [num, index] = sorted[i];
        if (i > 0 && num !== sorted[i - 1][0]) rank++;
        ranks[index] = rank;
    }

    return ranks;
}

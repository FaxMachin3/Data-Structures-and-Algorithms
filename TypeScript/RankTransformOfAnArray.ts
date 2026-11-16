// LeetCode 1331: Rank Transform of an Array

function arrayRankTransform(arr: number[]): number[] {
    const uniqueValues = [...new Set(arr)].sort((a, b) => a - b);
    const rankByValue = new Map<number, number>();

    uniqueValues.forEach((value, index) => {
        rankByValue.set(value, index + 1);
    });

    return arr.map(value => rankByValue.get(value)!);
}

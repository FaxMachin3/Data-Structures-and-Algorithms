// LeetCode 1431: Kids With the Greatest Number of Candies
// Time: O(n). Extra space: O(1), excluding the result array.

function kidsWithCandies(candies: number[], extraCandies: number): boolean[] {
    let maxC = 0;
    const result = new Array<boolean>(candies.length);

    for(let i = 0; i < candies.length; i++) {
        maxC = Math.max(maxC, candies[i]);
    }

    for(let i = 0; i < candies.length; i++) {
        if(candies[i]+extraCandies >= maxC) result[i] = true;
        else result[i] = false;
    }

    return result;
};

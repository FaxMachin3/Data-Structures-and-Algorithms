// LeetCode 605: Can Place Flowers
// Time: O(n). Extra space: O(1).

function canPlaceFlowers(flowerbed: number[], n: number): boolean {
    for(let i = 0; i < flowerbed.length; i++) {
        if(flowerbed[i] === 0 &&
        (flowerbed[i-1] || 0) === 0 &&
        (flowerbed[i+1] || 0)=== 0) {
            flowerbed[i] = 1;
            n--;
        }
    }

    return n <= 0;
};

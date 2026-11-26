// LeetCode 3360: Stone Removal Game

function canAliceWin(n: number): boolean {
    let remove = 10;

    while (n>= remove) {
        n-=remove;
        remove--;
    }

    return remove % 2 !== 0
};
